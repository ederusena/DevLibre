namespace DevLibre.Entities
{
    public class User : BaseEntity
    {
        public User(string fullname, string email, DateTime birthDate) : base()
        {
            Fullname = fullname;
            Email = email;
            BirthDate = birthDate;
            Active = true; // Default to active when created

            Skills = new List<UserSkill>();
            OwnedProject = new List<Project>();
            FreelanceProjects = new List<Project>();
            Comments = new List<ProjectComment>();
        }

        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProject { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }


    }
}
