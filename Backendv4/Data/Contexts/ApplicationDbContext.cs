using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StatusEntity>().HasData(
                new StatusEntity { Id = 1, StatusName = "In Progress" },
                new StatusEntity { Id = 2, StatusName = "Completed" }
            );

      
            modelBuilder.Entity<ClientEntity>().HasData(
                new ClientEntity { Id = 1, ClientName = "SuperTech Corp" }
            );

       
            modelBuilder.Entity<OwnerEntity>().HasData(
                new OwnerEntity { Id = 1, FullName = "Ava Mitchell", ClientId = 1 },
                new OwnerEntity { Id = 2, FullName = "Liam Thompson", ClientId = 1 },
                new OwnerEntity { Id = 3, FullName = "Sophia Rivera", ClientId = 1 },
                new OwnerEntity { Id = 4, FullName = "Noah Patel", ClientId = 1 },
                new OwnerEntity { Id = 5, FullName = "Emma Clark", ClientId = 1 },
                new OwnerEntity { Id = 6, FullName = "Elijah Nguyen", ClientId = 1 },
                new OwnerEntity { Id = 7, FullName = "Isabella Wright", ClientId = 1 },
                new OwnerEntity { Id = 8, FullName = "James Hernandez", ClientId = 1 }
            );

           
            modelBuilder.Entity<ProjectEntity>().HasData(
                new ProjectEntity
                {
                    Id = "11111111-1111-1111-1111-111111111111", 
                    ProjectName = "Project X",
                    Description = "Description for Project X",
                    StartDate = new DateTime(2024, 01, 01),
                    EndDate = new DateTime(2024, 06, 01),
                    Budget = 100000.00m,
                    StatusId = 1, 
                    Created = new DateTime(2024, 01, 01),
                    ClientId = 1,
                    OwnerId = 1 
                },
                new ProjectEntity
                {
                    Id = "22222222-2222-2222-2222-222222222222",
                    ProjectName = "Project Y",
                    Description = "Description for Project Y",
                    StartDate = new DateTime(2024, 02, 01),
                    EndDate = new DateTime(2024, 07, 01),
                    Budget = 50000.00m,
                    StatusId = 2, 
                    Created = new DateTime(2024, 01, 01),
                    ClientId = 1,
                    OwnerId = 2 
                },
                new ProjectEntity
                {
                    Id = "33333333-3333-3333-3333-333333333333",
                    ProjectName = "Project Z",
                    Description = "Description for Project Z",
                    StartDate = new DateTime(2024, 03, 01),
                    EndDate = new DateTime(2025, 03, 01),
                    Budget = 250000.00m,
                    StatusId = 1, 
                    Created = new DateTime(2024, 01, 01),
                    ClientId = 1,
                    OwnerId = 3 
                }
            );

            
            modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Projects)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.NoAction); 
        }

    }

}
