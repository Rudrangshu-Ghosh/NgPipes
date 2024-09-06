using System;
using System.Collections.Generic;

namespace DotNetEmpWebAPI.Models;

public partial class DeptTable
{
    public int DeptId { get; set; }

    public string? Dname { get; set; }

    public string? Dcity { get; set; }

    public virtual ICollection<EmpTable> EmpTables { get; set; } = new List<EmpTable>();
}
