using Azure;
using first_api.Data;
using first_api.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(AppDpContext db)
        {
            _db = db;
        }
        private readonly AppDpContext _db;
        [HttpGet]

        public async Task<IActionResult> getcateory()
        {
            var get = await _db.Categories.ToListAsync();
            return Ok(get);
        }
        [HttpPost]

        public async Task<IActionResult> addcatgegory(string name ,string note)
        {
            Category c = new() { Name = name ,Notes=note };
            await _db.Categories.AddAsync(c);
            _db.SaveChanges();
            return Ok(c);
        }
        [HttpPut]
        public async Task<IActionResult> editcategory(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (c == null)
            {

                return NotFound();
            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(c);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecategory(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> editcategorypath([FromBody] JsonPatchDocument<Category> cate, [FromRoute] int id)
        {
            {
                var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
                if (c == null)
                {

                    return NotFound();
                }
                cate.ApplyTo(c);
                await _db.SaveChangesAsync();
                _db.SaveChanges();
                return Ok(c);

            }

        }
    }
}
