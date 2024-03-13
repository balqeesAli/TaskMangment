using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentAPI.Infrastructure.Repo.IRepo;
using TaskMangmentAPI.Services.IServices;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IDbRepo _dbRepo;  

        public AuthServices(IDbRepo dbRepo)
        {
            this._dbRepo = dbRepo;
        } 

        public async Task<ResponseModel<object>> Register(RegistrationDto model)
        {
             var account = await  _dbRepo.AccountRepo.GetAccountByIdAsync(model.Email);

            if (account != null)
            {
                return ResponseModel<object>.Fail(403, "This email is used by another account");
            }

            var newAccount = new Account()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Name = model.name,
                HashPassword = Hash(model.HashPassword)
            };

            try
            {
                if (!await _dbRepo.AccountRepo.Post(newAccount))
                {
                    return ResponseModel<object>.Fail(500, "Error while adding to Db");
                }

                if (!await _dbRepo.SaveDbAsync())
                {
                    return ResponseModel<object>.Fail(500, "Db Error");
                }

                return ResponseModel<object>.Success(default);
            }
            catch (Exception)
            {
                return ResponseModel<object>.Fail(500, "DB Error");
            }
        }

        public async Task<ResponseModel<Account>> Login(loginDto model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return ResponseModel<Account>.Fail(400, "The Request body is not defined");
            }

            var account = await _dbRepo.AccountRepo.GetAccountByEmailAsync(model.Email);

            if (account == null)
            {
                return ResponseModel<Account>.Fail(404, "Invalid username or password");
            } 
             
            if (Hash(model.HashPassword) != account.HashPassword)
            {
                return ResponseModel<Account>.Fail(403, "Invalid username or password");
            } 
            return ResponseModel<Account>.Success(account);
        }


        public static string Hash(string pass)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
    }
}
