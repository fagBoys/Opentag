﻿using System.ComponentModel.DataAnnotations;
using Vira.Web.Shared.Entities.User;

namespace Vira.DataLayer.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {
            
        }

        [Key]
        public int UR_Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }


        #region Relations

        public virtual Web.Shared.Entities.User.User User { get; set; }
        public virtual Role Role { get; set; }

        #endregion

    }
}
