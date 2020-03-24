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
using static CareerCloud.gRPC.Protos.CompanyJobEducation;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationService : CompanyJobEducationBase
    {
        private readonly CompanyJobEducationLogic _logic;
        public CompanyJobEducationService()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }
        public override Task<Empty> CreateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Major = request.Major;
            pocos[0].Importance = Convert.ToInt16(request.Importance);

            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Major = request.Major;
            pocos[0].Importance = Convert.ToInt16(request.Importance);


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Job = Guid.Parse(request.Job);
            pocos[0].Major = request.Major;
            pocos[0].Importance = Convert.ToInt16(request.Importance);


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<CompanyJobEducationPayload> ReadCompanyJobEducation(CompanyJobEducationRequest request, ServerCallContext context)
        {
            CompanyJobEducationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyJobEducationPayload>(
                    () => new CompanyJobEducationPayload()
                    {
  
                        Id = poco.Id.ToString(),
                        Job = poco.Job.ToString(),
                        Major = poco.Major,
                        Importance = poco.Importance
                    }
            );

        }
    }
}
