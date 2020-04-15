using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;

namespace DAL
{
    public class CreditoRepository
    {
        string ruta=@"Archivo.txt";
        List<Entity.Credito> creditos;

        public CreditoRepository()
        {
            creditos = new List<Entity.Credito>();
        }
        public void Guardar(Entity.Credito credito)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(credito.ToString());
            writer.Close();
            fileStream.Close();
        }
        public List<Entity.Credito> Consultar()
        {
            creditos.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            string line = string.Empty;
            while ((line=reader.ReadLine())!=null)
            {
                Entity.Credito credito = Map(line);
                creditos.Add(credito);
            }
            fileStream.Close();
            reader.Close();
            return creditos;
        }

        private Entity.Credito Map(string line)
        {
            string[] vs = line.Split(';');
            if (vs[1]=="Simple")
            {
                Entity.TasaDeInteresSimple simple = new TasaDeInteresSimple();
                simple.Identificacion = vs[0];
                simple.TipoCredito = vs[1];
                simple.CapitalInicial = double.Parse(vs[2]);
                simple.TasaInteres = double.Parse(vs[3]);
                simple.Tiempo = double.Parse( vs[4]);
                simple.CapitalFinal = double.Parse(vs[5]);
                return simple;
            }
            else
            {
                Entity.TasaDeInteresCompuesto compuesto = new TasaDeInteresCompuesto();
                compuesto.Identificacion = vs[0];
                compuesto.TipoCredito = vs[1];
                compuesto.CapitalInicial = double.Parse(vs[2]);
                compuesto.TasaInteres = double.Parse(vs[3]);
                compuesto.Tiempo = double.Parse(vs[4]);
                compuesto.CapitalFinal = double.Parse(vs[5]);
                return compuesto;
            }
        }
        public void Eliminar(string id) 
        {
            creditos.Clear();
            creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.Identificacion != id)
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(Entity.Credito credito)
        {
            creditos.Clear();
            creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.Identificacion != credito.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(credito);
                }
            }
        }
        public Entity.Credito Buscar(string id)
        {
            creditos.Clear();
            creditos = Consultar();
            foreach (var item in creditos)
            {
                if (item.Identificacion == id)
                {
                   return item;
                }
            }
            return null;
        }


    }
}
