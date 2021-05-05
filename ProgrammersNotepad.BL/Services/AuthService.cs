using System;
using System.Security.Cryptography;
using System.Threading;
using ProgrammersNotepad.BL.Exceptions;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.BL.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserFacade<UserDetailModel> _facade;
        private readonly IDetailFacade<UserDetailModel> _detailFacade;

        private const int DefaultSaltLength = 128;
        private const int DefaultHashLength = 512;
        private const int DefaultNumberOfPBKDFIterations = 10000;

        public AuthService(IUserFacade<UserDetailModel> facade, IDetailFacade<UserDetailModel> detailFacade)
        {
            _facade = facade;
            _detailFacade = detailFacade;
        }

        public UserDetailModel AuthenticateUser(string username, string password)
        {
            string storedPassword = _facade.GetPasswordByUserName(username);

            if (storedPassword == null)
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }

            if (!PasswordMatchesHashedPassword(password, storedPassword))
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }

            UserDetailModel user = _facade.GetByUserName(username);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }
            return user;
        }

        private string GetHashedPassword(string password)
        {
            var salt = new byte[DefaultSaltLength];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf = new Rfc2898DeriveBytes(password, salt, DefaultNumberOfPBKDFIterations);
            var hash = pbkdf.GetBytes(DefaultHashLength);
            var hashWithSalt = new byte[DefaultSaltLength + DefaultHashLength];
            Array.Copy(salt, 0, hashWithSalt, 0, DefaultSaltLength);
            Array.Copy(hash, 0, hashWithSalt, DefaultSaltLength, DefaultHashLength);
            var hashWithSaltString = Convert.ToBase64String(hashWithSalt);
            return hashWithSaltString;
        }

        private bool PasswordMatchesHashedPassword(string password, string hashedPassword)
        {
            var hash = Convert.FromBase64String(hashedPassword);
            var salt = new byte[DefaultSaltLength];
            Array.Copy(hash, 0, salt, 0, DefaultSaltLength);
            var pkbdf = new Rfc2898DeriveBytes(password, salt, DefaultNumberOfPBKDFIterations);
            var providedPasswordHash = pkbdf.GetBytes(DefaultHashLength);
            for (int i = 0; i < DefaultHashLength; i++)
            {
                if (hash[i + DefaultSaltLength] != providedPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public UserDetailModel CreateUser(UserDetailModel user)
        {
            if (_facade.Exists(user.Username))
            {
                throw new UserExistsException("User already exists.");
            }
            user.Password = GetHashedPassword(user.Password);
            return _detailFacade.Add(user);
        }
    }
}