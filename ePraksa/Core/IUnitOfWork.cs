using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Core
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IAppointmentRepository Appointments { get; }
        IAttendanceRepository Attandences { get; }
        ICityRepository Cities { get; }
        IProfesorRepository Profesors { get; }
        ISpecializationRepository Specializations { get; }
        IApplicationUserRepository Users { get; }
        IPersonRepository Persons { get; }
        IFacultyRepository Faculties { get; }

        IFaculty2Repository Faculties2 { get; }

        IFacultyTypeRepository FacultyTypes { get; }

        IFacultySectorRepository FacultySectors { get; }
        //IQuotaRepository Quotas { get; }
        IPracticeTypeRepository PracticeTypes { get; }
        IFirmRepository Firms { get; }
        IFirmTypeRepository FirmTypes { get; }

      
        //IRatingTypeRepository RatingTypes { get; }
        IMentorRepository Mentors { get; }
        IStudentRepository Students { get; }
        IYearOfStudyRepository YearOfStudies { get; }
        IInternshipRepository Internships { get; }
        //IStudentInternshipRepository StudentInternships { get; }
        //IStudentRatingRepository StudentRatings { get; }
        IFacultyCourseRepository FacultyCourses { get; }
        IGradeRepository Grades { get; }
        //IMentorRepository Mentors { get; }
      
        //IPollRepository Polls { get; }
        //      IPollQuestionRepository PollQuestions{ get; }
        void Complete();
    }
}
