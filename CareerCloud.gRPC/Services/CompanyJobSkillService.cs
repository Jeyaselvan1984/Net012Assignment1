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
using static CareerCloud.gRPC.Protos.CompanyJobSkill;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobSkill : CompanyJobSkillBase
    {
        private readonly CompanyJobSkillLogic _logic;
        public CompanyJobSkill()
        {
            _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>());
        }
        public override Task<Empty> CreateCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].Importance = request.Importance;

            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].Importance = request.Importance;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Skill = request.Skill;
            pocos[0].SkillLevel = request.SkillLevel;
            pocos[0].Importance = request.Importance;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<CompanyJobSkillPayload> ReadCompanyJobSkill(CompanyJobSkillRequest request, ServerCallContext context)
        {
            CompanyJobSkillPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyJobSkillPayload>(
                    () => new CompanyJobSkillPayload()
                    {
                  
                        Id = poco.Id.ToString(),
                        Job = poco.Job.ToString(),
                        Skill = poco.SkillLevel,
                        SkillLevel = poco.SkillLevel,
                        Importance = poco.Importance
                    }
            );

        }
    }
}
