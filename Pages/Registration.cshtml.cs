using AcademicManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Lab2.Pages
{
    public class RegistrationModel : PageModel
    {

        [BindProperty]


        public List<AcademicRecord> academicRecords { get; set; } = new List<AcademicRecord>();

        [BindProperty]
        public string selectedStudentId { get; set; }


        [BindProperty]
        public List<SelectListItem>? cSelections { get; set; }

        [BindProperty]
        public List<Course> SelectedCourses { get; set; }


        public Boolean NameCheck { get; set; } = false;
        public Boolean CourseCheck { get; set; } = false;
        public int LoadTime { get; set; } = 0;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            LoadTime += 1;
            if (selectedStudentId != "-1")
            {
                NameCheck = true;
                academicRecords = DataAccess.GetAcademicRecordsByStudentId(selectedStudentId);

                if (academicRecords.Count() > 0)
                {
                    NameCheck = true;
                    CourseCheck = true;

                    SelectedCourses = new List<Course>();
                    foreach (AcademicRecord ar in academicRecords)
                    {
                        SelectedCourses.Add(DataAccess.GetAllCourses().First(c => c.CourseCode == ar.CourseCode));
                    }

                }
            }


        }

        public void OnPostRegister()
        {

            NameCheck = true;

            foreach (SelectListItem item in cSelections)
            {
                if (item.Selected)
                {
                    CourseCheck = true;
                    SelectedCourses.Add(DataAccess.GetAllCourses().First(c => c.CourseCode == item.Value));
                    DataAccess.AddAcademicRecord(new AcademicRecord(selectedStudentId, item.Value));

                }
            }

        }


    }
}
