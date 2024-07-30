using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vehicle_Backend.Models;
using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly Context _context;

        public VehicleController(Context context)
        {
            _context = context;
        }

        
        
    }
}
