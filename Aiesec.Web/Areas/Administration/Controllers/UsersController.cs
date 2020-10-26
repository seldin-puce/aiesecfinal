using System.Threading.Tasks;
using Aiesec.Service.IServices;
using Aiesec.Web.Helper;
using Aiesec.Web.Models;
using Aiesec.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using AutoMapper;
using System.Net;
using System;
using System.Linq;
using Aiesec.Service.Attributes;
using Aiesec.Service.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Aiesec.Web.Areas.Administration.Controllers
{
    [Authorize]
    [Area(Strings.Area.Administration)]
    public class UsersController : Controller
    {
        private readonly UserManager<Database.Models.ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly SharedResource _sharedResource;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ValidationErrors _validationErrors;

        public UsersController(UserManager<Database.Models.ApplicationUser> userManager, IUserService userService, IProfileService profileService,
            ILogger<UsersController> logger, SharedResource sharedResource, IMapper mapper, ValidationErrors validationErrors)
        {
            _userManager = userManager;
            _userService = userService;
            _profileService = profileService;
            _sharedResource = sharedResource;
            _logger = logger;
            _mapper = mapper;
            _validationErrors = validationErrors;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    int numberOfRecords = await _userService.GetNumberOfRecordsAsync();
        //    Tuple<List<Model.Response.Administration.User>, List<int>> userData = await _userService.TakeRecordsAndIdsByNumberAsync();
        //    List<Model.Response.Administration.Profile> profileData = await _profileService.TakeRecordsByNumberAndIdsAsync(userData.Item2);
        //    IEnumerable<Model.Response.Administration.UserProfileViewModel> data =
        //        userData.Item1.Zip(profileData, (u, p) => new Model.Response.Administration.UserProfileViewModel { User = u, Profile = p });
        //    ViewModels.DataTable<Model.Response.Administration.UserProfileViewModel> model = new ViewModels.DataTable<Model.Response.Administration.UserProfileViewModel>
        //    {
        //        recordsFiltered = numberOfRecords,
        //        recordsTotal = numberOfRecords,
        //        data = data
        //    };
        //    ViewBag.UserRegisterSuccessful = TempData["SuccUserAdd"];
        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<ViewModels.DataTable<Model.Response.Administration.UserProfileViewModel>>
        //   GetData([FromForm] Model.Search.Administration.UserProfilSearchModel searchParams, [FromForm] DataTableRequest request)
        //{
        //    int numberOfRecords = await _userService.GetNumberOfRecordsAsync();
        //    Tuple<List<Model.Response.Administration.User>, List<int>> userData;
        //    Tuple<List<Model.Response.Administration.Profile>, List<int>> profileData;
        //    if (searchParams.User == null)
        //    {
        //        profileData = await _profileService.GetByParametersAndIdsAsync(searchParams.Profile, null, request.order[0].dir, request.columns[request.order[0].column].name, request.start, request.length);
        //        userData = await _userService.GetByParametersAndIdsAsync(searchParams.User, profileData.Item2, request.order[0].dir, request.columns[request.order[0].column].name, request.start, request.length);
        //    }
        //    else
        //    {
        //        userData = await _userService.GetByParametersAndIdsAsync(searchParams.User, null, request.order[0].dir, request.columns[request.order[0].column].name, request.start, request.length);
        //        profileData = await _profileService.GetByParametersAndIdsAsync(searchParams.Profile, userData.Item2, request.order[0].dir, request.columns[request.order[0].column].name, request.start, request.length);
        //    }

        //    IEnumerable<Model.Response.Administration.UserProfileViewModel> data =
        //       userData.Item1.Zip(profileData.Item1, (u, p) => new Model.Response.Administration.UserProfileViewModel { User = u, Profile = p });

        //    return new ViewModels.DataTable<Model.Response.Administration.UserProfileViewModel>
        //    {
        //        draw = request.draw,
        //        recordsTotal = numberOfRecords,
        //        recordsFiltered = numberOfRecords,
        //        data = data
        //    };
        //}

        //[HttpGet]
        //public IActionResult Insert() => View();

        //[HttpGet, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Details([FromRoute] string encryptedId)
        //{
        //    try
        //    {
        //        var userData = await _userService.GetByIdAsync(encryptedId);
        //        var profileData = await _profileService.GetByIdAsync(encryptedId);
        //        return View(new Model.Response.Administration.UserProfileViewModel { User = userData, Profile = profileData, OldEncryptedId = encryptedId });
        //    }
        //    catch
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(new { message = _sharedResource.ResourceCantBeRetrieved });
        //    }
        //}

        //[HttpGet, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromRoute] string encryptedId)
        //{
        //    try
        //    {
        //        Model.Response.Administration.User userData = await _userService.GetByIdAsync(encryptedId);
        //        Model.Response.Administration.Profile profileData = await _profileService.GetByIdAsync(encryptedId);
        //        return View(new Model.Response.Administration.UserProfileViewModel { User = userData, Profile = profileData, OldEncryptedId = encryptedId });
        //    }
        //    catch
        //    {
        //        return Json(new { message = _sharedResource.ErrUserUpdate });
        //    }
        //}

        //[HttpPost, ValidateAntiForgeryToken, AutoValidateModelState]
        //public async Task<IActionResult> RegisterUser(Model.Request.Administration.User user, Model.Request.Administration.Profile profile, Model.Enum.Roles role)
        //{
        //    Database.Models.ApplicationUser newUser = new Database.Models.ApplicationUser { UserName = user.UserName, Email = user.Email, PhoneNumber = user.PhoneNumber };
        //    Model.Response.Administration.Profile profileResult = null;
        //    IdentityResult userResult = null;
        //    try
        //    {
        //        userResult = await _userManager.CreateAsync(newUser, user.Password);
        //        if (userResult.Succeeded)
        //        {
        //            _userService.EncryptId(newUser);
        //            profileResult = await _profileService.InsertAsync(profile);
        //            for (int i = (int)Model.Enum.Roles.Alumni; i >= (int)role; i--)
        //            {
        //                string roleName = ((Model.Enum.Roles)i).ToString();
        //                await _userManager.AddToRoleAsync(newUser, roleName);
        //            }
        //            TempData["SuccUserAdd"] = true;
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        if (userResult.Succeeded)
        //        {
        //            await _userManager.DeleteAsync(newUser);
        //            if (profileResult != null)
        //                await _userManager.DeleteAsync(newUser);
        //        }
        //    }
        //    TempData["SuccUserAdd"] = false;
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost, ValidateAntiForgeryToken, AutoValidateModelState]
        //public async Task<IActionResult> UpdateUser([FromForm] string encryptedId, [FromForm] Model.Update.Administration.User user, [FromForm] Model.Update.Administration.Profile profile)
        //{
        //    IdentityResult result = null;
        //    try
        //    {
        //        Database.Models.ApplicationUser userFromDb = await _userService.GetModelByIdAsync(encryptedId);
        //        _mapper.Map<Model.Update.Administration.User, Database.Models.ApplicationUser>(user, userFromDb);
        //        result = await _userManager.UpdateAsync(userFromDb);
        //        Model.Response.Administration.Profile profileData = await _profileService.UpdateAsync(encryptedId, profile);
        //        if (result.Succeeded && profileData is object)
        //            return Json(new
        //            {
        //                message = _sharedResource.SuccUserUpdate,
        //                model = new Model.Response.Administration.UserProfileViewModel { User = _mapper.Map<Model.Response.Administration.User>(userFromDb), Profile = profileData },
        //                target = encryptedId,
        //                callback = Settings.Routes.User.Details + "/" + userFromDb.EncryptedId,
        //                ajaxAdd = "modal-lg"
        //            });
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError("Error", _sharedResource.ErrUserUpdate);
        //    }
        //    if (result.Errors is object)
        //    {
        //        ModelState.AddModelErrors(result.Errors);
        //    }

        //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangeActiveStatus([FromRoute] string encryptedId)
        //{
        //    try
        //    {
        //        Model.Response.Administration.User userData = await _userService.ChangeActiveStatusAsync(encryptedId);
        //        Model.Response.Administration.Profile profileData = await _profileService.GetByIdAsync(encryptedId);
        //        return Json(new { message = _sharedResource.SuccChangeStatus, model = new Model.Response.Administration.UserProfileViewModel { User = userData, Profile = profileData } });
        //    }
        //    catch
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(new { message = _sharedResource.ErrChangeStatus });
        //    }
        //}
    }
}