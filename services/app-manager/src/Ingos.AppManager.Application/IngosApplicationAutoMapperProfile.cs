using AutoMapper;
using Ingos.AppManager.Application.Contracts.ApplicationAggregates.Dtos;

namespace Ingos.AppManager.Application
{
    /// <summary>
    ///     AutoMapper object mapper profile
    /// </summary>
    public class IngosApplicationAutoMapperProfile : Profile
    {
        public IngosApplicationAutoMapperProfile()
        {
            CreateMap<AppManager.Domain.ApplicationAggregates.Application, ApplicationDto>();
        }
    }
}