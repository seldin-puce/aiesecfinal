using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Service.IServices
{
    public interface ITeamService : ICRUDService<Database.Models.Team, Model.Request.Administration.Team, Model.Update.Administration.Team, Model.Response.Administration.Team,
        Model.Search.Administration.Team, string, int>
    {
    }
}
