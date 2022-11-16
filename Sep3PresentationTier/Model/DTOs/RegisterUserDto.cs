namespace Model.DTOs;

public class RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public RegisterUserDto(string email, string password, string name)
    {
        Email = email;
        Password = password;
        Name = name;
    }
}