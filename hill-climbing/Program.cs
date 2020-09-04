using System;
using System.Collections.Generic;
using System.Linq;

namespace hill_climbing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Minimizando z = x2 + y2
            //limites entre -5 y 5
            int maxRepeticiones=31;
            var listaFitness= new List<double>();
            for (var rep=0; rep<maxRepeticiones;rep++){

         
            Random aleatorio = new Random(rep);
            int dimensiones=2;
            double limInferior=-5;
            double limSuperior=5;
            int maxIteraciones=10000;
            double ajuste=0.01;
            double[] solucion = new double[dimensiones];
            double fitness=0;
            for(int d = 0; d < dimensiones;d++){
                solucion[d]=limInferior + (limSuperior-limInferior)*aleatorio.NextDouble();
            }
            for(int d = 0; d < dimensiones;d++){
                fitness+= Math.Pow(solucion[d],2);
            }
            
            for(var iter=1; iter<maxIteraciones;iter++){
                double[] r = new double[dimensiones];
                for(int d = 0; d < dimensiones;d++){
                    r[d]=solucion[d];
                }
                for(int d = 0; d < dimensiones;d++){
                    r[d]=r[d] +(-1*ajuste + 2*ajuste * aleatorio.NextDouble());
                }
                double fr=0;
                for(int d=0; d<dimensiones;d++){
                    fr+=Math.Pow(r[d],2);
                }
                if(fr<fitness){
                    for(int d=0; d<dimensiones;d++){
                        solucion[d]=r[d];
                    }
                    fitness=fr;
                }
            }
            // for(int d=0;d<dimensiones;d++){
            //     Console.WriteLine("Dimensiones "+ d +"="+solucion[d]);
            // }
            Console.WriteLine("Fitness de repeticion "+rep+" "+fitness);
            listaFitness.Add(fitness);
        }
        Console.WriteLine("El promedio de fitness= "+ listaFitness.Average());
        }
    }
}