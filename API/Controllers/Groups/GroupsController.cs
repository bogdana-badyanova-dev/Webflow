using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.GroupsService.Interfaces;

namespace Webflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class GroupsController : ControllerBase
    {
        private readonly IGroupsService groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            this.groupsService = groupsService;
        }
    }
}
