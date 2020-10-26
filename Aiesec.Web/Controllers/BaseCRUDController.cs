using System;
using System.Net;
using System.Threading.Tasks;
using Aiesec.Service.Attributes;
using Aiesec.Service.IServices;
using Aiesec.Web.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aiesec.Web.Controllers
{
    public class BaseCRUDController<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> :
        Controller where TSearch : class where TRequest : class, new()
    {
        protected readonly ICRUDService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> CrudService;
        protected readonly IMapper Mapper;
        protected readonly SharedResource Localizer;

        public BaseCRUDController(ICRUDService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> crudService,
            SharedResource localizer, IMapper mapper)
        {
            CrudService = crudService;
            Localizer = localizer;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            ViewBag.ModelInsertSuccessfull = TempData["Model"];
            return View(await CrudService.TakeRecordsByNumberAsync());
        }


        [HttpGet]
        public virtual IActionResult Insert() => View(new TRequest());

        [HttpPost, AutoValidateModelState]
        public virtual async Task<IActionResult> Create([FromForm] TRequest model)
        {
            try
            {
                await CrudService.InsertAsync(model);
                TempData["Model"] = true;
                TempData["Message"] = Localizer.SuccAdd;
            }
            catch(Exception e)
            {
                var a = e.Message;
                TempData["Model"] = false;
                TempData["Message"] = Localizer.ErrAdd;

            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet, ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([FromRoute] TEncryptedKey encryptedId)
        {
            try
            {
                var model = await CrudService.GetByIdAsync(encryptedId);
                return View(model);
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Localizer.ResourceCantBeRetrieved });
            }
        }

        public virtual async Task<IActionResult> Edit(TEncryptedKey encryptedId)
        {
            TResponse model = await CrudService.GetByIdAsync(encryptedId);
            if (model != null)
                return View(model);
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Update(TEncryptedKey encryptedId, TUpdate model)
        {
            try
            {   
                await CrudService.UpdateAsync(encryptedId, model);
                TempData["Model"] = true;
                TempData["Message"] = Localizer.SuccUpdate;
            }
            catch
            {
                TempData["Model"] = false;
                TempData["Message"] = Localizer.ErrUpdate;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete, Transaction, AutoValidateModelState]
        public virtual async Task<IActionResult> Delete(TEncryptedKey encryptedId)
        {
            try
            {
                await CrudService.DeleteAsync(encryptedId);
                return Json(new { success = true, message = Localizer.SuccDelete });
            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, message = Localizer.ErrDelete });
            }
        }

        [HttpGet, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> ChangeActiveStatusAsync([FromRoute] TEncryptedKey encryptedId)
        {
            try
            {
                TResponse model = await CrudService.ChangeActiveStatusAsync(encryptedId);
                return Json(new { success = true, message = Localizer.SuccChangeStatus, model });
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, message = Localizer.ErrChangeStatus });
            }
        }
    }
}