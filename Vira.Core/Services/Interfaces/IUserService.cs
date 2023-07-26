using Microsoft.AspNetCore.Http;
using Vira.Core.DTOs;
using Vira.Core.DTOs.Main;
using Vira.Web.Shared.Entities.Main;
using Vira.Web.Shared.Entities.User;

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
        public User GetUserByActiveCode(string activeCode);
        User GetUserByUserName(string username);
        void UpdateUser(User user);
        int GetUserIdByUserName(string username); 
        void AddVisitHomePage(string ip);

        void AddContactUs(AddContact contactUs);

        List<Contact> ListContactUs();

    }
}
