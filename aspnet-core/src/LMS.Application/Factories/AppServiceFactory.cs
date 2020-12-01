//using Abp.Application.Services;
//using Abp.Dependency;
//using LMS.Crud.Dto;
//using LMS.Crud.Interfaces;
//using LMS.Loan.Indexes.Countries;

//namespace LMS.Factories
//{
//    public class AppServiceFactory : ITransientDependency
//    {
//        private readonly IIocResolver _iocResolver;
//        public AppServiceFactory(IIocResolver iocResolver)
//        {
//            _iocResolver = iocResolver;
//        }
//        public static ICrudApplicationSevice<ReadCrudDto> Create() 
//        {
//            return (ICrudApplicationSevice<ReadGrudDto>)_iocResolver.Resolve<CountryAppService>();
//        }
//    }
//}
