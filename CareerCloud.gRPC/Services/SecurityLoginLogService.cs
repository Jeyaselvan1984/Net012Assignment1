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
using static CareerCloud.gRPC.Protos.SecurityLoginLog;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginLog : SecurityLoginLogBase
    {
        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginLog()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
        }
        public override Task<Empty> CreateSecurityLoginLog(SecurityLoginLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1];
 
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].SourceIP = request.SourceIP;
            pocos[0].LogonDate = request.LogonDate.ToDateTime();
            pocos[0].IsSuccesful = request.IsSuccesful;
            

            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteSecurityLoginLog(SecurityLoginLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1];
            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].SourceIP = request.SourceIP;
            pocos[0].LogonDate = request.LogonDate.ToDateTime();
            pocos[0].IsSuccesful = request.IsSuccesful;



            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateSecurityLoginLog(SecurityLoginLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].SourceIP = request.SourceIP;
            pocos[0].LogonDate = request.LogonDate.ToDateTime();
            pocos[0].IsSuccesful = request.IsSuccesful;


            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<SecurityLoginLogPayload> ReadSecurityLoginLog(SecurityLoginLogRequest request, ServerCallContext context)
        {
            SecurityLoginsLogPoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginLogPayload>(
                    () => new SecurityLoginLogPayload()
                    {
                        Id = poco.Id.ToString(),
                        Login = poco.Login.ToString(),
                        SourceIP = poco.SourceIP,
                        LogonDate = Timestamp.FromDateTime((DateTime)poco.LogonDate),
                        IsSuccesful = poco.IsSuccesful
                    }
            );

        }
    }
}
