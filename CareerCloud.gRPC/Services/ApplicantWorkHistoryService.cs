using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantWorkHistory;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantWorkHistoryService : ApplicantWorkHistoryBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryService()
        {
            _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>());
        }
        public override Task<Empty> CreateApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1];

         
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CompanyName = request.CompanyName;
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Location = request.Location;
            pocos[0].JobTitle = request.JobTitle;
            pocos[0].JobDescription = request.JobDescription;
            pocos[0].StartMonth = Convert.ToInt16(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToInt16(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CompanyName = request.CompanyName;
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Location = request.Location;
            pocos[0].JobTitle = request.JobTitle;
            pocos[0].JobDescription = request.JobDescription;
            pocos[0].StartMonth = Convert.ToInt16(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToInt16(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CompanyName = request.CompanyName;
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Location = request.Location;
            pocos[0].JobTitle = request.JobTitle;
            pocos[0].JobDescription = request.JobDescription;
            pocos[0].StartMonth = Convert.ToInt16(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToInt16(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<ApplicantWorkHistoryPayload> ReadApplicantWorkHistory(ApplicantWorkHistoryRequest request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantWorkHistoryPayload>(
                    () => new ApplicantWorkHistoryPayload()
                    {
                        Id = poco.Id.ToString(),
                        Applicant = poco.Applicant.ToString(),
                        CompanyName = poco.CompanyName,
                        CountryCode = poco.CountryCode,
                        Location = poco.Location,
                       JobTitle = poco.JobTitle,
                       JobDescription = poco.JobDescription,
                       StartMonth = poco.StartMonth,
                        StartYear = poco.StartYear,
                        EndMonth = poco.EndMonth,
                        EndYear = poco.EndYear


        }
            );

        }
    }
}
