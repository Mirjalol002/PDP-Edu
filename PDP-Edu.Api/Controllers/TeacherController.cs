using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models.Teacher;

namespace PDP_Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherModel updateTeacher)
        {
            await _service.UpdateAsync(updateTeacher);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}