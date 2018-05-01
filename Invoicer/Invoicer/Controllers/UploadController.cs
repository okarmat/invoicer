using Invoicer.Infrastructure;
using Invoicer.Models;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;
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
        private readonly IUnitOfWork _unitOfWork;

        public UploadController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            var viewModel = new UploadFileFormViewModel
            {
                InvoiceTypes = _unitOfWork.InvoiceTypes.GetInvoiceTypes()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UploadFile(UploadFileFormViewModel viewModel, HttpPostedFileBase file)
        {
            try
            {
                if(file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    if(viewModel.InvoiceType == (int)InvoiceTypeEnum.FuelInvoice)
                        TempData["invoice"] = OcrUtils.GetFuelInvoicViewModel(_path);                      
                    System.IO.File.Delete(_path);

                    return RedirectToAction("Create", "FuelInvoice") ;
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