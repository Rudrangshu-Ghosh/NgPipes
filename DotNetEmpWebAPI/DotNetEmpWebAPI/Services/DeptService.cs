using DotNetEmpWebAPI.Models;
using DotNetEmpWebAPI.Repository;

namespace DotNetEmpWebAPI.Services
{
	public class DeptService: IDeptService<DeptTable>
	{
		private readonly IDeptRepo<DeptTable> _repo;

		public DeptService(IDeptRepo<DeptTable> repo)
		{
			_repo = repo;
		}
		public void AddDept(DeptTable dept)
		{
			_repo.AddDept(dept);
		}

		public void DeleteById(int id)
		{
			_repo.DeleteById(id);
		}

		public void EditDept(int id, DeptTable dept)
		{
			_repo.EditDept(id, dept);
		}

		public List<DeptTable> GetAll()
		{
			return _repo.GetAll();
		}

		public DeptTable GetById(int id)
		{
			return _repo.GetById(id);
		}
	}
}
