﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        public Guid Job { get; set; }
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public CompanyJobPoco CompanyJob { get; set; }
        public ApplicantProfilePoco ApplicantProfile { get; set; }
    

    }
}
