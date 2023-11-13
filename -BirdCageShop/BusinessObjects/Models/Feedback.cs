using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public int? RatingId { get; set; }
        public string? FeedBackName { get; set; }
        public string? FeedBackContent { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public double? Rating { get; set; }

        public virtual Order? Order { get; set; }
        public virtual User? User { get; set; }
    }
}
