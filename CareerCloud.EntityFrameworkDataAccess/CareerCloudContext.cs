using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications{ get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> systemLanguageCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>
            (entity =>
            {
                //entity.ToTable("Applicant_Educations");
                //entity.Property(_ => _.StartDate.HasColumnName("Start_Date").HasColumnType("date");
                //For single column primary key
                entity.HasKey(e => e.Id);
    //MultiColumn Composite key
    entity.HasKey(e => new { e.Id, e.Major });
                entity.HasOne(e => e.ApplicantProfiles)
    .WithMany(p => p.ApplicantEducation)
    .HasForeignKey(e => e.Applicant);
                entity.Property(e => e.TimeStamp).IsRowVersion();
    //Alternatively in Poco class use //[NotMapped]
});
            modelBuilder.Entity<ApplicantProfilePoco>
           (entity =>
           {
               //entity.ToTable("Applicant_Educations");
               //entity.Property(_ => _.StartDate.HasColumnName("Start_Date").HasColumnType("date");
               //For single column primary key
               entity.HasKey(e => e.Id);
               //MultiColumn Composite key
               // entity.HasKey(e => new { e.Id, e.Major });
               entity.HasMany(e => e.ApplicantEducation)
                .WithOne(p => p.ApplicantProfiles);

               entity.HasOne(e => e.SystemCountryCode)
               .WithMany(p => p.ApplicantProfile).HasForeignKey(e => new { e.Id, e.Login});

     
               entity.Property(e => e.TimeStamp).IsRowVersion();
                //Alternatively in Poco class use //[NotMapped]
            });

            modelBuilder.Entity<ApplicantJobApplicationPoco>
         (entity =>
         {
         
               entity.HasKey(e => e.Id);

               entity.HasOne(e => e.CompanyJob)
              .WithMany(p => p.ApplicantJobApplication).HasForeignKey(e=>new { e.Job, e.Applicant });

             entity.HasOne(e => e.ApplicantProfile)
             .WithMany(p => p.ApplicantJobApplication);


             entity.Property(e => e.TimeStamp).IsRowVersion();
  
           });


            modelBuilder.Entity<ApplicantResumePoco>
         (entity =>
         {

             entity.HasKey(e => e.Id);
             

             entity.HasOne(e =>e.ApplicantProfile)
            .WithMany(f => f.ApplicantResume).HasForeignKey(e=>e.Applicant);

       
          


         });

            modelBuilder.Entity<ApplicantSkillPoco>
      (entity =>
      {

          entity.HasKey(e => e.Id);


          entity.HasOne(e => e.ApplicantProfile)
         .WithMany(f => f.ApplicantSkill).HasForeignKey(e => e.Applicant);





      });

       modelBuilder.Entity<ApplicantWorkHistoryPoco>
        (entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.ApplicantProfile)
            .WithMany(f => f.ApplicantWorkHistory).HasForeignKey(e=>new { e.CountryCode, e.Applicant });

            entity.HasOne(e => e.SystemCountryCode).WithMany(f => f.ApplicantWorkHistory);
        });

            modelBuilder.Entity<CompanyJobPoco>
     (entity =>
     {
         entity.HasKey(e => e.Id);
         entity.HasOne(e => e.CompanyProfile)
         .WithMany(f => f.CompanyJob).HasForeignKey(f => f.Company );

     
     });

            modelBuilder.Entity<CompanyDescriptionPoco>
(entity =>
{
    entity.HasKey(e => e.Id);
    entity.HasOne(e => e.CompanyProfile)
    .WithMany(f => f.CompanyDescription).HasForeignKey(f => new { f.Company, f.LanguageId });

    entity.HasOne(e => e.SystemLanguageCode)
    .WithMany(f => f.CompanyDescription);

});
            modelBuilder.Entity<CompanyLocationPoco>
(entity =>
{
    entity.HasKey(e => e.Id);
    entity.HasOne(e => e.CompanyProfile)
    .WithMany(f => f.CompanyLocation).HasForeignKey(f => f.Company );



});

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            optionsBuilder.UseSqlServer(_connStr);
            base.OnConfiguring(optionsBuilder);
        }
      
      
    }
}
