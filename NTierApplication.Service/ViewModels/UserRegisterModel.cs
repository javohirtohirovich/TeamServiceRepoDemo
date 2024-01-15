namespace NTierApplication.Service.ViewModels;

public class UserRegisterModel
{
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
