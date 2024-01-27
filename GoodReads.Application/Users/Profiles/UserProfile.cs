using AutoMapper;

using GoodReads.Domain.Users;
using GoodReads.Application.Users.Models;
using GoodReads.Application.Users.CreateUser;

namespace GoodReads.Application.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, UserViewModel>();
        CreateMap<User, UserWithRatingsViewModel>();
    }
}