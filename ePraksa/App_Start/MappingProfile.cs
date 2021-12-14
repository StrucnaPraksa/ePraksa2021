using AutoMapper;
using PracticeManagement.Core.Dto;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.App_Start
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<Profesor, ProfesorDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            Mapper.CreateMap<Faculty, FacultyDto>();
            Mapper.CreateMap<Faculty2, Faculty2Dto>();
            //Mapper.CreateMap<FacultySector, FacultySectorDto>();
            Mapper.CreateMap<FacultyType, FacultyTypeDto>();
            //Mapper.CreateMap<ProfesorFormViewModel, Profesor>();
        }
    }
}