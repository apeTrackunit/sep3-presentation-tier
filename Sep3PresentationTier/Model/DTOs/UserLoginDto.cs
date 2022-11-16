namespace Model;

public class UserLoginDto
{
    private string email { get; set; }
    private string password { get; set; }

    public UserLoginDto(String email, String password)
    {
        this.email = email;
        this.password = password;
    }
}