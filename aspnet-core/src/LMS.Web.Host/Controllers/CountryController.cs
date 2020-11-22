using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using LMS.Loan.Indexes.Countries;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Syncfusion.EJ2.Base;

namespace LMS.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CountryController : AbpController
    {
        private readonly ICountryAppService _countryAppService;
        public CountryController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries =await _countryAppService.GetAllAsync();
            return Json(countries);
        }

        [HttpPost]
        public async Task<ActionResult> GetForGrid([FromBody] DataManagerRequest dm)
        {
            IEnumerable<ReadIndexDto> countries = await _countryAppService.GetAllForGridAsync();

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                countries = operations.PerformFiltering(countries, dm.Where, "and");
            }

            if(dm.Sorted!=null && dm.Sorted.Count > 0)
            {
                countries = operations.PerformSorting(countries, dm.Sorted);
            }

            var count = countries.Count();

            if (dm.Skip != 0)
            {
                countries = operations.PerformSkip(countries, dm.Skip);
            }

            if (dm.Take != 0)
            {
                countries = operations.PerformTake(countries, dm.Take);
            }

            //var serializerSettings = new JsonSerializerSettings()
            //{
            //    ContractResolver = new DefaultContractResolver()
            //};

            return Json(new { result = countries, count = count });
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CreateIndexDto country)
        {
            var indexDto = await _countryAppService.CreateAsync(country);
            country.Value = indexDto;
            return Json(country);
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] UpdateIndexDto country)
        {
            var indexDto = await _countryAppService.UpdateAsync(country);
            country.Value = indexDto;
            return Json(country);
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromBody] DeleteIndexDto country)
        {
            await _countryAppService.DeleteAsync(country.Key.Id);
            return Json(country);
        }
    }
}
