using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.AspNetCore.Http;
using Berlance.Core.DTOs;
using Berlance.DataLayer.Entities.User;
//using Berlance.DataLayer.Entities.Wallet;

namespace Berlance.Core.Services.Interfaces
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
        void AddVisiteCount(string ip);
        void AddContactUs(ContactUs contactUs);

        #region User Panel

        InformationUserViewModel GetUserInformation(string username);
        InformationUserViewModel GetUserInformation(int userid);
        //SideBarUserPanelViewModel GetSideBarUserPanelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
        bool CompareOldPassword(string OldPassword, string username);
        void ChengeUserPassword(string username, string newpassword);

        int AddCartBanke(string username, string CartNumber , string AccountOwner);
        #endregion

        #region Wallet

        //int BalanceUserWallet(string username);
        //List<WalletViewModel> GetWalletUser(string username);
        //int ChargWallet(string usernam, int amount, string description, bool ispay = false);
        //int AddWallet(Wallet wallet);
        //Wallet GetWalletByWalletId(int walletId);
        //void UpdateWallet(Wallet wallet);

        #endregion

        #region Admin Panel

        UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        int AddUserFormAdmin(CreatUserViewModel user);
        EditeUserViewModel GetUserForShowInEditeModel(int userId);
        void EditeUserFormAdmin(EditeUserViewModel editeUser);

        int GetToDayVisite();
        int GetAllVisite();
        int GetCountAllUser();
        List<ContactUs> GetContactUsList();
        ContactUs GetDetailContactUs(int countactId);

        #endregion
    }
}