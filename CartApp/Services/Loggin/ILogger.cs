using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Services.Loggin
{

    public interface ILogger
    {
        void Info(string mensaje);
        void Error(string mensaje);
    }
}