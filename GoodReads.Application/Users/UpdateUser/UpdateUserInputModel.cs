namespace GoodReads.Application.Users.UpdateUser;

public sealed record UpdateUserInputModel(string Name, string Email, bool Active);