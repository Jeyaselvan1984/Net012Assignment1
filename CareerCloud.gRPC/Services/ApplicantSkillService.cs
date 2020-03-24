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
using static CareerCloud.gRPC.Protos.ApplicantSkill;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantSkillService : ApplicantSkillBase
    {
        private readonly ApplicantSkillLogic _logic;
        public ApplicantSkillService()
        {
            _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>());
        }
        public override Task<Empty> CreateApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].StartMonth = Convert.ToByte(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToByte(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].StartMonth = Convert.ToByte(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToByte(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Applicant = Guid.Parse(request.Applicant);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].StartMonth = Convert.ToByte(request.StartMonth);
            pocos[0].StartYear = request.StartYear;
            pocos[0].EndMonth = Convert.ToByte(request.EndMonth);
            pocos[0].EndYear = request.EndYear;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<ApplicantSkillPayload> ReadApplicantSkill(ApplicantSkillRequest request, ServerCallContext context)
        {
            ApplicantSkillPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantSkillPayload>(
                    () => new ApplicantSkillPayload()
                    {
                        Id = poco.Id.ToString(),
                        Applicant = poco.Applicant.ToString(),
                        Skill = poco.Skill,
                        SkillLevel = poco.SkillLevel,
                        StartMonth = poco.StartMonth,
                        StartYear = poco.StartYear,
                        EndMonth = poco.EndMonth,
                        EndYear = poco.EndYear


                    }
            );

        }
    }
}
