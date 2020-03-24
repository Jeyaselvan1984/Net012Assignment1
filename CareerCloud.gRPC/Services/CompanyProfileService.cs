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
using static CareerCloud.gRPC.Protos.CompanyProfile;

namespace CareerCloud.gRPC.Services
{
    public class CompanyProfile : CompanyProfileBase
    {
        private readonly CompanyProfileLogic _logic;
        public CompanyProfile()
        {
            _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>());
        }
        public override Task<Empty> CreateCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1];
    
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].RegistrationDate = request.RegistrationDate.ToDateTime();
            pocos[0].CompanyWebsite = request.CompanyWebsite;
            pocos[0].ContactPhone = request.ContactPhone;
            pocos[0].ContactName = request.ContactName;
            pocos[0].CompanyLogo = request.CompanyLogo.ToByteArray();
           


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].RegistrationDate = request.RegistrationDate.ToDateTime();
            pocos[0].CompanyWebsite = request.CompanyWebsite;
            pocos[0].ContactPhone = request.ContactPhone;
            pocos[0].ContactName = request.ContactName;
            pocos[0].CompanyLogo = request.CompanyLogo.ToByteArray();

            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].RegistrationDate = request.RegistrationDate.ToDateTime();
            pocos[0].CompanyWebsite = request.CompanyWebsite;
            pocos[0].ContactPhone = request.ContactPhone;
            pocos[0].ContactName = request.ContactName;
            pocos[0].CompanyLogo = request.CompanyLogo.ToByteArray();

            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<CompanyProfilePayload> ReadCompanyProfile(CompanyProfileRequest request, ServerCallContext context)
        {
            CompanyProfilePoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyProfilePayload>(
                    () => new CompanyProfilePayload()
                    {
                       
                        Id = poco.Id.ToString(),
                        RegistrationDate = Timestamp.FromDateTime((DateTime)poco.RegistrationDate),
                        CompanyWebsite = poco.CompanyWebsite,
                        ContactPhone = poco.ContactPhone,
                        ContactName = poco.ContactName,
                        CompanyLogo = Google.Protobuf.ByteString.CopyFrom(poco.CompanyLogo),
              
                    }
            );

        }
    }
}
