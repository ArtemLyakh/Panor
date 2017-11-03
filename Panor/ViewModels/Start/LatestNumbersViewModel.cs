using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Start
{
    public class LatestNumbersViewModel : BaseViewModel
    {
        public LatestNumbersViewModel()
        {
            Actions = new List<(string, ICommand)>()
            {
                ("option1", Command1),
                ("option2", Command2),
                ("option3", Command3),
            };

            ViewState = Views.LoadingContentViewState.Loading;


            Load();
        }

        private List<Models.Numbers.NumberPreview> _numbers;
        public List<Models.Numbers.NumberPreview> Numbers 
        {
            get => _numbers;
            set => SetProperty(ref _numbers, value);
        }

        public List<(string, ICommand)> Actions { get; set; }


        private readonly ICommand Command1 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("q" + id.ToString());
        });
        private readonly ICommand Command2 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("w" + id.ToString());
        });
        private readonly ICommand Command3 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("e" + id.ToString());
        });

        private Views.LoadingContentViewState _viewState;
        public Views.LoadingContentViewState ViewState
        {
            get => _viewState;
            set => SetProperty(ref _viewState, value);
        }



        private async Task Load()
        {
            ViewState = Views.LoadingContentViewState.Loading;

            List<Models.Numbers.NumberPreview> res;
            try
            {
                res = await App.Current.Api.GetLatestNumbers(GetNewToken());
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                    App.Current.ToastService.Show(ex.Message);

                ViewState = Views.LoadingContentViewState.Reload;

                return;
            }
            finally
            {
                ClearToken();
            }


            Numbers = res;
            ViewState = Views.LoadingContentViewState.Content;
        }

    }
}
