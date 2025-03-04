﻿namespace NTierApplication.Service.ViewModels;

public class UserViewModel
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
