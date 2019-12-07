using System;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }
    }
}
