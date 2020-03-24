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
using static CareerCloud.gRPC.Protos.SystemLanguageCode;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCode : SystemLanguageCodeBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCode()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
        }
        public override Task<Empty> CreateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1];
            pocos[0].LanguageID = request.LanguageID;
            pocos[0].Name = request.Name;
            pocos[0].NativeName = request.NativeName;
            _logic.Add(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1];

            pocos[0].LanguageID = request.LanguageID;
            pocos[0].Name = request.Name;
            pocos[0].NativeName = request.NativeName;

            _logic.Delete(pocos);
            return new Task<Empty>(null);
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1];
            pocos[0].LanguageID = request.LanguageID;
            pocos[0].Name = request.Name;
            pocos[0].NativeName = request.NativeName;
            _logic.Update(pocos);
            return new Task<Empty>(null);
        }

        public override Task<SystemLanguageCodePayload> ReadSystemLanguageCode(SystemLanguageCodeRequest request, ServerCallContext context)
        {
            SystemLanguageCodePoco poco = _logic.Get(request.LanguageID);
            return new Task<SystemLanguageCodePayload>(
                    () => new SystemLanguageCodePayload()
                    {
                        LanguageID = poco.LanguageID,
                        Name = poco.Name,
                        NativeName = poco.NativeName
                    }
            );

        }
    }
}
