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
using static CareerCloud.gRPC.Protos.ApplicantJobApplication;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationService : ApplicantJobApplicationBase
    {
        private readonly ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationService()
        {
            _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
        }
        public override Task<Empty> CreateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].ApplicationDate = request.ApplicationDate.ToDateTime();


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].ApplicationDate = request.ApplicationDate.ToDateTime();


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].ApplicationDate = request.ApplicationDate.ToDateTime();
            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<ApplicantJobApplicationPayload> ReadApplicantJobApplication(ApplicantJobApplicationRequest request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantJobApplicationPayload>(
                    () => new ApplicantJobApplicationPayload()
                    {
                          Id = poco.Id.ToString(),
                          Applicant = poco.Applicant.ToString(),
                          Job = poco.Job.ToString(),
                          ApplicationDate = Timestamp.FromDateTime((DateTime)poco.ApplicationDate)
                    }
            );

        }
    }
}
