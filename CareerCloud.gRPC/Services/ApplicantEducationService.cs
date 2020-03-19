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