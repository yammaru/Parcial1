using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TasaDeInteresCompuesto : Credito
    {
        
        public override void CalcularInteres()
        {
            CapitalFinal = CapitalInicial /Math.Pow((1 + TasaInteres), Tiempo);
        }
        public TasaDeInteresCompuesto()
        {

        }

        public TasaDeInteresCompuesto(string identificacion, string tipoCredito, double capitalInicial, double tasa, double tiempo, double capitalFinal) : base(identificacion, tipoCredito, capitalInicial, tasa, tiempo, capitalFinal)
        {
        }
    }
}
