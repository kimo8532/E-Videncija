using AutoMapper;
using E_Videncija.Model.TvrtkaConfig;
using E_Videncija.DAL.DataModel;
using E_Videncija.Model.UserInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Repository.Automappers
{
    public class RepositoryMappingService : IRepositoryMappingService
    {

        public Mapper mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserInformationDTO, UserInformation>();
                    cfg.CreateMap<UserInformation, UserInformationDTO>();
                    cfg.CreateMap<TvrtkaConfig, TvrtkaConfigDTO>();
                    cfg.CreateMap<TvrtkaConfigDTO, TvrtkaConfig>();

                });
            mapper = new Mapper(config);
        }
        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
