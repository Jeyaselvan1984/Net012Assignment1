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
using static CareerCloud.gRPC.Protos.CompanyLocation;

namespace CareerCloud.gRPC.Services
{
    public class CompanyLocation : CompanyLocationBase
    {
        private readonly CompanyLocationLogic _logic;
        public CompanyLocation()
        {
            _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>());
        }
        public override Task<Empty> CreateCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;

            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Company = Guid.Parse(request.Company);
            pocos[0].CountryCode = request.CountryCode;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;

            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<CompanyLocationPayload> ReadCompanyLocation(CompanyLocationRequest request, ServerCallContext context)
        {
            CompanyLocationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyLocationPayload>(
                    () => new CompanyLocationPayload()
                    {         
                        Id = poco.Id.ToString(),
                        Company = poco.Company.ToString(),                   
                        CountryCode = poco.CountryCode,
                        Province = poco.Province,
                        Street = poco.Street,
                        City = poco.City,
                        PostalCode = poco.PostalCode
                    }
            );

        }
    }
}
