using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Interfaces
{
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request); //Ne vraca nista
    }

    public interface ICommand<TRequest, TResult>
    {
        TResult Execute(TRequest request); //Vraca TResult u odnosu sta trazi TRequest
    }

}
