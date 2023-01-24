using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _contex;

        public ApiBeerController(PubContext context)
        {
            _contex = context;
        }

       // [HttpGet]
        public async Task<List<BeerBrandViewModel>> Get()
        
            => await _contex.Beers.Include(b => b.Brand)
                .Select(b=>new BeerBrandViewModel
                {
                    Name=b.Name,
                    Brand=b.Brand.Name,
                })
                .ToListAsync();
        
    }
}
