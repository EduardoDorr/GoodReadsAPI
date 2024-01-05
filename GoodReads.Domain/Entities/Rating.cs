namespace GoodReads.Domain.Entities;

public class Rating : BaseEntity
{
    public int Grade { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime FinishDate { get; private set; }
    public int UserId { get; private set; }
    public int BookId { get; private set; }

    public virtual User User { get; private set; }
    public virtual Book Book { get; private set; }

    protected Rating() { }

    public Rating(int grade, string description, DateTime startDate, DateTime finishDate, int userId, int bookId)
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

    public void Update(int grade, string description, DateTime startDate, DateTime finishDate)
    {
        if (!ValidateStartAndFinishDate(startDate, finishDate))
            return;

        Grade = grade;
        Description = description;
        StartDate = startDate;
        FinishDate = finishDate;

        UpdatedAt = DateTime.Now;
    }

    private bool ValidateStartAndFinishDate(DateTime startDate, DateTime finishDate)
    {
        return DateTime.Compare(startDate, finishDate) <= 0;
    }
}