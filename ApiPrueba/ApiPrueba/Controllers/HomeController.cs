using modelos;
using repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiPrueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public JsonResult GetListProductos()
        {
            try
            {
                repoProducts rProductos = new repoProducts();
                List<Productos> products;
                products = rProductos.GetListProductos().ToList();

                return Json(new { Success = true, Data = products }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {

                return Json(new { Success = false, Message = err.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetUsuario(Usuarios usua)
        {
            try
            {
                repoUsua rUsuarios = new repoUsua();
                List<Usuarios> usuarios = new List<Usuarios>();
                usuarios = rUsuarios.GetListUsuarios().ToList();

                foreach (var item in usuarios)
                {
                    if (usua.Usua == item.Usua && usua.Pass == item.Pass)
                    {
                        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {

                return Json(new { Success = false, Message = err.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
