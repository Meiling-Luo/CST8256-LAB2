using AcademicManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string? SelectedStudentName { get; set; }

        public List<Course>? AllCourses { get; set; }

        [BindProperty]
        public List<string> SelectedCourseCode { get; set; } = new List<string>();


        [BindProperty]

        public Course? SelectedCourse { get; set; }

        [BindProperty]

        public bool ShowEmptyRegistrationError { get; set; } = false;
        public bool ShowRegistrationInfo { get; set; } = false;




        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(SelectedStudentName))
            {
                ShowEmptyRegistrationError = false;
                ShowRegistrationInfo = true;
            }
            else
            {
                ShowEmptyRegistrationError = true;
                ShowRegistrationInfo = false;


            }

            if (SelectedCourseCode != null)
            {
                SelectedCourse = DataAccess.GetAllCourses().FirstOrDefault(c => SelectedCourseCode.Contains(c.CourseCode));


            }

            else
            {
                SelectedCourse = null;
            }



        }

    }
}