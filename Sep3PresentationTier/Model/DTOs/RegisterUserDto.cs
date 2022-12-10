namespace Model.DTOs;

public class RegisterUserDto
{
    public string userName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }


    public RegisterUserDto(string name, string email, string password, string role)
    {
        this.userName = name;
        this.email = email;
        this.password = password;
        this.role = role;
    }
}