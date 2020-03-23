using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Grpc.Core;
using System;
using Google.Protobuf;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantEducation;
using Google.Protobuf.WellKnownTypes;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationService : ApplicantEducationBase

    { 
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationService()
        {            
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }

        public override Task<Empty> CreateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CertificateDiploma = request.CertificateDiploma;
            pocos[0].Major = request.Major;
            pocos[0].CompletionPercent = Byte.Parse(request.CompletionPercent.ToString());
            pocos[0].CompletionDate = request.CompletionDate.ToDateTime();
            pocos[0].StartDate = request.StartDate.ToDateTime();
            
            
            _logic.Add(pocos);
            return new Task<Empty>(null);
            

        }

        public override Task<Empty> DeleteApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CertificateDiploma = request.CertificateDiploma;
            pocos[0].Major = request.Major;
            pocos[0].CompletionPercent = Byte.Parse(request.CompletionPercent.ToString());
            pocos[0].CompletionDate = request.CompletionDate.ToDateTime();
            pocos[0].StartDate = request.StartDate.ToDateTime();


            _logic.Delete(pocos);

            return new Task<Empty>(null);

        }

        public override Task<Empty> UpdateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].CertificateDiploma = request.CertificateDiploma;
            pocos[0].Major = request.Major;
            pocos[0].CompletionPercent = Byte.Parse(request.CompletionPercent.ToString());
            pocos[0].CompletionDate = request.CompletionDate.ToDateTime();
            pocos[0].StartDate = request.StartDate.ToDateTime();


            _logic.Update(pocos);

            return new Task<Empty>(null);

        }
        public override Task<ApplicantEducationPayload> ReadApplicantEducation(IdRequest request, ServerCallContext context)
        {
        ApplicantEducationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantEducationPayload>(
                    () => new ApplicantEducationPayload()
                    {
                        Id = poco.Id.ToString(),
                        Applicant = poco.Applicant.ToString(),
                        CertificateDiploma = poco.CertificateDiploma,
                        CompletionDate = poco.CompletionDate is null ? null :  Timestamp.FromDateTime((DateTime)poco.CompletionDate),
                        Major = poco.Major,
                        StartDate = poco.CompletionDate is null ? null : Timestamp.FromDateTime((DateTime)poco.StartDate),
                        CompletionPercent = poco.CompletionPercent is null ? 0 : (int)poco.CompletionPercent
                    }
            ) ;
            

            //return base.ReadApplicantEducation(request, context);
        }
    }

}