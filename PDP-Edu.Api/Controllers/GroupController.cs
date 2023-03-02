using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models;
using PDP_Edu.Application.Models.Group;

namespace PDP_Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateGroupModel model)
        {
            await _groupService.CreateAsync(model);
            return Ok();
        }

        [HttpGet("Id")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAllAsync());
        }
        [HttpGet("{gorupId/lessons}")]
        [Authorize]
        public async Task<IActionResult> GetLessons(int groupId)
        {
            return Ok(await _groupService.GetLessonAsync(groupId));
        }

        [HttpPut]
        [Authorize(Policy ="AdminActions")]
        public async Task<IActionResult> Update(UpdateGroupModel updateGroupModel)
        {
            await _groupService.UpdateAsync(updateGroupModel);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy ="AdminActions")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost("{groupId}/student")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> AddStudent([FromRoute] int groupId, AddStudentGroupModel model)
        {
            await _groupService.AddStudentAsync(model, groupId);

            return Ok();
        }

        [HttpDelete("{groupId}/student")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> RemoveStudent([FromRoute] int groupId, [FromBody] int studentId)
        {
            await _groupService.RemoveStudentAsync(studentId, groupId);
            return Ok();
        }
    }
}
