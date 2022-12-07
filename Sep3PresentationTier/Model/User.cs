namespace Model;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public User()
    {
        
    }
    
    public User(string id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }
}