using SoccerApp.Data;
using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Services
{
    public class StaffService
    {
        public void Insert(Staff staff)
        {
            using(var ctx = new SoccerAppContext())
            {
                ctx.Staffs.Add(staff);
                ctx.SaveChanges();
            }
        }
    }
}
