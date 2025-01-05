using System;
using AutoMapper;

namespace UsersApi.Profiles;

public class UserDetailProfile: Profile
{
    public UserDetailProfile() {
        CreateMap<Entities.UserDetail, Models.UserDetailDto>();
        CreateMap<Models.UserDetailDto, Entities.UserDetail>();
    }
}
