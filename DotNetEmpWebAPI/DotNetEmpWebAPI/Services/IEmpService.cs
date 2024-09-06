namespace DotNetEmpWebAPI.Services
{
	public interface IEmpService<EmpTable>
	{
		List<EmpTable> GetAll();
		EmpTable GetById(int id);
		void DeleteById(int id);
		void AddEmp(EmpTable emp);
		void EditEmp(int id, EmpTable emp);
	}
}
