using CoPiloto.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoPiloto.Services
{
    class ChartApi
    {
        static Lazy<ChartApi> LazyApi = new Lazy<ChartApi>(() => new ChartApi());

        public static ChartApi Current => LazyApi.Value;

        HttpClient Client;

        ChartApi()
        {
            Client = new HttpClient();
        }

        public async Task<(Charts chart, Info info)> GetChart(string airport)
        {
            try
            {
                var url      = string.Format(Const.Url, airport);
                var uri      = new Uri(url);
                var request  = await Client.GetAsync(uri).ConfigureAwait(false);
                var response = await request.Content.ReadAsStringAsync();
                var aiport   = JObject.Parse(response);

                var info  = aiport[airport]["info"];
                var chart = aiport[airport]["charts"];

                var chartObj = chart?.ToObject<Charts>();
                var infoObj  = info?.ToObject<Info>();

                return (chartObj, infoObj);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
