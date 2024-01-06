using GoodReads.Application.Ratings.Models;

namespace GoodReads.Application.Users.Models;

public record GetUserWithRatingsViewModel(int Id, string Name, string Email,
                                          ICollection<GetRatingViewModel> Ratings, bool IsActive);