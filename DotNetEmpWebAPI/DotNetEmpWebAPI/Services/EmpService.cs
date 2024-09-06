using DotNetEmpWebAPI.Models;
using DotNetEmpWebAPI.Repository;

namespace DotNetEmpWebAPI.Services
{
	public class EmpService: IEmpService<EmpTable>
	{
		private readonly IEmpRepo<EmpTable> _repo;

		public EmpService(IEmpRepo<EmpTable> repo)
		{
			_repo = repo;
		}
		public void AddEmp(EmpTable emp)
		{
			_repo.AddEmp(emp);
		}

		public void DeleteById(int id)
		{
			_repo.DeleteById(id);
		}

		public void EditEmp(int id, EmpTable emp)
		{
			_repo.EditEmp(id, emp);
		}

		public List<EmpTable> GetAll()
		{
			return _repo.GetAll();
		}

		public EmpTable GetById(int id)
		{
			return _repo.GetById(id);
		}
	}
}
