﻿using SoccerApp.Data;
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
        private SoccerAppContext ctx;

        public StaffService(SoccerAppContext context)
        {
            this.ctx = context ?? new SoccerAppContext();
        }

        public void Insert(Staff staff)
        {
            #region validaciones
            var staffRepetidos = from s in ctx.Staffs
                                where s.Name == staff.Name
                                select s;

            if (staffRepetidos.Count() > 0)
                throw new Exception("El nombre del staff ya existe");
            #endregion

            ctx.Staffs.Add(staff);
            ctx.SaveChanges();
        }
    }
}
