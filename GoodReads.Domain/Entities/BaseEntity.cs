namespace GoodReads.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public bool Active { get; protected set; }

    protected BaseEntity() { }

    public virtual void Activate()
    {
        Active = true;

        UpdatedAt = DateTime.Now;
    }

    public virtual void Deactivate()
    {
        Active = false;

        UpdatedAt = DateTime.Now;
    }
}