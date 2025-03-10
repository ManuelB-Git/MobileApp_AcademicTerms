using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MobileApp_AcademicTerms.Models
{
    [Table("Assessments")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Assessment title is required")]
        public string Title { get; set; }
        
        // Type can be "Objective" or "Performance"
        [Required(ErrorMessage = "Assessment type is required")]
        public string Type { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Indexed]
        public int CourseId { get; set; }
        
        public bool NotificationsEnabled { get; set; }
    }
}