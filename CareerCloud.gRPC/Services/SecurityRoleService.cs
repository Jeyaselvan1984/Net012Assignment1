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
using static CareerCloud.gRPC.Protos.SecurityRole;

namespace CareerCloud.gRPC.Services
{
    public class SecurityRole : SecurityRoleBase
    {
        private readonly SecurityRoleLogic _logic;
        public SecurityRole()
        {
            _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>());
        }
        public override Task<Empty> CreateSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Role = request.Role;
            pocos[0].IsInactive = request.IsInactive;



            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1];

            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Role = request.Role;
            pocos[0].IsInactive = request.IsInactive;



            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1];



            pocos[0].Id = Guid.Parse(request.Id);
            pocos[0].Role = request.Role;
            pocos[0].IsInactive = request.IsInactive;

            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<SecurityRolePayload> ReadSecurityRole(SecurityRoleRequest request, ServerCallContext context)
        {
            SecurityRolePoco poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityRolePayload>(
                    () => new SecurityRolePayload()
                    {
                        Id = poco.Id.ToString(),
                        Role = poco.Role,
                        IsInactive = poco.IsInactive

                    }
            );

        }
    }
}
