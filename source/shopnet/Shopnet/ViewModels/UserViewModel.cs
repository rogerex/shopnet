using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shopnet.ViewModels
{
    public class UserViewModel : StatusViewModel
    {
        public User User { get; set; }

        public UserViewModel() 
        {
            this.User = new User();
        }

        public UserViewModel(User user)
        {
            this.User = user;
            this.Status = user.Status;
        }

    }
}