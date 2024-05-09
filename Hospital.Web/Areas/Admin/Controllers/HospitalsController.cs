using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Hospital.Models;
using System.Diagnostics.Contracts;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HospitalsController : Controller
    {
        private readonly IHospitalInfo _hospitalInfo;
        private readonly IHttpClientFactory _httpClientFactory;

        public HospitalsController(IHospitalInfo hospitalInfo, IHttpClientFactory httpClientFactory)
        {
            _hospitalInfo = hospitalInfo;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var pagedResult = _hospitalInfo.GetAll(pageNumber, pageSize);
            return View(pagedResult);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _hospitalInfo.GetHospitalById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel vm)
        {
            _hospitalInfo.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new HospitalInfoViewModel();
     
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HospitalInfoViewModel vm)
        {
            _hospitalInfo.InsertHospitalInfo(vm);
            return RedirectToAction("Index");
        }





        public IActionResult Delete(int id)
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        }

    }
}
