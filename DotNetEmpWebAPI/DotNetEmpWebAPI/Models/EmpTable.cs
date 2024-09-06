using System;
using System.Collections.Generic;

namespace DotNetEmpWebAPI.Models;

public partial class EmpTable
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public int? Salary { get; set; }

    public DateOnly? Doj { get; set; }

    public int? DeptId { get; set; }

    public virtual DeptTable? Dept { get; set; }
}
