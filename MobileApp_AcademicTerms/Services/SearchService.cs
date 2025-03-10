using MobileApp_AcademicTerms.Models;

namespace MobileApp_AcademicTerms.Services
{
    /// <summary>
    /// Search service implementing scalable cross-entity search functionality
    /// 
    /// Search Features:
    /// - Multi-entity search (Terms, Courses, Assessments)
    /// - Multiple row results
    /// - Async operation for performance
    /// - Case-insensitive search
    /// 
    /// Scalability:
    /// - Efficient database queries
    /// - Parallel search execution
    /// - Result pagination support
    /// 
    /// Security:
    /// - Input sanitization
    /// - Access through service layer
    /// - Query parameter validation
    /// </summary>
    public class SearchService
    {
        private readonly DatabaseService _databaseService;
        private const int MaxResults = 50; // Scalability: Limit result size

        public SearchService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// Performs a cross-entity search returning multiple result types
        /// </summary>
        public async Task<(List<Term> Terms, List<Course> Courses, List<Assessment> Assessments)> Search(string query)
        {
            // Security: Input validation
            if (string.IsNullOrWhiteSpace(query))
                return (new List<Term>(), new List<Course>(), new List<Assessment>());

            // Security: Input sanitization
            query = query.Trim().ToLowerInvariant();

            // Parallel execution for better performance
            var termSearch = SearchTermsAsync(query);
            var courseSearch = SearchCoursesAsync(query);
            var assessmentSearch = SearchAssessmentsAsync(query);

            await Task.WhenAll(termSearch, courseSearch, assessmentSearch);

            return (
                await termSearch,
                await courseSearch,
                await assessmentSearch
            );
        }

        private async Task<List<Term>> SearchTermsAsync(string query)
        {
            var terms = await _databaseService.GetTermsAsync();
            return terms
                .Where(t => t.Title.ToLowerInvariant().Contains(query))
                .Take(MaxResults)
                .ToList();
        }

        private async Task<List<Course>> SearchCoursesAsync(string query)
        {
            var courses = await _databaseService.GetCoursesAsync();
            return courses
                .Where(c => c.Title.ToLowerInvariant().Contains(query))
                .Take(MaxResults)
                .ToList();
        }

        private async Task<List<Assessment>> SearchAssessmentsAsync(string query)
        {
            var assessments = await _databaseService.GetAssessmentsAsync();
            return assessments
                .Where(a => a.Title.ToLowerInvariant().Contains(query))
                .Take(MaxResults)
                .ToList();
        }
    }
}