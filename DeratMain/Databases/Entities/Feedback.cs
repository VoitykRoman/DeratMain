﻿using DeratMain.Models.Feedback;

namespace DeratMain.Databases.Entities
{
    public class Feedback : BaseEntity
    {
        public Feedback(FeedbackCreateModel feedbackCreateModel) : base()
        {
            AvatarUrl = feedbackCreateModel.avatarUrl;
            UserName = feedbackCreateModel.UserName;
            Description = feedbackCreateModel.Description;
            Rating = feedbackCreateModel.Rating;
        }

        public Feedback() : base()
        {
        }

        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}