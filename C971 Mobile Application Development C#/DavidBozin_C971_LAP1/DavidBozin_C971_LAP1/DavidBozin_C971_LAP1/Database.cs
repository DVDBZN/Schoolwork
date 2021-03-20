using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DavidBozin_C971_LAP1
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Term>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<Assessment>().Wait();
        }

        //Each table has get, set, and delete functions
        public Task<List<Term>> GetTermsAsync()
        {
            return _database.QueryAsync<Term>("SELECT * FROM Term");
        }

        public Task<int> SaveTermAsync(Term term)
        {
            if (term.ID != 0)
                return _database.UpdateAsync(term);
            else
                return _database.InsertAsync(term);
        }

        public Task<int> DeleteTermAsync(Term term)
        {
            ClearCourses(term.ID);
            return _database.DeleteAsync(term);
        }

        //Term and Course tables also have a function that clears associated courses and assessments, respectively
        public async void ClearCourses(int termId)
        {
            var courses = await GetCoursesAsync(termId);
            foreach (Course course in courses)
            {
                await DeleteCourseAsync(course);
            }
        }

        public Task<List<Course>> GetCoursesAsync(int termId)
        {
            return _database.QueryAsync<Course>("SELECT * FROM Course WHERE TermID = ?", termId.ToString());
        }

        public Task<int> SaveCourseAsync(Course course)
        {
            if (course.ID != 0)
                return _database.UpdateAsync(course);
            else
                return _database.InsertAsync(course);
        }

        public Task<int> DeleteCourseAsync(Course course)
        {
            ClearAssessments(course.ID);
            return _database.DeleteAsync(course);
        }

        public async void ClearAssessments(int courseId)
        {
            var assessments = await GetAssessmentsAsync(courseId);
            foreach (Assessment assessment in assessments)
            {
                await DeleteAssessmentAsync(assessment);
            }
        }

        public Task<List<Assessment>> GetAssessmentsAsync(int courseId)
        {
            return _database.QueryAsync<Assessment>("SELECT * FROM Assessment WHERE CourseID = " + courseId.ToString());
        }

        public Task<int> SaveAssessmentAsync(Assessment assessment)
        {
            if (assessment.ID != 0)
                return _database.UpdateAsync(assessment);
            else
                return _database.InsertAsync(assessment);
        }

        public Task<int> DeleteAssessmentAsync(Assessment assessment)
        {
            return _database.DeleteAsync(assessment);
        }

        //Functions that get all notifications from each table
        public Task<List<Term>> TermNotifications()
        {
            return _database.QueryAsync<Term>("SELECT * FROM Term WHERE Notify = true");
        }

        public Task<List<Course>> CourseNotifications()
        {
            return _database.QueryAsync<Course>("SELECT * FROM Course WHERE Notify = true");
        }

        public Task<List<Assessment>> AssessmentNotifications()
        {
            return _database.QueryAsync<Assessment>("SELECT * FROM Assessment WHERE Notify = true");
        }
    }
}