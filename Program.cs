using System;

namespace TrianguloPascal
{
    class Program
    {
        private readonly int baseTriangulo;
        private readonly int[,] trianguloPascalNumeros;

        public Program(int baseTriangulo){
            this.baseTriangulo = baseTriangulo;
            this.trianguloPascalNumeros = creaArreglo(this.baseTriangulo);
            imprimir(generaString(this.trianguloPascalNumeros));
        }

        private int[,] creaArreglo(int baseTriangulo) {
            int[,] numerosTriangulo = new int [baseTriangulo,baseTriangulo];
            int numUno;
            int numDos;
            for (int y = 0; y < numerosTriangulo.GetLength(1); y++) {
                if (y == 0) {
                    numerosTriangulo[0,0] = 1; 
                } else if (y==1) {
                    numerosTriangulo[0,1] = 1;
                    numerosTriangulo[1,1] = 1;
                } else {
                    int x = 0;
                    numerosTriangulo[x,y] = 1;
                    x++;
                    for (int i = x; i < y; i++) {
                        numUno = numerosTriangulo[x-1,y-1];
                        numDos = numerosTriangulo[x,y-1];
                        numerosTriangulo[x,y] = numUno + numDos;
                        x++;
                    }
                    numerosTriangulo[x,y] = 1;
                }
            }
            return numerosTriangulo;
        }

        private string[] generaString(int[,] arreglo) {
            string cadena;
            string[] respuesta = new string[arreglo.GetLength(1)];
            for (int y = 0; y < arreglo.GetLength(1); y++) {
                cadena = "";                
                for (int x = 0; x < arreglo.GetLength(0); x++ ){
                    if (arreglo[x,y] > 0 && x < y) {
                        cadena += arreglo[x,y] + " ";
                    } else if (arreglo[x,y] > 0) {
                        cadena += arreglo[x,y];
                    }
                }
                respuesta[y] = cadena;
            }
            return respuesta;
        }

        private string repiteEspacios(int num) {
            string respuesta = "";
            for (int rep = 0; rep < num; rep++) {
                respuesta += " ";
            }
            return respuesta;
        }

        private void imprimir(string[] lineas) {
            int anchoMaximo = lineas[lineas.Length-1].Length;
            int espacios = anchoMaximo/2;
            for (int i = 0; i < lineas.Length; i++) {              
                if (i > 0) {
                    espacios = espacios - ((lineas[i].Length 
                               - lineas[i-1].Length)/2);
                }                     
                Console.WriteLine(repiteEspacios(espacios) + lineas[i]);
            }          
        }

        static void Main(string[] args)
        {
            int baseTriangulo = 0;
            Console.Write("¿De cuanto será la base de tu triángulo de " + 
                                "Pascal? ");
            try {
                baseTriangulo = Int16.Parse(Console.ReadLine());
                if (baseTriangulo>1){
                    Console.WriteLine();
                    // Construye e imprime el triángulo.
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Program triangulo = new Program(baseTriangulo);                    
                    // Fin de construcción del triángulo.
                    Console.WriteLine();
                } else {
                    throw new Exception();
                }
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lo siento debe de ser un número entero y " 
                                    + "mayor a uno. Intenta para la próxima" + 
                                    "...");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Presiona la tecla enter para salir...");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
