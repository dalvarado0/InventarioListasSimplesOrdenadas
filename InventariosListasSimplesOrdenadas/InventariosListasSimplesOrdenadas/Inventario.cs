using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventariosListasSimplesOrdenadas
{
    class Inventario
    {
        private Producto inicio;

        public void agregar(Producto nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
            {
                if (nuevo.codigo < inicio.codigo)
                {
                    nuevo.siguiente = inicio;
                    inicio = nuevo;
                }
                else
                {
                    Producto temp = inicio;
                    while (temp.siguiente != null && temp.siguiente.codigo < nuevo.codigo)
                        temp = temp.siguiente;
                    nuevo.siguiente = temp.siguiente;
                    temp.siguiente = nuevo;
                }
            }
        }

        public Producto buscar(int codigo)
        {
            Producto item = null, temp = inicio;
            while (temp.siguiente != null)
            {
                if (temp.codigo == codigo)
                {
                    return temp;
                }
                if (temp.siguiente.codigo == codigo)
                    item = temp.siguiente;
                temp = temp.siguiente;
            }
            return item;
        }

        public void borrar(int codigo)
        {
            Producto temp = inicio;
            while (temp.siguiente != null)
            {
                if (temp.codigo == codigo)
                {
                    inicio = temp.siguiente;
                    temp = inicio;
                }
                else
                {
                    if (temp.siguiente.codigo == codigo)
                    {
                        temp.siguiente = temp.siguiente.siguiente;
                        break;
                    }
                    temp = temp.siguiente;
                }
            }
        }

        public string reporte()
        {
            string datos = "";
            Producto t = inicio;
            while (t != null)
            {
                datos += t.ToString() + Environment.NewLine;
                t = t.siguiente;
            }
            return datos;
        }

        public string reporteInvertido()
        {
            string reporte = "";
            Producto temp = inicio;
            if (temp == null)
                return reporte;
            else
                return reporteInv(temp);
        }

        private string reporteInv(Producto item)
        {
            if (item.siguiente == null)
                return item.ToString() + Environment.NewLine;
            else
            {
                return reporteInv(item.siguiente) + item.ToString() + Environment.NewLine;
            }
        }
    }
}
