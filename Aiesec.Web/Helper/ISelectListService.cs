﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aiesec.Web.Helper
{
    public interface ISelectListService
    {
        ValueTask<IEnumerable<SelectListItem>> Cities(bool includeChooseText = true);
        ValueTask<IEnumerable<SelectListItem>> Roles(bool includeChooseText = true);
        ValueTask<IEnumerable<SelectListItem>> Genders(bool includeChooseText = true);
        ValueTask<IEnumerable<SelectListItem>> FunctionalFields(bool includeChooseText = true);
        ValueTask<IEnumerable<SelectListItem>> LocalCommittees(bool includeChooseText = true);

    }
}
