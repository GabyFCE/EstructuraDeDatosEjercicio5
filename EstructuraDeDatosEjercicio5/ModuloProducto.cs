using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatosEjercicio5
{
    internal class ModuloProducto
    {
        internal static void Alta()
        {
            List<ProductoEnt> productos = new List<ProductoEnt>();
            List<ComponenteEnt> componentesPrueba = new List<ComponenteEnt>();

            while (true)
            {

                ComponenteEnt componentePrueba = IngresarComponentePrueba();
                componentesPrueba.Add(componentePrueba);
                Console.WriteLine("Se ha agregado un nuevo coponente de prueba");
                Console.WriteLine($"Cantidad: {componentesPrueba.Count}");

                Console.WriteLine("¿Desea continuar agregando coponentes de prueba? [S/N]");
                string continuar = null;
                while (continuar != "S" && continuar != "N")
                {
                    continuar = Console.ReadLine();
                }

                if (continuar == "N")
                {
                    break;
                }

                ComponenteEnt IngresarComponentePrueba()
                {

                    ComponenteEnt componentePr = new ComponenteEnt();
                    while (true)
                    {
                        Console.WriteLine("Proceso de ingreso del componente de prueba");
                        componentePr.Codigo = Ingreso.Cadena("código del componente", 6, 6, soloLetras: false);

                        if (!componentePr.ValidarComponente(out string errorComponente))
                        {
                            Console.WriteLine(errorComponente);
                            continue;
                        }
                        break;

                    }
                    return componentePr;
                }

            }



            while (true)
            {
                //1) Pedir los datos para construir un objeto auto
                //2) agregarlo a la lista
                //3)preguntarle al usuario si quiere seguir o no,
                //4)si no, por ahora terminamos.
                //5)si si, seguimos

                ProductoEnt nuevoProducto = IngresarProducto();
                productos.Add(nuevoProducto);
                ProductoArchivo.AgregarProducto(nuevoProducto);
                Console.WriteLine("Se ha agregado un nuevo producto.");
                Console.WriteLine($"Cantidad: {productos.Count}");
                Console.WriteLine("¿Desea continuar agregando productos? [S/N]");
                string continuar = null;
                while (continuar != "S" && continuar != "N")
                {
                    continuar = Console.ReadLine();
                }

                if (continuar == "N")
                {
                    break;
                }
            }

            ProductoEnt IngresarProducto()
            {
                ProductoEnt producto = new ProductoEnt();

                while (true)
                {
                    Console.WriteLine("Proceso de ingreso de producto");
                    //Código
                    producto.Codigo = Ingreso.Cadena("el código", 6, 6, soloLetras:false);

                    //Nombre corto
                    producto.NombreCorto = Ingreso.Cadena("el nombre corto", 1, 15, soloLetras:true);

                    //Descripcion
                    producto.Descripcion = Ingreso.Cadena("descripcion", 1, 200,soloLetras:true);

                    //Costo
                    producto.Costo = Ingreso.Decimal("el costo", 1, null);

                    //Precio
                    producto.Precio = Ingreso.Decimal("el precio", 1, null);

                    //componentes
                    List<ComponenteEnt> componentes = new List<ComponenteEnt>();
                    while (true)
                    {

                        string respuesta;
                        ComponenteEnt componente = IngresarComponente();
                        componentes.Add(componente);
                        Console.WriteLine("Tiene más componentes para ingresar[S/N]");
                        respuesta = Console.ReadLine();
                        while (respuesta != "S" && respuesta != "N")
                        {
                            respuesta = Console.ReadLine();
                        }
                        if (respuesta == "N")
                        {
                            break;
                        }

                    }
                    producto.Componentes = componentes;



                    if (!producto.ValidarProducto(out string error))
                    {
                        Console.WriteLine(error);
                        continue;
                    }

                    break;
                }

                return producto;
            }

            ComponenteEnt IngresarComponente()
            {

                ComponenteEnt componente = new ComponenteEnt();
                while (true)
                {

                    Console.WriteLine("Proceso de ingreso del componente");
                    componente.Codigo = Ingreso.Cadena("código del componente", 6, 6, soloLetras: false);

                    foreach(ComponenteEnt c in componentesPrueba)
                    {
                        int i = 0;
                        if(componente.Codigo == c.Codigo)
                        {
                            i++;
                        }
                        if(i == 0)
                        {
                            Console.WriteLine("Debe existir el código");
                            continue;

                        }
                    }

                    if (!componente.ValidarComponente(out string errorComponente))
                    {
                        Console.WriteLine(errorComponente);
                        continue;
                    }
                    break;

                }

                return componente;

            }

        }

        internal static void Baja()
        {
            throw new NotImplementedException();
        }

        internal static void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
