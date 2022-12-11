namespace Model;

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public User(string id, string email, string userName)
    {
        Id = id;
        Email = email;
        UserName = userName;
    }
}