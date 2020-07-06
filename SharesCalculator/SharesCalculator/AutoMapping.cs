using AutoMapper;
using SharesCalculator.Api.Models;
using SharesCalculator.Business.Models;

namespace SharesCalculator.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SaleDetailRequest, SaleDetail>();
            CreateMap<ShareInfo, ShareInfoResponse>();
        }
    }
}
