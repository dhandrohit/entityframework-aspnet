using ASPNETCore6.Models;
using System.Collections;

namespace ASPNETCore6
{
    public interface IDeptRepository
    {
        IEnumerable<TestDept> GetAllDepts();
        List<TestDept> GetAllDeptsByStoredProcedure();
        List<EFDeptModel> GetAllDeptsCustomStoredProcedure();


    }
}
