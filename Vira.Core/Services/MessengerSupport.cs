using Vira.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vira.DataLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vira.Core.DTOs.Cart;

namespace Vira.Core.Services
{
    public class MessengerSupport : IMessengerSupport
    {
        private ViraContext _context;
        private IUserService _userService;

        public MessengerSupport(ViraContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        #region Admin

        public int SendMessageAdmin(DataLayer.Entities.Support.MessengerSupport messengerSupport)
        {
            messengerSupport.IdAdmin = 1;
            messengerSupport.SendMessageDate = DateTime.Now;
            messengerSupport.State = "receive";
            messengerSupport.IsReplay = true;
            _context.MessengerSupports.Add(messengerSupport);
            _context.SaveChanges();
            return messengerSupport.Id;
        }

        public List<DataLayer.Entities.Support.MessengerSupport> ListMessageAdmin()
        {
            return _context.MessengerSupports.ToList();
        }

        public List<DataLayer.Entities.Support.MessengerSupport> ListMessageForAdminByUser(int userId, Guid browserId)
        {
            return _context.MessengerSupports.Where(m => m.UserId == userId || m.BrowserId == browserId).ToList();
        }

        #endregion

        #region User
        public int SendMessageUser(DataLayer.Entities.Support.MessengerSupport messengerSupport)
        {
            string? userName = null;
            var messengerSupports = _context.MessengerSupports.FirstOrDefault(p => p.BrowserId == messengerSupport.BrowserId);
           
            if (messengerSupports != null)
            {
                if (messengerSupports.UserId != null)
                {
                    int userId = (int)messengerSupports.UserId;
                    userName = _userService.GetUserById(userId).UserName;
                }
            }

            if (userName != null)
            {
                messengerSupport.IdAdmin = 1;
                messengerSupport.SendMessageDate = DateTime.Now;
                messengerSupport.State = "Sander";
                messengerSupport.IsReplay = false;
                _context.MessengerSupports.Add(messengerSupport);
                _context.SaveChanges();
            }
            else
            {
                messengerSupport.IdAdmin = 1;
                messengerSupport.SendMessageDate = DateTime.Now;
                messengerSupport.State = "Sander";
                messengerSupport.IsReplay = false;
                _context.MessengerSupports.Add(messengerSupport);
                _context.SaveChanges();

            }
            return messengerSupport.Id;
        }

        public List<DataLayer.Entities.Support.MessengerSupport> ListMessageUser(Guid browserId, int? userId)
        {
            //List<DataLayer.Entities.Support.MessengerSupport> chat = new List<DataLayer.Entities.Support.MessengerSupport>();
            IQueryable<DataLayer.Entities.Support.MessengerSupport> result = _context.MessengerSupports;
            //if (userId != null && userId != 0)
            //{
            //     chat = _context.MessengerSupports.Where(m => m.UserId == userId).ToList();
            //}
            //else
            //{
            //     chat = _context.MessengerSupports.Where(m => m.Ip == ip).ToList();
            //}

            var userid = userId.ToString();
            var browserID = browserId.ToString();
            if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(browserID))
            {
                result = result.Where(p => p.UserId.ToString().Contains(userid) || p.BrowserId.ToString().Contains(browserID));

            }
            else if (!string.IsNullOrEmpty(browserID))
            {
                result = result.Where(p => p.BrowserId.ToString().Contains(browserID));
            }
            else
            {
                result = result.Where(p => p.UserId.ToString().Contains(userid));

            }


            return result.ToList();
        }


        #endregion
    }
}
