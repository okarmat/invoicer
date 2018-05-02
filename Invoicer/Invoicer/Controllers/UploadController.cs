using Invoicer.Infrastructure;
using Invoicer.Infrastructure.Parsers;
using Invoicer.Infrastructure.Providers;
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
        private readonly IFuelInvoiceViewModelProvider _fuelInvoiceViewModelProvider;

        public UploadController(
            IUnitOfWork unitOfWork,
            IFuelInvoiceViewModelProvider fuelInvoiceViewModelProvider)
        {
            _unitOfWork = unitOfWork;
            _fuelInvoiceViewModelProvider = fuelInvoiceViewModelProvider;
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
            viewModel.InvoiceTypes = _unitOfWork.InvoiceTypes.GetInvoiceTypes();

            if (file != null && file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);
                if (viewModel.InvoiceType == (int)InvoiceTypeEnum.FuelInvoice)
                {
                    var fuelInvoiceViewModel = _fuelInvoiceViewModelProvider.GetFuelInvoiceViewModel(_path);
                    fuelInvoiceViewModel.CurrencyTypes = _unitOfWork.CurrencyTypes.GetCurrencyTypes().ToList();
                    fuelInvoiceViewModel.FuelTypes = _unitOfWork.FuelTypes.GetFuelTypes().ToList();
                    fuelInvoiceViewModel.GasStations = _unitOfWork.GasStations.GetGasStations().ToList();
                    TempData["invoice"] = fuelInvoiceViewModel;
                }
                System.IO.File.Delete(_path);

                return RedirectToAction("Create", "FuelInvoice");
            }
            
            return View(viewModel);
        }
    }
}