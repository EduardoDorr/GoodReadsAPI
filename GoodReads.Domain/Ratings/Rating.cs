using GoodReads.Core.Entities;
using GoodReads.Domain.Books;
using GoodReads.Domain.Users;

namespace GoodReads.Domain.Ratings;

public class Rating : BaseEntity
{
    public RatingGrade Grade { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime FinishDate { get; private set; }
    public int UserId { get; private set; }
    public int BookId { get; private set; }

    public virtual User User { get; private set; }
    public virtual Book Book { get; private set; }

    protected Rating() { }

    public Rating(RatingGrade grade, string description, DateTime startDate, DateTime finishDate, int userId, int bookId)
    {
        if (!ValidateStartAndFinishDate(startDate, finishDate))
            return;

        Grade = grade;
        Description = description;
        StartDate = startDate;
        FinishDate = finishDate;
        UserId = userId;
        BookId = bookId;

        Active = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(RatingGrade grade, string description, DateTime startDate, DateTime finishDate, bool active)
    {
        if (!ValidateStartAndFinishDate(startDate, finishDate))
            return;

        Grade = grade;
        Description = description;
        StartDate = startDate;
        FinishDate = finishDate;
        Active = active;

        UpdatedAt = DateTime.Now;
    }

    public static bool ValidateStartAndFinishDate(DateTime startDate, DateTime finishDate)
        => startDate < finishDate;
}