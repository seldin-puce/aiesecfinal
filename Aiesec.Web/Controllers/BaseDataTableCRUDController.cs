using System.Threading.Tasks;
using Aiesec.Service.IServices;
using Aiesec.Web.Models;
using Aiesec.Web.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aiesec.Web.Controllers
{
    public class BaseDataTableCRUDController<TModel, TInsert, TUpdate, TResult, TSearch, TEncryptedKey, TDecryptedKey> : BaseCRUDController<TModel, TInsert, TUpdate, TResult, TSearch, TEncryptedKey, TDecryptedKey> where TSearch : class where TInsert : class, new()
    {
        public BaseDataTableCRUDController(ICRUDService<TModel, TInsert, TUpdate, TResult, TSearch, TEncryptedKey, TDecryptedKey> crudService,  SharedResource localizer, IMapper mapper) 
            : base(crudService, localizer, mapper)
        {
        }
        [HttpGet]
        public override async Task<IActionResult> Index()
        {
            int numberOfRecords = await CrudService.GetNumberOfRecordsAsync();
            DataTable<TResult> model = new DataTable<TResult>()
            {
                recordsFiltered = numberOfRecords,
                recordsTotal = numberOfRecords,
                data = await CrudService.TakeRecordsByNumberAsync()
            };
            ViewBag.Model = TempData["Model"];
            ViewBag.Message = TempData["Message"];
            return View(model);
        }

        [HttpPost, IgnoreAntiforgeryToken]
        public virtual async Task<DataTable<TResult>> GetData([FromForm]TSearch searchParams, [FromForm]DataTableRequest request)
        {
            var filteredData = await CrudService.GetByParametersAsync(searchParams, request.order[0].dir, request.columns[request.order[0].column].name, request.start, request.length);
            return new DataTable<TResult>
            {
                draw = request.draw,
                recordsTotal = filteredData.Item2,
                recordsFiltered = filteredData.Item2,
                data = filteredData.Item1
            };
        }
    }
}