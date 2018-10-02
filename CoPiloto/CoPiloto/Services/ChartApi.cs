using CoPiloto.Models;
using CoPiloto.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoPiloto.Services
{
    class ChartApi
    {
        static Lazy<ChartApi> LazyApi = new Lazy<ChartApi>(() => new ChartApi());

        public static ChartApi Current => LazyApi.Value;

        HttpClient Client;

        static readonly Category Sid      = new Category { CategoryId = 1, Title = "Sid" };
        static readonly Category General  = new Category { CategoryId = 1, Title = "General" };
        static readonly Category Star     = new Category { CategoryId = 1, Title = "Star" };
        static readonly Category Approach = new Category { CategoryId = 1, Title = "Approach" };
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

        public ObservableCollection<LocalChart> PrepareChart(Charts charts)
        {
            var teste = new ObservableCollection<LocalChart>();

            foreach (var item in charts.Approach)
            {
                teste.Add(new LocalChart
                {
                    Uri = item.Url,
                    ChartName = item.Chartname,
                    Category = Approach

                });
            }

            foreach (var item in charts.Sid)
            {
                teste.Add(new LocalChart
                {
                    Uri = item.Url,
                    ChartName = item.Chartname,
                    Category = Sid

                });
            }

            foreach (var item in charts.Star)
            {
                teste.Add(new LocalChart
                {
                    Uri = item.Url,
                    ChartName = item.Chartname,
                    Category = Star

                });
            }

            foreach (var item in charts.General)
            {
                teste.Add(new LocalChart
                {
                    Uri = item.Url,
                    ChartName = item.Chartname,
                    Category = General

                });
            }

            return teste;
        }
    }
}
