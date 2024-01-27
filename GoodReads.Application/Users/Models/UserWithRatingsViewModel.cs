using GoodReads.Application.Ratings.Models;

namespace GoodReads.Application.Users.Models;

public record UserWithRatingsViewModel(
    int Id,
    string Name,
    string Email,
    ICollection<RatingViewModel> Ratings,
    bool Active);