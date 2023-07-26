using Berlance.Core.Generator;
using Microsoft.AspNetCore.Http;
using Vira.Core.DTOs;
using Vira.Core.DTOs.Main;
using Vira.Core.Security;
using Vira.Core.Services.Interfaces;
using Vira.Web.Shared.Context;
using Vira.Web.Shared.Entities.Main;
using Vira.Web.Shared.Entities.User;

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
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            //string email = FixedText.FixEmail(login.PhoneNeumber);
            return _context.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == hashPassword);
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

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
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

        public void AddVisitHomePage(string ip)
        {
            var visite = _context.VisitHomePages.Any(v => v.Ip == ip && v.VisitDate.Date == DateTime.Now.Date);
            if (!visite)
            {
                VisitHomePage visiteCount = new VisitHomePage
                {
                    Ip = ip,
                    VisitDate = DateTime.Now.Date,
                };

                _context.VisitHomePages.Add(visiteCount);
                _context.SaveChanges();
            }

        }

        public void AddContactUs(AddContact contactUs)
        {
            Contact contact = new Contact();
            contact.Fullname = contactUs.Fullname;
            contact.Email = contactUs.Email;
            contact.Phone = contactUs.Phone;
            contact.Subject = contactUs.Subject;
            contact.Text = contactUs.Text;
            contact.ContactDate = DateTime.Now;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public List<Contact> ListContactUs()
        {
            return _context.Contacts.ToList();
        }
    }
}
