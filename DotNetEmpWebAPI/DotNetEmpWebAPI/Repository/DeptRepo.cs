using DotNetEmpWebAPI.Models;

namespace DotNetEmpWebAPI.Repository
{
	public class DeptRepo: IDeptRepo<DeptTable>
	{
		private readonly EmpDbContext _context;

		public DeptRepo(EmpDbContext context)
		{
			_context = context;
		}

		public void AddDept(DeptTable dept)
		{
			_context.DeptTables.Add(dept);
			_context.SaveChanges();
		}

		public void DeleteById(int id)
		{
			DeptTable d = _context.DeptTables.Find(id);
			_context.DeptTables.Remove(d);
			_context.SaveChanges();
		}

		public void EditDept(int id, DeptTable dept)
		{
			_context.DeptTables.Update(dept);
			_context.SaveChanges();
		}

		public List<DeptTable> GetAll()
		{
			return _context.DeptTables.ToList();
		}

		public DeptTable GetById(int id)
		{
			var c = _context.DeptTables.Where(x => x.DeptId == id).SingleOrDefault();
			return c;
		}
	}
}
