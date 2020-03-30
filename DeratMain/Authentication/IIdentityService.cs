using DeratMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeratMain.Authentication
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> Login(LoginModel loginModel);
    }
}
