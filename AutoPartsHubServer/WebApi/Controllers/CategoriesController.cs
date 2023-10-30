using DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories(int? mainCategoryId = null, CancellationToken cancellationToken = default)
    {
        var response = await _context.Categories.Where(p => p.MainCategoryId == mainCategoryId).OrderBy(o => o.Name).ToListAsync(cancellationToken);
        return Ok(response);
    }
}