using DotNetEmpWebAPI.Models;

namespace DotNetEmpWebAPI.Repository
{
	public interface IDeptRepo<DeptTable>
	{
		List<DeptTable> GetAll();
		DeptTable GetById(int id);
		void DeleteById(int id);
		void AddDept(DeptTable dept);
		void EditDept(int id, DeptTable dept);
	}
}
