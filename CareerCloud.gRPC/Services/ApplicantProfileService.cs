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

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].CurrentSalary =  Convert.ToDecimal(request.CurrentSalary);
            pocos[0].CurrentRate = Convert.ToDecimal(request.CurrentRate);
            pocos[0].Currency = request.Currency;
            pocos[0].Country = request.Country;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;
   

            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].CurrentSalary = Convert.ToDecimal(request.CurrentSalary);
            pocos[0].CurrentRate = Convert.ToDecimal(request.CurrentRate);
            pocos[0].Currency = request.Currency;
            pocos[0].Country = request.Country;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].CurrentSalary = Convert.ToDecimal(request.CurrentSalary);
            pocos[0].CurrentRate = Convert.ToDecimal(request.CurrentRate);
            pocos[0].Currency = request.Currency;
            pocos[0].Country = request.Country;
            pocos[0].Province = request.Province;
            pocos[0].Street = request.Street;
            pocos[0].City = request.City;
            pocos[0].PostalCode = request.PostalCode;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<ApplicantProfilePayload> ReadApplicantProfile(ApplicantRequest request, ServerCallContext context)
        {
            ApplicantProfilePoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantProfilePayload>(
                    () => new ApplicantProfilePayload()
                    {
                        Id = poco.Id.ToString(),
                        Login = poco.Login.ToString(),
                        CurrentSalary = poco.CurrentSalary is null ? 0 : Convert.ToDouble(poco.CurrentSalary),
                        CurrentRate = poco.CurrentRate is null ? 0 : Convert.ToDouble(poco.CurrentRate),
                        Currency = poco.Currency,
                        Country = poco.Country,
                        Province = poco.Province,
                        Street = poco.Street,
                        City = poco.City,
                        PostalCode = poco.PostalCode
          
                    }
            );

        }
    }
}
