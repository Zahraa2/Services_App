using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;
using Microsoft.Extensions.Localization;

namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManger category;
        private readonly IStringLocalizer<CategoryController> _localizer;

        public CategoryController(ICategoryManger category, IStringLocalizer<CategoryController> localizer)
        {
            this.category = category;
            _localizer = localizer;
        }
        //return all names of category
        [HttpGet]
        [Route("CategoryNames")]
        public ActionResult<List<string>> GetCategoryName()
        {
            List<string> CategoryNames = category.GetAllNames();
            return LocalizeCategories(CategoryNames);
        }

        [HttpPost]
        [Route("Addcatigorty")]
        public void addcatigory(CategoryWriteDTO category5)
        {
            category.Add(category5);
        }

        [HttpGet]
        [Route("Localizer-Cat")]
        public List<string> LocalizeCategories(List<string> categories)
        {
            for (int i = 0; i < categories.Count; i++)
                categories[i] = _localizer[categories[i]].Value;

            return categories;
        }


    }
}
