using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shopnet.ViewModels
{
    public class ViewUser : ViewStatus
    {
        public User User { get; set; }

        public ViewUser() 
        {
            this.User = new User();
        }

        public ViewUser(User user)
        {
            this.User = user;
            this.Status = user.Status;
        }

    }
}