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
using static CareerCloud.gRPC.Protos.CompanyJob;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJob : CompanyJobBase
    {
        private readonly CompanyJobLogic _logic;
        public CompanyJob()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
        }
        public override Task<Empty> CreateCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[1];
         
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].ProfileCreated = request.ProfileCreated.ToDateTime();
            pocos[0].IsInactive = request.IsInactive;
            pocos[0].IsCompanyHidden = request.IsCompanyHidden;

            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].ProfileCreated = request.ProfileCreated.ToDateTime();
            pocos[0].IsInactive = request.IsInactive;
            pocos[0].IsCompanyHidden = request.IsCompanyHidden;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].ProfileCreated = request.ProfileCreated.ToDateTime();
            pocos[0].IsInactive = request.IsInactive;
            pocos[0].IsCompanyHidden = request.IsCompanyHidden;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<CompanyJobPayload> ReadCompanyJob(CompanyJobRequest request, ServerCallContext context)
        {
            CompanyJobPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyJobPayload>(
                    () => new CompanyJobPayload()
                    {


                        Id = poco.Id.ToString(),
                        Company = poco.Company.ToString(),
                        ProfileCreated = Timestamp.FromDateTime((DateTime)poco.ProfileCreated),
                        IsInactive = poco.IsInactive,
                        IsCompanyHidden = poco.IsCompanyHidden
                    }
            ) ;

        }
    }
}
