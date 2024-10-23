using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Drogueria : Entity
    {
        public int Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Cuit.ToString();
        }
    }
}
