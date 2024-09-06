using DotNetEmpWebAPI.Models;

namespace DotNetEmpWebAPI.Repository
{
	public class EmpRepo: IEmpRepo<EmpTable>
	{
		private readonly EmpDbContext _context;

		public EmpRepo(EmpDbContext context)
		{
			_context = context;
		}

		public void AddEmp(EmpTable emp)
		{
			_context.EmpTables.Add(emp);
			_context.SaveChanges();
		}

		public void DeleteById(int id)
		{
			EmpTable e = _context.EmpTables.Find(id);
			_context.EmpTables.Remove(e);
			_context.SaveChanges();
		}

		public void EditEmp(int id, EmpTable emp)
		{
			_context.EmpTables.Update(emp);
			_context.SaveChanges();
		}

		public List<EmpTable> GetAll()
		{
			return _context.EmpTables.ToList();
		}

		public EmpTable GetById(int id)
		{
			var e = _context.EmpTables.Where(x => x.Eid == id).SingleOrDefault();
			return e;
		}
	}
}
