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
using static CareerCloud.gRPC.Protos.ApplicantProfile;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService : ApplicantProfileBase
    {
        private readonly ApplicantProfileLogic _logic;
        public ApplicantProfileService()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        }
        public override Task<Empty> CreateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1];

            //pocos[0].Id = Guid.Parse(request.Id);
            //pocos[0].Applicant = Guid.Parse(request.Applicant);
            //pocos[0].CertificateDiploma = request.CertificateDiploma;
            //pocos[0].Major = request.Major;
            //pocos[0].CompletionPercent = Byte.Parse(request.CompletionPercent.ToString());
            //pocos[0].CompletionDate = request.CompletionDate.ToDateTime();
            //pocos[0].StartDate = request.StartDate.ToDateTime();


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            return base.DeleteApplicantProfile(request, context);
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            return base.UpdateApplicantProfile(request, context);
        }

        public override Task<ApplicantProfilePayload> ReadApplicantProfile(ApplicantRequest request, ServerCallContext context)
        {
            return base.ReadApplicantProfile(request, context);
        }
    }
}
