using PracticeManagement.Core;
using PracticeManagement.Core.Repositories;
using PracticeManagement.Persistence.Repositories;

namespace PracticeManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatientRepository Patients { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAttendanceRepository Attandences { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IProfesorRepository Profesors { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IApplicationUserRepository Users { get; private set; }
        public IPersonRepository Persons { get; private set; }
        public IFacultyRepository Faculties { get; private set; }
        public IFacultyTypeRepository FacultyTypes { get; private set; }
        public IFacultySectorRepository FacultySectors { get; private set; }
        public IFaculty2Repository Faculties2 { get; private set; }
        //public IQuotaRepository Quotas { get; private set; }
        public IPracticeTypeRepository PracticeTypes { get; private set; }
        //public IRatingTypeRepository RatingTypes { get; private set; }
        public IMentorRepository Mentors { get; private set; }
        public IStudentRepository Students { get; private set; }
        //public IInternshipRepository Internships { get; private set; }
        //public IStudentInternshipRepository StudentInternships { get; private set; }
        //public IStudentRatingRepository StudentRatings { get; private set; }
        public IFacultyCourseRepository FacultyCourses { get; private set; }
        public IFirmRepository Firms { get; private set; }
        public IFirmTypeRepository FirmTypes { get; private set; }
        //public IPollRepository Polls { get; private set; }
        //      public IPollQuestionRepository PollQuestions { get; private set; }
        public IYearOfStudyRepository YearOfStudies { get; private set; }
        //zrinka
        public IMentorRateRepository MentorRates { get; private set; }
        //zrinka
        public IStudentRateRepository StudentRates { get; private set; }
        public IPollMentorAnswerRepository PollMentorAnswers { get; private set; }

        public IInternshipRepository Internships { get; private set; }
        // public IPollStudentRepository PollStudents { get; private set; }

        // damir-zrinka commented MentorRates = new MentorRateRepository(context);
        //PollStudents = new PollStudentRepository(context);
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Patients = new PatientRepository(context);
            Appointments = new AppointmentRepository(context);
            Attandences = new AttendanceRepository(context);
            Cities = new CityRepository(context);
            Profesors = new ProfesorRepository(context);
            Specializations = new SpecializationRepository(context);
            Users = new ApplicationUserRepository(context);
            Persons = new PersonRepository(context);
            Faculties = new FacultyRepository(context);
            FacultyTypes = new FacultyTypeRepository(context);
            FacultySectors = new FacultySectorRepository(context);
            Faculties2 = new Faculty2Repository(context);
            //Quotas = new QuotaRepository(context);
            PracticeTypes = new PracticeTypeRepository(context);
            //RatingTypes = new RatingTypeRepository(context);
            Mentors = new MentorRepository(context);

            // damir-zinka added
            MentorRates = new MentorRateRepository(context);
            StudentRates = new StudentRateRepository(context);
            PollMentorAnswers = new PollMentorAnswerRepository(context);


            Students = new StudentRepository(context);
            Internships = new InternshipRepository(context);
            //Internships = new InternshipRepository(context);
            //StudentInternships = new StudentInternshipRepository(context);
            //StudentRatings = new StudentRatingRepository(context);
            FacultyCourses = new FacultyCourseRepository(context);
            Firms = new FirmRepository(context);
            FirmTypes = new FirmTypeRepository(context);
            //Polls = new PollRepository(context);
            //         PollQuestions = new PollQuestionRepository(context);
            YearOfStudies = new YearOfStudyRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
