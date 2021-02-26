using System;
using System.Security.Cryptography;
using System.Threading;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.BL.Services
{
    public class AuthService:IAuthService
    {
        private IUserRepository<UserEntity> _userRepository;

        public AuthService(IUserRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity AuthenticateUser(string username, string password)
        {
            string storedPassword = _userRepository.GetPasswordByUserName(username);

            if (storedPassword == null)
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }

            if (!PasswordMatchesToUser(password, storedPassword))
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }

            UserEntity user = _userRepository.GetByUserName(username);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Failed to authenticate user.");
            }
            return user;
        }

        private bool PasswordMatchesToUser(string pass, string storedPass)
        {
            return pass == storedPass;
        }

        public UserEntity CreateUser(UserEntity user)
        {
            if (_userRepository.Exists(user.Username))
            {
                throw new Exception("User already exists.");
            }
            return _userRepository.Add(user);
        }
    }
}