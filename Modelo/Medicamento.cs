using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento : Entity
    {
        public string NombreComercial { get; set; }
        public bool EsVentaLibre { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        public List<Drogueria> Droguerias { get; set; }

        public Medicamento()
        {
            Droguerias = new List<Drogueria>();
        }


        public bool AgregarDrogueria(Drogueria nuevaDrogueria)
        {
            var dDupl = Droguerias.FirstOrDefault(z => z.Id == nuevaDrogueria.Id);
            if (dDupl == null)
            {
                Droguerias.Add(nuevaDrogueria);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarDrogueria(Drogueria DrogueriaAEliminar)
        {
            var dDupl = Droguerias.FirstOrDefault(z => z.Id == DrogueriaAEliminar.Id);
            if (dDupl != null)
            {
                Droguerias.Remove(DrogueriaAEliminar);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return Droguerias.AsReadOnly();
        }
    }
}
