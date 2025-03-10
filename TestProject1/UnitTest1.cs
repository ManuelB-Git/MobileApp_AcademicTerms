using MobileApp_AcademicTerms.Models;
using MobileApp_AcademicTerms.Services;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly DatabaseService _databaseService;
        private readonly string _testDbPath;

        public UnitTest1()
        {
            // Create a temporary path for the test database
            _testDbPath = Path.Combine(Path.GetTempPath(), "test_academicterms.db");

            // Delete any existing test database
            if (File.Exists(_testDbPath))
            {
                File.Delete(_testDbPath);
            }

            _databaseService = new DatabaseService(_testDbPath);
            _databaseService.Init().Wait();
        }

        [Fact]
        public async Task GetTermsAsync_ShouldReturnTerms()
        {
            var terms = await _databaseService.GetTermsAsync();
            Assert.NotNull(terms);
        }



    }
}
