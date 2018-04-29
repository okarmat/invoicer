using Invoicer.BussinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invoicer.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if(file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    var stringData = OcrUtils.GetStringDataFromFile(_path);
                    System.IO.File.Delete(_path);
                    ViewBag.Message = stringData;
                }
                
                return View();
            }
            catch
            {
                ViewBag.Message = "Wystąpił błąd podczas ładowania pliku.";
                return View();
            }
        }
    }
}