using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfCommands
{
    public abstract class EFBaseCommand
    {
        protected ProjekatASPContext Context { get; } //mogu da ga koriste samo klase koje ga nasledjuju

        protected EFBaseCommand(ProjekatASPContext context) => Context = context;
    }
}
