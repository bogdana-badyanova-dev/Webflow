using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.SkillsService.Interfaces;

namespace Webflow.API.Controllers.Skills
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class SkillsController : ControllerBase
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }
    }
}
