using DotNetEmpWebAPI.Models;
using DotNetEmpWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetEmpWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpController : ControllerBase
	{
		private readonly IEmpService<EmpTable> _service;

		public EmpController(IEmpService<EmpTable> service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<EmpTable>>> GetAll()
		{
			return Ok(_service.GetAll());
		}

		[HttpPost]
		public async Task<ActionResult> AddEmp(EmpTable emp)
		{
			if (ModelState.IsValid)
			{
				_service.AddEmp(emp);
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		
		public async Task<ActionResult<EmpTable>> GetById(int id)
		{
			return Ok(_service.GetById(id));
		}


		[HttpPut("{id}")]
		public async Task<ActionResult> EditEmp(int id, EmpTable emp)
		{
			if (ModelState.IsValid)
			{
				_service.EditEmp(id, emp);
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
