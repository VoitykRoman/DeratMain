﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.Feedback
{
    public class FeedbackUpdateModel
    {
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
