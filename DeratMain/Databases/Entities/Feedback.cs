using DeratMain.Models.Feedback;

namespace DeratMain.Databases.Entities
{
    public class Feedback : BaseEntity
    {
        public Feedback(FeedbackCreateModel feedbackCreateModel) : base()
        {
            UserName = feedbackCreateModel.UserName;
            Description = feedbackCreateModel.Description;
            Rating = feedbackCreateModel.Rating;
            UserId = feedbackCreateModel.UserId;
        }

        public Feedback() : base()
        {
        }

        public string UserName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
