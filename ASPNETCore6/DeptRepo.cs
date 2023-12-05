using ASPNETCore6.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ASPNETCore6
{
    public class DeptRepo : IDeptRepository
    {
        LovelyContext _lovelyContext; 
        LovelySPContext _lovelySPContext;
        public DeptRepo(LovelyContext lovelyContext, LovelySPContext lovelySPContext)
        {
            _lovelyContext = lovelyContext;
            _lovelySPContext = lovelySPContext;
        }
        public IEnumerable<TestDept> GetAllDepts()
        {
            //return _lovelyContext.TestDepts.ToList();
            var depts = _lovelyContext.TestDepts.Include(x => x.TestEmps)
                    .Where(x => x.Id == 1)
                    .ToList();
            return depts;
            //return _lovelyContext.TestDepts.Include(dept => dept.TestEmp);
        }

        public List<TestDept> GetAllDeptsByStoredProcedure()
        {
          
            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@vDeptId", Value = 1 }
            };

            //list = _db.Products.FromSqlRaw<Product>(sql, parms.ToArray()).ToList();
            var result = _lovelyContext.TestDepts.FromSqlRaw("Execute dbo.spGetAllTestDepts @vDeptId", parms.ToArray()).ToList();
            return result.ToList();

        }
        public List<EFDeptModel> GetAllDeptsCustomStoredProcedure()
        {
            var result = _lovelySPContext.EFDepts.FromSqlRaw("Execute spGetAllTestDepts").ToList();
            return result;
        }
    }

}
