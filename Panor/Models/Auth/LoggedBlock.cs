using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Panor.Models.Auth
{
    public class LoggedBlock
    {
        public string Fio { get; set; }
        public string Email { get; set; }
        public Uri Image { get; set; }

        public bool FromJson(string json)
        {
            Json.Auth.Profile profile;
            try
            {
                profile = JsonConvert.DeserializeObject<Json.Auth.Profile>(json);
            }
            catch
            {
                return false;
            }

            var fio = new List<string>();
            if (!string.IsNullOrWhiteSpace(profile.last_name)) fio.Add(profile.last_name);
            if (!string.IsNullOrWhiteSpace(profile.name)) fio.Add(profile.name);
            if (!string.IsNullOrWhiteSpace(profile.second_name)) fio.Add(profile.second_name);
            Fio = string.Join(" ", fio);

            Email = profile.email;

            Image = (!string.IsNullOrWhiteSpace(profile.photo) && Uri.TryCreate(profile.photo, UriKind.Absolute, out Uri image))
                ? image
                : null;

            return true;
        }

    }
}
