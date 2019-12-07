using System;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        public decimal Lado2 { get; set; }
        public decimal BaseMayor { get; set; }
        public decimal BaseMenor { get; set; }
        public decimal Altura { get; set; }

        public override decimal CalcularArea()
        {
            return ((BaseMayor + BaseMenor) * Altura)/2;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado + Lado2 + BaseMayor + BaseMenor;
        }
    }
}
