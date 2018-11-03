﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Models
{
    public class UserFriend
    {
        public UserFriend()
        {

        }

        public int UserId { get; set; }
        public User User { get; set; }

        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}
