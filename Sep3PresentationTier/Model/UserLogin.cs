namespace Model;

public class UserLogin
{
    private String email;
    private String password;

    public UserLogin(String email, String password)
    {
        this.email = email;
        this.password = password;
    }
}