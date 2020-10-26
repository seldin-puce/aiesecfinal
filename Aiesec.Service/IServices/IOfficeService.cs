using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Service.IServices
{
    public interface IOfficeService : ICRUDService<Database.Models.Office, Model.Request.Administration.Office, Model.Update.Administration.Office, Model.Response.Administration.Office,
        Model.Search.Administration.Office, string, int>
    {
    }
}
