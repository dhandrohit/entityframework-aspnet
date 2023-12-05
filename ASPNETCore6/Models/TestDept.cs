using System;
using System.Collections.Generic;

namespace ASPNETCore6.Models
{
    public partial class TestDept
    {
        public TestDept()
        {
            TestEmps = new HashSet<TestEmp>();
        }

        public int Id { get; set; }
        public string? Dname { get; set; }
        public string? Loc { get; set; }

        public virtual ICollection<TestEmp> TestEmps { get; set; }
    }
}
