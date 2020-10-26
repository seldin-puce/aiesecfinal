using Aiesec.Database.Context;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Service.Services
{
    public class MemberCommitteeService : CRUDService<Database.Models.MemberCommittee, Model.Request.Administration.MemberCommittee, Model.Update.Administration.MemberCommittee,
        Model.Response.Administration.MemberCommittee, Model.Search.Administration.MemberCommittee, string, int>, IMemberCommitteeService
    {
        public MemberCommitteeService(DBContext dbContext, ILogger<MemberCommitteeService> logger, IMapper mapper, IDataProtectionProvider protectionProvider) : base(dbContext, logger, mapper, protectionProvider)
        {
        }
    }
}
