using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Services.IServices
{
    public interface IAuthServices
    {
        Task<ResponseModel<object>> Register(RegistrationDto model);
        Task<ResponseModel<Account>> Login(loginDto model);
    }
}
