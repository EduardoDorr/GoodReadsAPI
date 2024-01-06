using AutoMapper;

using GoodReads.Domain.Entities;
using GoodReads.Application.Users.Models;
using GoodReads.Application.Users.Commands;

namespace GoodReads.Application.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, GetUserViewModel>();
        CreateMap<User, GetUserWithRatingsViewModel>();
    }
}