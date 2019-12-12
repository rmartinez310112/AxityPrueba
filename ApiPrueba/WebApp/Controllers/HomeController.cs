using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var sendServicioResponse = SendtoOtherApi("http://localhost:5050/Home/GetListProductos");
            productosGet products = new productosGet();
            if (sendServicioResponse.StatusDescription.ToUpper() == "OK" && sendServicioResponse.StatusCode == HttpStatusCode.OK)
            {
                var json = sendServicioResponse.Content;
                products = JsonConvert.DeserializeObject<productosGet>(json);


            }
            return View(products.Data);
        }
        [NonAction]
        public IRestResponse SendtoOtherApi(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("content-type", "application/json");
            var result = client.Execute(request);
            return result;
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validar(LoginUsers credentials)
        {
            var sendServicioResponse = SendtoOtherApi("http://localhost:5050/Home/GetUsuario?usua.Usua=" + credentials.Usua + "&usua.Pass=" + credentials.Pass + "");
            if (sendServicioResponse.StatusDescription.ToUpper() == "OK" && sendServicioResponse.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.message = "";

                userResult validar;
                var json = sendServicioResponse.Content;
                validar = JsonConvert.DeserializeObject<userResult>(json);
                List<productos> lst = new List<productos>();
                if (validar.Success == true)
                {
                    var sendServicioResponse1 = SendtoOtherApi("http://localhost:5050/Home/GetListProductos");
                    
                    if (sendServicioResponse1.StatusDescription.ToUpper() == "OK" && sendServicioResponse1.StatusCode == HttpStatusCode.OK)
                    {
                        productosGet products;
                        var json1 = sendServicioResponse1.Content;
                        products = JsonConvert.DeserializeObject<productosGet>(json1);
                        lst = products.Data;

                    }
                    return View("Index",lst);
                }
                else
                {
                    ViewBag.message = "Las credenciales son incorrectas";
                    return View("Login");
                }
            }
            return View();
        }
    }
}