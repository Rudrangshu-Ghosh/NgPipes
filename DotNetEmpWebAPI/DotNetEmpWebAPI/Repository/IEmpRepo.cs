namespace DotNetEmpWebAPI.Repository
{
	public interface IEmpRepo<EmpTable>
	{
		List<EmpTable> GetAll();
		EmpTable GetById(int id);
		void DeleteById(int id);
		void AddEmp(EmpTable emp);
		void EditEmp(int id, EmpTable emp);
	}
}
