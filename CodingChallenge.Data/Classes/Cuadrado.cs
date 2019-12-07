namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public override decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
