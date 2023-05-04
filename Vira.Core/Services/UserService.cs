using Berlance.Core.Generator;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.Convertors;
using Vira.Core.DTOs;
using Vira.Core.Security;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.User;

namespace Vira.Core.Services
{
    public class UserService :IUserService
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

        public bool ActiveAccountCode(string PhoneNumber, string activeCode)
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

        public User GetUserByActiveCode(string activeCode, string PhoneNumber)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode && u.PhoneNumber == PhoneNumber);
            if (user == null || !user.IsActive)
                return user;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.RandomString(4);
            _context.SaveChanges();

            return user;
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

        //public void AddVisiteCount(string ip)
        //{
        //    var visite = _context.VisiteCounts.Any(v => v.Ip == ip && v.DateVisite.Date == DateTime.Now.Date);
        //    if (!visite)
        //    {
        //        VisiteCount visiteCount = new VisiteCount()
        //        {
        //            Ip = ip,
        //        };
        //        _context.VisiteCounts.Add(visiteCount);
        //        _context.SaveChanges();
        //    }

        //}

        //public void AddContactUs(ContactUs contactUs)
        //{
        //    _context.ContactUs.Add(contactUs);
        //    _context.SaveChanges();
        //}
    }
}
