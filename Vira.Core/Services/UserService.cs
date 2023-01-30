using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Vira.Core.Convertors;
using Vira.Core.DTOs;
using Vira.Core.Generator;
using Vira.Core.Security;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.User;
//using Vira.DataLayer.Entities.Wallet;

namespace Vira.Core.Services
{
    public class UserService : IUserService
    {
        private ViraContext _context;

        public UserService(ViraContext context)
        {
            _context = context;
        }


        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            user.BirthDate = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            //string email = FixedText.FixEmail(login.PhoneNeumber);
            return _context.Users.SingleOrDefault(u => u.UserName == login.PhoneNumber && u.Password == hashPassword);
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.RandomString(4);
            _context.SaveChanges();
            return true;
        }

        public bool ActiveAccountCode(string PhoneNumber,  string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode && u.UserName == PhoneNumber);
            if (user == null)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.RandomString(4);
            _context.SaveChanges();

            return true;
        }

        public bool CheckingCode(string userName, string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode && u.UserName == userName);
            if (user == null || !user.IsActive)
                return false;


            return true;
        }


        public void DeleteUser(int UserId)
        {
            User user = GetUserById(UserId);
            user.IsDelete = true;
            user.IsActive = false;
            UpdateUser(user);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public void SaveAvatar(string userName, string AvatarName, string FileName, IFormFile UserAvatar)
        {
            User user = GetUserByUserName(userName);
            //Delete old Image
            if (AvatarName != "Defult.jpg")
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", AvatarName);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }
            }

            //Save New Image
            user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                UserAvatar.CopyTo(stream);
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByActiveCode(string activeCode , string PhoneNumber)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode && u.PhoneNumber == PhoneNumber);
            if (user == null || !user.IsActive)
                return user;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.RandomString(4);
            _context.SaveChanges();

            return user ;
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public int GetUserIdByUserName(string username)
        {
            return _context.Users.Single(A => A.UserName == username).UserId;
        }

        public void AddVisiteCount(string ip)
        {
            var visite = _context.VisiteCounts.Any(v => v.Ip == ip && v.DateVisite.Date == DateTime.Now.Date);
            if (!visite)
            {
                VisiteCount visiteCount = new VisiteCount()
                {
                    Ip = ip,
                };
                _context.VisiteCounts.Add(visiteCount);
                _context.SaveChanges();
            }

        }

        public void AddContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
        }

        #region UserPanel

        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUserName(username);
            InformationUserViewModel information = new InformationUserViewModel();
            information.Firstname = user.Firstname;
            information.LastName = user.LastName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.IdCode = user.IdCode;
            information.PhoneNumber = user.PhoneNumber;
            information.State = user.State;
            information.BirthDate = user.BirthDate;

            return information;

        }

        public InformationUserViewModel GetUserInformation(int userid)
        {
            var user = GetUserById(userid);
            InformationUserViewModel information = new InformationUserViewModel();
            //information.UserName = user.UserName;
            information.Firstname = user.Firstname;
            information.LastName = user.LastName;
            information.Email = user.Email;

            information.RegisterDate = user.RegisterDate;

            return information;
        }

        //public SideBarUserPanelViewModel GetSideBarUserPanelData(string username)
        //{
        //    return _context.Users.Where(u => u.UserName == username).Select(u => new SideBarUserPanelViewModel()
        //    {
        //        UserName = u.UserName,
        //        ImageName = u.UserAvatar,
        //        RegisterDate = u.RegisterDate
        //    }).Single();
        //}

        public EditProfileViewModel GetDataForEditProfileUser(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel()
            {
                Firstname = u.Firstname,
                LastName = u.LastName,
                Email = u.Email,
                State = u.State,
                Address = u.Address,
                BirthDate = u.BirthDate,
                IdCode = u.IdCode,
                PhoneNumber = u.PhoneNumber,
                City = u.City,
                PostCode = u.PostCode,
                Sex = u.Sex

            }).Single();
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {

            var user = GetUserByUserName(username);
            user.Firstname = profile.Firstname;
            user.LastName  = profile.LastName;
            user.UserName = profile.PhoneNumber;
            user.Email = profile.Email;
            user.BirthDate = profile.BirthDate;
            user.Address = profile.Address;
            user.City = profile.City;
            user.State = profile.State;
            user.IdCode = profile.IdCode;
            user.PhoneNumber = profile.PhoneNumber;
            user.PostCode = profile.PostCode;
            user.Sex = profile.Sex;


            UpdateUser(user);

        }

        public bool CompareOldPassword(string OldPassword, string username)
        {
            string hashOldPassword = PasswordHelper.EncodePasswordMd5(OldPassword);
            return _context.Users.Any(A => A.UserName == username && A.Password == hashOldPassword);
        }

        public void ChengeUserPassword(string username, string newpassword)
        {
            var user = GetUserByUserName(username);
            user.Password = PasswordHelper.EncodePasswordMd5(newpassword);
            UpdateUser(user);
        }

        public int AddCartBanke(string username, string CartNumber, string AccountOwner)
        {
            var user = GetUserByUserName(username);
            user.CartNumber = CartNumber;
            user.Accountowner = AccountOwner;
            UpdateUser(user);
            return user.UserId;
        }

        #endregion

        #region Wallet

        //public int BalanceUserWallet(string username)
        //{
        //    int UserId = GetUserIdByUserName(username);

        //    var Enter = _context.Wallets
        //     .Where(W => W.UserId == UserId && W.TypeId == 1 && W.IsPay)
        //     .Select(W => W.Amount).ToList();

        //    var Exite = _context.Wallets
        //        .Where(W => W.UserId == UserId && W.TypeId == 2)
        //        .Select(W => W.Amount).ToList();

        //    return (Enter.Sum() - Exite.Sum());
        //}

        //public List<WalletViewModel> GetWalletUser(string username)
        //{
        //    int UserId = GetUserIdByUserName(username);
        //    return _context.Wallets
        //        .Where(W => W.IsPay && W.UserId == UserId)
        //        .Select(W => new WalletViewModel()
        //        {
        //            Amount = W.Amount,
        //            DateTime = W.CreateDate,
        //            Description = W.Description,
        //            Type = W.TypeId

        //        })
        //        .ToList();
        //}

        //public int ChargWallet(string usernam, int amount, string description, bool ispay = false)
        //{
        //    Wallet wallet = new Wallet()
        //    {
        //        Amount = amount,
        //        CreateDate = DateTime.Now,
        //        Description = description,
        //        IsPay = ispay,
        //        TypeId = 1,
        //        UserId = GetUserIdByUserName(usernam)
        //    };
        //    return AddWallet(wallet);
        //}

        //public int AddWallet(Wallet wallet)
        //{
        //    _context.Wallets.Add(wallet);
        //    _context.SaveChanges();
        //    return wallet.WalletId;
        //}

        //public Wallet GetWalletByWalletId(int walletId)
        //{
        //    return _context.Wallets.Find(walletId);
        //}

        //public void UpdateWallet(Wallet wallet)
        //{
        //    _context.Wallets.Update(wallet);
        //    _context.SaveChanges();
        //}


        #endregion

        #region Admin

        public UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(A => A.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(A => A.UserName.Contains(filterUserName));
            }

            //Show Item In page
            int take = 20;
            int skip = (pageId - 1) * take;


            UserForAdminViewModel List = new UserForAdminViewModel();
            List.CurrentPage = pageId;
            List.PageCount = result.Count() / take;
            List.Users = result.OrderBy(A => A.RegisterDate).Skip(skip).Take(take).ToList();

            return List;

        }

        public UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(U => U.IsDelete);

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(A => A.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(A => A.UserName.Contains(filterUserName));
            }

            //Show Item In page
            int take = 20;
            int skip = (pageId - 1) * take;


            UserForAdminViewModel List = new UserForAdminViewModel();
            List.CurrentPage = pageId;
            List.PageCount = result.Count() / take;
            List.Users = result.OrderBy(A => A.RegisterDate).Skip(skip).Take(take).ToList();

            return List;

        }

        public int AddUserFormAdmin(CreatUserViewModel user)
        {
            User addUser = new User();
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GenerateUniqCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;
            addUser.UserAvatar = "Defult.jpg";
            #region Save Avatar

            //if (user.UserAvatar == null)
            //{
            //    string imagePath = "";


            //    addUser.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
            //    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.UserAvatar);
            //    using (var stream = new FileStream(imagePath, FileMode.Create))
            //    {
            //        user.UserAvatar.CopyTo(stream);
            //    }
            //}


            #endregion

            return AddUser(addUser);

        }

        public EditeUserViewModel GetUserForShowInEditeModel(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId)
                .Select(u => new EditeUserViewModel()
                {
                    UserId = u.UserId,
                    AvatarName = u.UserAvatar,
                    Email = u.Email,
                    UserName = u.UserName,
                    UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
                }).Single();
        }

        public void EditeUserFormAdmin(EditeUserViewModel editeUser)
        {
            User user = GetUserById(editeUser.UserId);
            user.Email = editeUser.Email;
            user.UserName = editeUser.UserName;
            if (!string.IsNullOrEmpty(editeUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editeUser.Password);
            }

            if (editeUser.UserAvatar != null)
            {

                SaveAvatar(user.UserName, editeUser.AvatarName, editeUser.UserAvatar.FileName, editeUser.UserAvatar);
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public int GetToDayVisite()
        {
            return _context.VisiteCounts.Count(v => v.DateVisite.Date == DateTime.Now.Date);
        }

        public int GetAllVisite()
        {
            return _context.VisiteCounts.Count();
        }

        public int GetCountAllUser()
        {
            return _context.Users.Count() - 1;
        }

        public List<ContactUs> GetContactUsList()
        {
            return _context.ContactUs.OrderByDescending(c => c.RegisterDate).ToList();
        }

        public ContactUs GetDetailContactUs(int countactId)
        {
            return _context.ContactUs.FirstOrDefault(c => c.CountactId == countactId);
        }
        #endregion
    }
}
