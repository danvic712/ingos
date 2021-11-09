using AutoMapper;
using Ingos.Application.Contracts.ApplicationAggregates.Dtos;

namespace Ingos.Application
{
    /// <summary>
    /// AutoMapper object mapper profile
    /// </summary>
    public class IngosApplicationAutoMapperProfile : Profile
    {
        public IngosApplicationAutoMapperProfile()
        {
            CreateMap<Domain.ApplicationAggregates.Application, ApplicationDto>();
        }
    }
}