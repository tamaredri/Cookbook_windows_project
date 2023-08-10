using Newtonsoft.Json;
using ServiceAgent.Spoonacular.REntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Hebcal
{
    public class HebcalService : IHebcalService
    {
        #region fields
        readonly HttpClient client = new();

        readonly string url = $"https://www.hebcal.com";

        string? Parameter1 { get; set; }
        string? Parameter2 { get; set; }


        /// GetFullQuery Doc
        /// <returns>The complete query ready to be sent to the website
        /// </returns>
        private string? GetFullQuery()
        {
            var a = $"/hebcal?v=1&cfg=json&maj=on&&min=on&mod=on&nx=on&ss=on&mf=on&start={Parameter1}&end={Parameter2}/items";
            return a;
        }

        #endregion

        public HebcalService()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
        }

        public async Task<DateInformation> GetHebrewEvent(DateTime start, DateTime end)
        {
            Parameter1 = start.ToString("yyyy-MM-dd");
            Parameter2 = end.ToString("yyyy-MM-dd");

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");

            }
            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);

            var itemsProperty = jsonObject!.items;
            if (itemsProperty.HasValues)
                return jsonObject!.items[0].ToObject<DateInformation>();
            else return new DateInformation() { Date = start, Title = "", Category = "no category"};
        }
    }
}
