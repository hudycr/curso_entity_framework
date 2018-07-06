using SoccerApp.Data;
using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Services
{
    public class DirectiveService
    {
        private SoccerAppContext ctx;

        public DirectiveService(SoccerAppContext context)
        {
            this.ctx = context ?? new SoccerAppContext();
        }

        public void Insert(Directive directive)
        {
            #region validaciones
            var directivoRepetido = ctx.Directives
                .FirstOrDefault(i => i.Name == directive.Name);
            if (directivoRepetido != null)
                throw new Exception("El nombre del directivo está repetido");
            #endregion

            ctx.Directives.Add(directive);
            ctx.SaveChanges();
        }
    }
}
