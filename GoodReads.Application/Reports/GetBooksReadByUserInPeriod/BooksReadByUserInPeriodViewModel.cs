using GoodReads.Application.Books.Models;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Reports.GetBooksReadByUserInPeriod;

public sealed record BooksReadByUserInPeriodViewModel(
    UserViewModel User,
    DateTime StartDate,
    DateTime FinishDate,
    int BooksRead);