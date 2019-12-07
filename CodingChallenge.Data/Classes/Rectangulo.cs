namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        public decimal Lado2 { get; set; }

        public override decimal CalcularArea()
        {
            return Lado * 2 + Lado2 * 2;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * Lado2;
        }
    }
}
