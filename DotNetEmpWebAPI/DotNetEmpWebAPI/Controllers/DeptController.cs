using DotNetEmpWebAPI.Models;
using DotNetEmpWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetEmpWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DeptController : ControllerBase
	{
		private readonly IDeptService<DeptTable> _service;

		public DeptController(IDeptService<DeptTable> service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<DeptTable>>> GetAll()
		{
			return Ok(_service.GetAll());
		}

		[HttpPost]
		public async Task<ActionResult> AddDept(DeptTable dept)
		{
			if (ModelState.IsValid)
			{
				_service.AddDept(dept);
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DeptTable>> GetById(int id)
		{
			return Ok(_service.GetById(id));
		}


		[HttpPut("{id}")]
		public async Task<ActionResult> EditDept(int id, DeptTable dept)
		{
			if (ModelState.IsValid)
			{
				_service.EditDept(id, dept);
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteById(int id)
		{
			if (ModelState.IsValid)
			{
				_service.DeleteById(id);
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
