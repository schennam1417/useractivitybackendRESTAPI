using CommonLayer;
using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AuthenticationRL : IAuthenticationRL
    {
        private readonly IConfiguration _configuration;
        public readonly ApplicationDbContext _dbContext;
        public AuthenticationRL(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "LogIn Successfully.";

            try
            {
                var IsUserExist = await _dbContext
                    .UserDetails
                    .FirstOrDefaultAsync(x => (x.EmailID.ToLower().Equals(request.EmailId.ToLower()) || (x.Username.ToLower().Equals(request.EmailId)))
                    && x.Password == request.Password);
                if (IsUserExist == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User Not Exist exist.";
                    return response;
                }
                response.data = IsUserExist;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully.";

            try
            {
                var IsUserExist = await _dbContext.UserDetails
                    .FirstOrDefaultAsync(x => (x.Username.ToLower().Equals(request.Username.ToLower())));


                if (IsUserExist != null)
                {
                    response.IsSuccess = false;
                    response.Message = "UserName already exist.";
                    return response;
                }

                 IsUserExist = await _dbContext.UserDetails
                    .FirstOrDefaultAsync(x => ( x.EmailID.ToLower().Equals(request.EmailId.ToLower())));


                if (IsUserExist != null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email Address already exist.";
                    return response;
                }

                UserDetails userDetails = new UserDetails();
                userDetails.Username = request.Username;
                userDetails.Password = request.Password;
                userDetails.EmailID = request.EmailId;
                await _dbContext.UserDetails.AddAsync(userDetails);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }


        private string? TaskRespect(string? Id)
        {
            string response = string.Empty;
            try
            {
                string EncryptionKey = "abc123";
                byte[] clearBytes = Encoding.Unicode.GetBytes(Id);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        response = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
