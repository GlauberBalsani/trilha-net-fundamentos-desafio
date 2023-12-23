using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Domain.Services
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base (message) {}
    }
}