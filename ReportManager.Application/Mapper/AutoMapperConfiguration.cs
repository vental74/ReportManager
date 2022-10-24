using AutoMapper;
using ReportManager.Application.Model;
using ReportManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        /// <summary>
        /// Ignoring id for entities for sake of updating.
        /// </summary>
        public AutoMapperConfiguration()
        {
            CreateMap<ReportEntity, ReportModel>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.Id + "pidaras"))
            .ReverseMap()
            .ForMember(x => x.IdUser, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
