using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TasaDeInteresSimple : Credito
    {
        public TasaDeInteresSimple()
        {
        }

        public TasaDeInteresSimple(string identificacion, string tipoCredito, double capitalInicial, double tasa, double tiempo, double capitalFinal) : base(identificacion, tipoCredito, capitalInicial, tasa, tiempo, capitalFinal)
        {
        }

        public override void CalcularInteres()
        {
            CapitalFinal = CapitalInicial * ((1) + (TasaInteres*Tiempo));
        }
    }
}
