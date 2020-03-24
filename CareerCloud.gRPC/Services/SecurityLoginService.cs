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
using static CareerCloud.gRPC.Protos.SecurityLogin;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLogin : SecurityLoginBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLogin()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        }
        public override Task<Empty> CreateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = request.Login;
            pocos[0].Password = request.Password;
            pocos[0].Created = request.Created.ToDateTime();
            pocos[0].PasswordUpdate = request.PasswordUpdate.ToDateTime();
            pocos[0].AgreementAccepted = request.AgreementAccepted.ToDateTime();
            pocos[0].IsLocked = request.IsLocked;
                pocos[0].IsInactive = request.IsInactive;
                pocos[0].EmailAddress = request.EmailAddress;
                pocos[0].PhoneNumber = request.PhoneNumber;
                pocos[0].FullName = request.FullName;
                pocos[0].ForceChangePassword = request.ForceChangePassword;
            pocos[0].PrefferredLanguage = request.PrefferredLanguage;



            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = request.Login;
            pocos[0].Password = request.Password;
            pocos[0].Created = request.Created.ToDateTime();
            pocos[0].PasswordUpdate = request.PasswordUpdate.ToDateTime();
            pocos[0].AgreementAccepted = request.AgreementAccepted.ToDateTime();
            pocos[0].IsLocked = request.IsLocked;
            pocos[0].IsInactive = request.IsInactive;
            pocos[0].EmailAddress = request.EmailAddress;
            pocos[0].PhoneNumber = request.PhoneNumber;
            pocos[0].FullName = request.FullName;
            pocos[0].ForceChangePassword = request.ForceChangePassword;
            pocos[0].PrefferredLanguage = request.PrefferredLanguage;


            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = request.Login;
            pocos[0].Password = request.Password;
            pocos[0].Created = request.Created.ToDateTime();
            pocos[0].PasswordUpdate = request.PasswordUpdate.ToDateTime();
            pocos[0].AgreementAccepted = request.AgreementAccepted.ToDateTime();
            pocos[0].IsLocked = request.IsLocked;
            pocos[0].IsInactive = request.IsInactive;
            pocos[0].EmailAddress = request.EmailAddress;
            pocos[0].PhoneNumber = request.PhoneNumber;
            pocos[0].FullName = request.FullName;
            pocos[0].ForceChangePassword = request.ForceChangePassword;
            pocos[0].PrefferredLanguage = request.PrefferredLanguage;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<SecurityLoginPayload> ReadSecurityLogin(SecurityLoginRequest request, ServerCallContext context)
        {
            SecurityLoginPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginPayload>(
                    () => new SecurityLoginPayload()
                    {
                       

                        Id = poco.Id.ToString(),
                        Login = poco.Login,
                        Password = poco.Password,
                        Created = Timestamp.FromDateTime((DateTime)poco.Created),
                        PasswordUpdate = poco.PasswordUpdate is null ? null : Timestamp.FromDateTime((DateTime)poco.PasswordUpdate),
                        AgreementAccepted = poco.AgreementAccepted is null ? null :  Timestamp.FromDateTime((DateTime)poco.AgreementAccepted),
                        IsLocked = poco.IsLocked,
                        IsInactive = poco.IsInactive,
                        EmailAddress = poco.EmailAddress,
                        PhoneNumber = poco.PhoneNumber,
                        FullName = poco.FullName,
                        ForceChangePassword = poco.ForceChangePassword,
                        PrefferredLanguage = poco.PrefferredLanguage
                    }
            );

        }
    }
}
