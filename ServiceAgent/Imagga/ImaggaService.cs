using Newtonsoft.Json;
using RestSharp;
using ServiceAgent.Spoonacular.REntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServiceAgent.Imagga
{
    public class ImaggaService : IImaggaService
    {
        #region fields
        const string? IMAGGA_API_KEY = "acc_32e552f170a3593";
        const string? IMAGGA_SECRET = "47e0dbbb32bee8722508deeb7bf5ffc7";
        const string? BASIC_URL = "https://api.imagga.com/v2/";
        string imageUrl1 = "https://imagga.com/static/images/tagging/wind-farm-538576_640.jpg";
        string basicAuthValue => Convert.ToBase64String(
                                    Encoding.UTF8.GetBytes(
                                        string.Format($"{IMAGGA_API_KEY}:{IMAGGA_SECRET}")));
        #endregion

        public bool IsSimilarImages(string url1, string url2)
        {
            var client = new RestClient($"{BASIC_URL}/images-similarity/categories/general_v3");

            var request = new RestRequest();

            if (url1.Contains("http"))
                 request.AddParameter("image_url", url1);
            else request.AddParameter("image_upload_id", url1);

            if (url2.Contains("http"))
                 request.AddParameter("image2_url", url2);
            else request.AddParameter("image2_upload_id", url2);

            request.AddHeader("Authorization", $"Basic {basicAuthValue}");

            RestResponse response = client.Execute(request);
            string jsonString = response.Content!;
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString!);

            if (jsonObject!.status.type != "success")
                throw new Exception(jsonObject!.status.text);
            return jsonObject!.result.distance < 1.1;
        }

        public string UploadImageToServer(string ImageUrl)
        {
            var client = new RestClient($"{BASIC_URL}/uploads");

            var request = new RestRequest("", Method.Post);
            request.AddHeader("Authorization", $"Basic {basicAuthValue}");
            request.AddFile("image", ImageUrl);

            RestResponse response = client.Execute(request);
            var jsonString = response.Content;
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString!);

            if (jsonObject!.status.type != "success")
                throw new Exception(jsonObject!.status.text);

            return jsonObject!.result.upload_id;
        }

        public void DeleteImageFromServer(string UploadID)
        {
            var client = new RestClient($"{BASIC_URL}/uploads/{UploadID}");

            var request = new RestRequest("", Method.Delete);
            request.AddHeader("Authorization", $"Basic {basicAuthValue}");

            RestResponse response = client.Execute(request);
            var jsonString = response.Content;
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString!);

            if (jsonObject!.status.type != "success")
                throw new Exception(jsonObject!.status.text);

        }
    }
}
