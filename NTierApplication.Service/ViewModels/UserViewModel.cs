using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Service.ViewModels;

public class UserViewModel
{
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
