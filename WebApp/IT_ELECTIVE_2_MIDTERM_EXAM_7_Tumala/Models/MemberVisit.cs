using System.ComponentModel.DataAnnotations;

namespace GymAttendanceSystem.Models
{
    public class MemberVisit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Visit Number is required.")]
        [Display(Name = "Visit Number")]
        public string VisitNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Member ID is required.")]
        [Display(Name = "Member ID")]
        public string MemberId { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Membership Type is required.")]
        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; } = DateTime.Now;

        [DataType(DataType.Time)]
        [Display(Name = "Time Out")]
        public DateTime? TimeOut { get; set; }

        public string Status { get; set; } = "Inside Gym"; // "Inside Gym" or "Checked Out"

        [Display(Name = "Workout Purpose")]
        public string? WorkoutPurpose { get; set; }

        public string? Notes { get; set; }
    }
}