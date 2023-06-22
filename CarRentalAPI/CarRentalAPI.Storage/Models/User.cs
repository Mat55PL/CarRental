namespace CarRentalAPI.Storage.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public UserRank Rank { get; set; }
}

public enum UserRank
{
    Ceo,
    Admin,
    User
}