namespace GoodReads.Application.Ratings.Models;

public record GetRatingViewModel(int Id, decimal Grade, string Description, DateTime StartDate, DateTime FinishDate);