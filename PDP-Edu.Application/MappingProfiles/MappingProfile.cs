using AutoMapper;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models.Teacher;
using PDP_Edu.Domain.Entities;
using PDP_Edu.Domain.Enums;

namespace PDP_Edu.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IHashProvider hashProvider)
        {
            CreateMap<User, TeacherViewModel>();

            CreateMap<CreateTeacherModel, User>()
                .ForMember(d => d.Role, o => o.MapFrom(s => UserRole.Teacher))
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => hashProvider.GetHash(s.Password)));

            CreateMap<UpdateTeacherModel, User>()
                .AfterMap((model, entity) =>
                {
                    entity.PasswordHash = model.Password == null
                        ? entity.PasswordHash
                        : hashProvider.GetHash(model.Password);
                });
        }
    }
}
