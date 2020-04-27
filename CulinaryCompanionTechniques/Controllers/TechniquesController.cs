using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CulinaryCompanionTechniques.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechniquesController : ControllerBase
    {
        [HttpGet]
        public string Get(string search)
        {
            try
            {
                var techniques = new List<string>();
                techniques.Add(search);

                var retrieveTechnique = new RetrieveTechniques();
                var Techniquefound = retrieveTechnique.retrieve(search);
                return Techniquefound;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
