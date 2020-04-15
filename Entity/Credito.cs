using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Credito
    {
        public string Identificacion { get; set; }
        public string TipoCredito { get; set; }
        public double CapitalInicial { get;set; }
        public double TasaInteres { get; set; }
        public double Tiempo { get; set; }
        public  double CapitalFinal { get; set; }
        public Credito()
        {

        }
        public Credito(string identificacion, string tipoCredito,double capitalInicial, double tasa, double tiempo, double capitalFinal)
        {
            Identificacion = identificacion;
            TipoCredito = tipoCredito;
            CapitalInicial = capitalInicial;
            TasaInteres = tasa;
            Tiempo = tiempo;
            CapitalFinal = capitalFinal;
        }
        public abstract void CalcularInteres();

        public override string ToString()
        {
            return $"{Identificacion};{TipoCredito};{CapitalInicial};{TasaInteres};{Tiempo};{CapitalFinal}";
        }
    }
}
