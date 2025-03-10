using SQLite;

namespace MobileApp_AcademicTerms.Models
{
    /// <summary>
    /// Base model class implementing common functionality
    /// Demonstrates inheritance and polymorphism patterns
    /// 
    /// Inheritance:
    /// - Base class for all academic models
    /// - Shared ID and validation functionality
    /// - Common date range validation
    /// 
    /// Polymorphism:
    /// - Virtual methods for validation
    /// - Abstract properties that must be implemented
    /// - Interface implementation for notifications
    /// </summary>
    public abstract class AcademicModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public abstract string Title { get; set; }
        public bool NotificationsEnabled { get; set; }

        /// <summary>
        /// Virtual method for model-specific validation
        /// Can be overridden by derived classes
        /// </summary>
        public virtual bool Validate()
        {
            if (EndDate <= StartDate)
                return false;
            return true;
        }

        /// <summary>
        /// Abstract method that must be implemented by derived classes
        /// Demonstrates polymorphic behavior
        /// </summary>
        public abstract string GetDisplayInfo();
    }
}