using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Panor.Services.WebClient
{
    public class WebClient
    {
        private HttpClient client = new HttpClient();

        public WebClient()
        {
        }

        public async Task<(int Code, string Response)> SendAsync(HttpMethod method, Uri uri, CancellationToken cancellationToken, string content = null, int timeout = 20)
        {
            var request = new HttpRequestMessage(method, uri);

            if (App.Current.AuthService.IsLogged)
            {
                request.Headers.TryAddWithoutValidation("Authorization", App.Current.AuthService.SecureAuth);
            }

            if (content != null)
            {
                request.Content = new StringContent(content);
            }

            var timeoutTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(timeout));
            var groupTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutTokenSource.Token, cancellationToken);

            HttpResponseMessage response;
            try
            {
                response = await client.SendAsync(request, groupTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                if (timeoutTokenSource.Token.IsCancellationRequested) throw new TimeoutException();
                else throw;
            }

            return (
                Code: (int)response.StatusCode,
                Response: await response.Content.ReadAsStringAsync()
            );
        }
    }
}
