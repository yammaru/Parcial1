using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
namespace BLL
{
    public class CreditoService
    {
        CreditoRepository creditoRepository;
        public CreditoService()
        {
            creditoRepository = new CreditoRepository();
        }
        public string Guardar(Credito credito)
        {
            try
            {
                if (creditoRepository.Buscar(credito.Identificacion)!=null)
                {
                    creditoRepository.Guardar(credito);
                    return $" se Guardó {credito.Identificacion} con su tasa XD.(-_-)";
                }
                return $"{credito.Identificacion} ya existe";

            }
            catch (Exception e)
            {

                return "Error de guardadoooooooooo"+e.Message;
            }

        }
        public List<Credito> Consultar()
        {
            return creditoRepository.Consultar();
        }

        public string Eliminar(string id)
        {
            try
            {
                Credito credito = creditoRepository.Buscar(id);
                if (credito!=null)
                {
                    creditoRepository.Eliminar(id);
                    return "Se muirooooooooooo";
                }
                return "no se elimino :V";
            }
            catch (Exception e)
            {

                return " Error al eliminar" + e.Message;
            }
        }
        public string modificar(Credito credito)
        {
            try
            {
                creditoRepository.Modificar(credito);
                return "se modifico";
            }
            catch (Exception e)
            {

                return "Errrooopooor" + e.Message;
            }
        }
    }
}
