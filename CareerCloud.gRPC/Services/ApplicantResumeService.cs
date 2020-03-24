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
using static CareerCloud.gRPC.Protos.ApplicantResume;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantResumeService : ApplicantResumeBase
    {
        private readonly ApplicantResumeLogic _logic;
        public ApplicantResumeService()
        {
            _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>());
        }
        public override Task<Empty> CreateApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Resume = request.Resume;
            pocos[0].LastUpdated = request.LastUpdated.ToDateTime();


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Resume = request.Resume;
            pocos[0].LastUpdated = request.LastUpdated.ToDateTime();


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1];


            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Resume = request.Resume;
            pocos[0].LastUpdated = request.LastUpdated.ToDateTime();


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<ApplicantResumePayload> ReadApplicantResume(ApplicantResumeRequest request, ServerCallContext context)
        {
            ApplicantResumePoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantResumePayload>(
                    () => new ApplicantResumePayload()
                    {

                        Id = poco.Id.ToString(),
                        Applicant = poco.Applicant.ToString(),
                        Resume = poco.Resume,
                        LastUpdated = poco.LastUpdated is null ? null : Timestamp.FromDateTime((DateTime)poco.LastUpdated)

                    }
            );

        }
    }
}
