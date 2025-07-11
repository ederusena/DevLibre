﻿namespace DevLibre.Entities
{
    public class ProjectComment : BaseEntity
    {
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public string Content { get; private set; }
        public ProjectComment(string content, int idProject, int idUser)
        {
            IdProject = idProject;
            IdUser = idUser;
            Content = content;
        }
    }
}
