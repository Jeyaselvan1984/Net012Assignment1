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
using static CareerCloud.gRPC.Protos.SecurityLoginRole;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginRole : SecurityLoginRoleBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        public SecurityLoginRole()
        {
            _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>());
        }
        public override Task<Empty> CreateSecurityLoginRole(SecurityLoginRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1];

                  
        pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].Role = Guid.Parse(request.Role);
  


            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteSecurityLoginRole(SecurityLoginRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1];


            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].Role = Guid.Parse(request.Role);



            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateSecurityLoginRole(SecurityLoginRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1];



            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Login = Guid.Parse(request.Login);
            pocos[0].Role = Guid.Parse(request.Role);

            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<SecurityLoginRolePayload> ReadSecurityLoginRole(SecurityLoginRoleRequest request, ServerCallContext context)
        {
            SecurityLoginsRolePoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginRolePayload>(
                    () => new SecurityLoginRolePayload()
                    {
                        Id = poco.Id.ToString(),
                        Login = poco.Login.ToString(),
                        Role = poco.Role.ToString()
                      
                    }
            );

        }
    }
}
