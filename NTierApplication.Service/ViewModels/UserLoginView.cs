﻿namespace NTierApplication.Service.ViewModels;

public class UserLoginView
{
    public string GrantType { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public long ClientId { get; set; }
}
