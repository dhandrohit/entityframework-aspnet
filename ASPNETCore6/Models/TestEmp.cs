using System;
using System.Collections.Generic;

namespace ASPNETCore6.Models
{
    public partial class TestEmp
    {
        public int Id { get; set; }
        public string? EmpName { get; set; }
        public string? Job { get; set; }
        public int? TestDeptId { get; set; }

        public virtual TestDept? TestDept { get; set; }
    }
}
