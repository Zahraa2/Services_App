using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;
namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManger category;

        public CategoryController(ICategoryManger category)
        {
            this.category = category;
        }
        //return all names of category
        [HttpGet]
        [Route("CategoryNames")]
        public ActionResult<List<string>> GetCategoryName()
        {
            List<string> CategoryNames = category.GetAllNames();
            return CategoryNames;
        }
        [HttpPost]
        [Route("Addcatigorty")]
        public void addcatigory(CategoryWriteDTO category5)
        {
            category.Add(category5);
        }


    }
}
