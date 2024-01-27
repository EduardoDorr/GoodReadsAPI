using GoodReads.Domain.Ratings;

namespace GoodReads.Application.Ratings.Models;

public sealed record RatingViewModel(int Id, RatingGrade Grade, string Description, DateTime StartDate, DateTime FinishDate, bool Active);