namespace Model.DTOs;

public class UserDto
{
    public String Id { get; set; }
    public String UserName { get; set; }

    public UserDto(string id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}