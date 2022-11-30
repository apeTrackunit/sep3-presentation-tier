namespace Model.DTOs;

public class LoginUserDto
{
    public string email { get; set; }
    public string password { get; set; }

    public LoginUserDto(string email, string password)
    {
        this.email = email;
        this.password = password;
    }
}