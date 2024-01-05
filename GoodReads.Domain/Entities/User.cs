using BloodBank.Domain.ValueObjects;

namespace GoodReads.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }

    public virtual ICollection<Rating> Ratings { get; private set; }

    protected User() { }

    public User(string name, string email)
    {
        Name = name;
        Email = new Email(email);
        Ratings = new List<Rating>();

        Active = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}