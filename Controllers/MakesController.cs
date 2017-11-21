using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Context;
using Udemy.Controllers.Resources;
using Udemy.Models;

namespace Udemy.Controllers
{
    [Route("api/makes")]
    public class MakesController : Controller
    {
        private readonly UdemyContext context;
        private readonly IMapper mapper;

        public MakesController(UdemyContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<MakeResource>> getMakes()
        {   var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}