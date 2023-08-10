using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Hebcal
{
    public class DateInformation
    {
        [JsonProperty("title")]
        public string? Title { get; set; } = "";

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        public override string? ToString()
        {
            return $"title: {Title}. date: {Date.ToString("yyyy-MM-dd")}. category: {Category}";
        }
    }
}
