using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        private string _connStr;
        public ApplicantEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params ApplicantEducationPoco[] items)
        {
            //@"Data Source=DESKTOP-KE364B2\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;"
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco poco in items)
                { 
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                comm.CommandText = @"INSERT INTO[dbo].[Applicant_Educations]
                                       ([Id]
                                       ,[Applicant]
                                       ,[Major]
                                       ,[Certificate_Diploma]
                                       ,[Start_Date]
                                       ,[Completion_Date]
                                       ,[Completion_Percent])
                                 VALUES
                                       (@Id,
                                        @Applicant,
                                        @Major,     
                                        @Certificate_Diploma, 
                                        @Start_Date, 
                                        @Completion_Date,
                                        @Completion_Percent)";
                    comm.Parameters.AddWithValue("@Id", poco.Id);
                    comm.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    comm.Parameters.AddWithValue("@Major", poco.Major);
                    comm.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    comm.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    comm.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    comm.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    connection.Open();
                    int rowAffected = comm.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            throw new NotImplementedException();
        }
    }

      
}
