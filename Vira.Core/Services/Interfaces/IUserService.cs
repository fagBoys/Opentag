using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs;
using Vira.DataLayer.Entities.User;

namespace Vira.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        bool ActiveAccount(string activeCode);
        bool ActiveAccountCode(string email, string activeCode);
        bool CheckingCode(string email, string activeCode);
        void DeleteUser(int UserId);
        User GetUserByEmail(string email);
        void SaveAvatar(string userName, string AvatarName, string FileName, IFormFile UserAvatar);
        User GetUserById(int userId);
        User GetUserByActiveCode(string activeCode, string PhoneNumber);
        User GetUserByUserName(string username);
        void UpdateUser(User user);
        int GetUserIdByUserName(string username);
        //void AddVisiteCount(string ip);
        //void AddContactUs(ContactUs contactUs);
    }
}
