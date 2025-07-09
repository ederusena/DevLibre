﻿namespace DevLibre.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string fullName, string email, DateTime birthDate) : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true; // Default to active when created

            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
            Comments = new List<ProjectComment>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }


    }
}
