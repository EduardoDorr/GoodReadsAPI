namespace GoodReads.Application.Users.Models;

public record GetUserViewModel(int Id, string Name, string Email, bool IsActive);