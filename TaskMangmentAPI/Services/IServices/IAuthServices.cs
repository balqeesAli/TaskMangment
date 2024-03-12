using TaskMangmentAPI.Infrastructure.DTOs;

namespace TaskMangmentAPI.Services.IServices
{
    public interface IAuthServices
    {
        Task<ResponseModel<object>> Register(RegistrationDto model);
        Task<ResponseModel<object>> Login(loginDto model);
    }
}
