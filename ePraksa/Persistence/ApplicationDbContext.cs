using PracticeManagement.Core.Models;
using PracticeManagement.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PracticeManagement.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FacultyType> FacultyTypes { get; set; }
        public DbSet<FacultySector> FacultySectors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<PatientStatus> PatientStatus { get; set; }
        public DbSet<Faculty2> Faculties2 { get; set; }
        //public DbSet<Quota> Quotas { get; set; }
        public DbSet<PracticeType> PracticeTypes { get; set; }
        //public DbSet<RatingType> RatingTypes { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<YearOfStudy> YearOfStudies { get; set; }
        
        
        public DbSet<Internship> Internships { get; set; }
        //public DbSet<StudentInternship> StudentInternships { get; set; }
        //public DbSet<StudentRating> StudentRatings { get; set; }
        public DbSet<FacultyCourse> FacultyCourses { get; set; }

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Core.Models.FirmAddress> FirmAddresses { get; set; }
        public DbSet<FirmType> FirmTypes { get; set; }

        public DbSet<Grade> Grades { get; set; }
		
		//public DbSet<Poll> Polls { get; set; }
  //      public DbSet<PollQuestion> PollQuestions { get; set; }
		
        public ApplicationDbContext()
            : base("StrucnaPraksa", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PatientConfiguration());
            modelBuilder.Configurations.Add(new AppointmentConfiguration());
            modelBuilder.Configurations.Add(new ProfesorConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new SpecializationConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new FacultyConfiguration());
            modelBuilder.Configurations.Add(new Faculty2Configuration());
            //modelBuilder.Configurations.Add(new QuotaConfiguration());
            //modelBuilder.Configurations.Add(new PracticeTypeConfiguration());
            //modelBuilder.Configurations.Add(new RatingTypeConfiguration());
            modelBuilder.Configurations.Add(new MentorConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new InternshipConfiguration());
            //modelBuilder.Configurations.Add(new StudentInternshipConfiguration());
            //modelBuilder.Configurations.Add(new StudentRatingConfiguration());
            modelBuilder.Configurations.Add(new FacultyCourseConfiguration());
            modelBuilder.Configurations.Add(new YearOfStudyConfiguration());
            modelBuilder.Configurations.Add(new GradeConfiguration());


            // modelBuilder.Entity<Faculty2>().ToTable("Faculties");
            //modelBuilder.Configurations.Add(new PatientStatusConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
