using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Serilog;
namespace DFI.Application.Exceptions
{
    public static class HttpResponseExtension
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonConvert.DeserializeObject<T>(data);
        }

        public static object ContentAsTypeJson(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            null :
                            JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data));
        }

        public static string ContentAsJson(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Log.Error("Something went wrong calling the API:" + response.ReasonPhrase);
            }
            // throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.SerializeObject(data);
        }

        public static string ContentAsString(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Log.Error("Something went wrong calling the API:" + response.ReasonPhrase);
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Log.Error("Something went wrong calling the API:" + response.ReasonPhrase);
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return System.Text.Json.JsonSerializer.Deserialize<T>(dataAsString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
