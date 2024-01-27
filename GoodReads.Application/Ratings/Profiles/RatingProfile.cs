using AutoMapper;

using GoodReads.Domain.Ratings;
using GoodReads.Application.Ratings.Models;
using GoodReads.Application.Ratings.CreateRating;

namespace GoodReads.Application.Ratings.Profiles;

public class RatingProfile : Profile
{
    public RatingProfile()
    {
        CreateMap<CreateRatingCommand, Rating>();
        CreateMap<Rating, RatingViewModel>();
    }
}