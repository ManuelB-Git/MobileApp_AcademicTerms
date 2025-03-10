using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MobileApp_AcademicTerms.Models
{
    [Table("Courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Course title is required")]
        public string Title { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        
        [Required(ErrorMessage = "Instructor name is required")]
        public string InstructorName { get; set; }
        
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string InstructorPhone { get; set; }
        
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string InstructorEmail { get; set; }
        
        public string Notes { get; set; }
        
        [Indexed]
        public int TermId { get; set; }
        
        public bool NotificationsEnabled { get; set; }
    }
}