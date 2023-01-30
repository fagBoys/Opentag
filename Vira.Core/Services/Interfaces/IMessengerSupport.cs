using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.Core.Services.Interfaces
{
    public interface IMessengerSupport
    {

        #region Admin

         int SendMessageAdmin(DataLayer.Entities.Support.MessengerSupport messengerSupport);
         List<DataLayer.Entities.Support.MessengerSupport> ListMessageAdmin();
         List<DataLayer.Entities.Support.MessengerSupport> ListMessageForAdminByUser(int userId, Guid browserId);

        #endregion

        #region User

         int SendMessageUser(DataLayer.Entities.Support.MessengerSupport messengerSupport);
         List<DataLayer.Entities.Support.MessengerSupport> ListMessageUser(Guid browserId, int? userId);

         #endregion

    }
}
