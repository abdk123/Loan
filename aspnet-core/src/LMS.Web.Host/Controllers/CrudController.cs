//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Abp.Application.Services;
//using Abp.AspNetCore.Mvc.Controllers;
//using LMS.Crud.Dto;
//using LMS.Factories;
//using Microsoft.AspNetCore.Mvc;
//using Syncfusion.EJ2.Base;

//namespace LMS.Web.Host.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    public class CrudController : AbpController
//    {
//        private readonly AppServiceFactory _appServiceFactory;
//        public CrudController(AppServiceFactory appServiceFactory)
//        {
//            _appServiceFactory = appServiceFactory;
//        }

//        [HttpPost]
//        public async Task<ActionResult> GetForGrid([FromBody] DataManagerRequest dm)
//        {
//            var appService = _appServiceFactory.Create();
//            IEnumerable<ReadIndexDto> countries = await appService.GetAllForGridAsync();

//            var operations = new DataOperations();
//            if (dm.Where != null && dm.Where.Count > 0)
//            {
//                countries = operations.PerformFiltering(countries, dm.Where, "and");
//            }

//            if (dm.Sorted != null && dm.Sorted.Count > 0)
//            {
//                countries = operations.PerformSorting(countries, dm.Sorted);
//            }

//            var count = countries.Count();

//            if (dm.Skip != 0)
//            {
//                countries = operations.PerformSkip(countries, dm.Skip);
//            }

//            if (dm.Take != 0)
//            {
//                countries = operations.PerformTake(countries, dm.Take);
//            }

//            //var serializerSettings = new JsonSerializerSettings()
//            //{
//            //    ContractResolver = new DefaultContractResolver()
//            //};

//            return Json(new { result = countries, count = count });
//        }
//    }
//}
