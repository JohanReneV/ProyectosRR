using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    public class NotaInvalidaException : Exception
    {
        public NotaInvalidaException(string mensaje) : base(mensaje)
        {
        }
    }

}

