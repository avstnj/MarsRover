using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Rovers.Model.Data;

namespace Rovers.UI.Controllers
{
    public class RoversController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RoversModel data)
        {
            TempData["uyari"] = "";
            if (data.X > 0 && data.Y > 0 && data.WAY != null && data.ROVER_DIRECTIVE != null)
            {
                RoversModel roversModel = new RoversModel(data.X, data.Y, data.WAY.ToUpper(), data.ROVER_DIRECTIVE.ToUpper());

                var uri = string.Format("{0}", "http://localhost:60618/api/rovers");

                RoversModel roversresult = PostMethod<RoversModel>(roversModel, uri, null);
                if (roversresult != null)
                {
                    return RedirectToAction("Result", roversresult);
                }
                else
                {
                    TempData["uyari"] = "Hata Oluştu";
                    return View(TempData["uyari"]);
                }
            }
            else
            {
                TempData["uyari"] = "Bilgiler Eksiksiz girilmemelidir...";
                return View(TempData["uyari"]);
            }
        }
        public IActionResult Result(RoversModel roversresult)
        {
            return View(roversresult);
        }

        public T PostMethod<T>(object obj, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };

            var result = GetResult<T>(client, request, obj, headers);

            return result;
        }
        private T GetResult<T>(RestClient client, RestRequest request, object obj = null, Dictionary<string, string> headers = null)
        {
            if (headers != null) //header varsa requeste headerları ekle
                foreach (var header in headers)
                    request.AddHeader(header.Key, header.Value);

            if (obj != null) //post,put,delete gibi işlemler için servise gönderilecek nesne varsa requeste ekle
                request.AddJsonBody(obj);

            //client üzerinden requesti servise yolla
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }

}