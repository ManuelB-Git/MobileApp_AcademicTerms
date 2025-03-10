using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MobileApp_AcademicTerms.Models
{
    /// <summary>
    /// Term model demonstrating inheritance and polymorphism
    /// Inherits from AcademicModel base class
    /// 
    /// Inheritance Features:
    /// - Inherits common fields (Id, StartDate, EndDate, NotificationsEnabled)
    /// - Implements required abstract members
    /// - Overrides validation with term-specific rules
    /// </summary>
    [Table("Term")]
    public class Term : AcademicModel
    {
        private string _title;
        
        // Implementation of abstract property from base class
        public override string Title 
        { 
            get => _title;
            set
            {
                // Term-specific validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Term title cannot be empty");
                _title = value.Trim();
            }
        }

        // Term-specific properties
        public string Status { get; set; }
        
        /// <summary>
        /// Override of base validation with additional term-specific rules
        /// </summary>
        public override bool Validate()
        {
            // Call base validation first
            if (!base.Validate())
                return false;

            // Add term-specific validation
            if (EndDate.Subtract(StartDate).TotalDays > 180)
                return false;  // Terms cannot be longer than 6 months

            return true;
        }

        /// <summary>
        /// Implementation of abstract method from base class
        /// </summary>
        public override string GetDisplayInfo()
        {
            return $"{Title} ({StartDate:MMM yyyy} - {EndDate:MMM yyyy})";
        }
    }
}