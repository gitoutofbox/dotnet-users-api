using System;
using AutoMapper;

namespace UsersApi.Profiles;

public class UserProfile: Profile
{
    public UserProfile() {
        CreateMap<Entities.User, Models.UserDto>();
        CreateMap<Models.UserDto, Entities.User>();

        CreateMap<Models.UserAddDto, Entities.User>();

        CreateMap<Models.UserUpdateDto, Entities.User>();
       
    }
}
