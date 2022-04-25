using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGames.Entities.ViewTools
{
    public class ValidationResponse<T> 
    {
        public bool HasError { get; set; }
        public string? Error { get; set; }
        public string? ExcepcionMessage { get; set; }
        public T? Entity { get; set; }
    }
}
