using AutoMapper;
using Vericode.Api.Models.DTO;
using Vericode.Domain.Entities;

namespace Vericode.Api
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
        }

        private void CreateMappingResponse()
        {
            CreateMap<UserEntity, UserDTO>();
        }
    }
}
