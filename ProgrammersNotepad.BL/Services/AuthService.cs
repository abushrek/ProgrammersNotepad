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

            if (!PasswordMatchesToUser(password, storedPassword))
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

        private bool PasswordMatchesToUser(string pass, string storedPass)
        {
            return pass == storedPass;
        }

        public UserDetailModel CreateUser(UserDetailModel user)
        {
            if (_facade.Exists(user.Username))
            {
                throw new UserExistsException("User already exists.");
            }
            return _detailFacade.Add(user);
        }
    }
}