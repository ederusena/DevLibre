﻿using DevLibre.Enums;
using Microsoft.EntityFrameworkCore;

namespace DevLibre.Entities
{
    public class Project : BaseEntity
    {
        protected Project() { }
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost) : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            Comments = new List<ProjectComment>();
            Status = ProjectStatusEnum.Created;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient{ get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        [Precision(18,2)]
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
                Status = ProjectStatusEnum.Cancelled;
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.UtcNow;
            }
        }

        public void Complete()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.PaymentPending)
            {
                Status = ProjectStatusEnum.Completed;
                CompletedAt = DateTime.UtcNow;
            }
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.PaymentPending;
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }


    }
}
