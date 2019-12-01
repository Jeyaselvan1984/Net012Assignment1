﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]
    class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        [Column("Company_Name")]
        public string CompanyName { get; set; }
        [Column("Country_Code")]
        public string CountryCode { get; set; }
        public string Location { get; set; }
        [Column("Job_Title")]
        public string JobTitle { get; set; }
        [Column("Job_Description")]
        public string JobDescription { get; set; }
        [Column("Start_Month")]
        public short StartMonth { get; set; }
        [Column("Start_Year")]
        public Int32 StartYear { get; set; }
        [Column("End_Month")]
        public short EndMonth { get; set; }
        [Column("End_Year")]
        public Int32 EndYear { get; set; }
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}