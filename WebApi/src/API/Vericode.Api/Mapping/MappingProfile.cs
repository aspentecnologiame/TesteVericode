using AutoMapper;
using Vericode.Api.Models.DTO;
using Vericode.Domain.Entities;

namespace Vericode.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMappingRequest();
            CreateMappingResponse();
        }

        private void CreateMappingRequest()
        {
            CreateMap<UserDTO, UserEntity>();
            CreateMap<TaskDTO, TaskEntity>();
        }

        private void CreateMappingResponse()
        {
            CreateMap<UserEntity, UserDTO>();
            CreateMap<TaskEntity, TaskDTO>();
        }
    }
}
