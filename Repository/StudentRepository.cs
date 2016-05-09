using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(BusinessDbContext db) : base(db)
        {

        }
    }
}
