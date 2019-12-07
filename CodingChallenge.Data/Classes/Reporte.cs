using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public static class Reporte
    {
        public static string Imprimir(List<FormaGeometrica> formas, TraduccionReporte traduccion)
        {
            var sb = new StringBuilder();

            if (!formas.Any()) return sb.Append(traduccion.ListaVacia).ToString();

            sb.Append(traduccion.Header);

            sb.Append(ObtenerLinea(formas.OfType<Cuadrado>().ToList(), traduccion));
            sb.Append(ObtenerLinea(formas.OfType<Circulo>().ToList(), traduccion));
            sb.Append(ObtenerLinea(formas.OfType<TrianguloEquilatero>().ToList(), traduccion));
            sb.Append(ObtenerLinea(formas.OfType<Trapecio>().ToList(), traduccion));
            sb.Append(ObtenerLinea(formas.OfType<Rectangulo>().ToList(), traduccion));

            // FOOTER
            sb.Append("TOTAL:<br/>");
            sb.Append($"{formas.Count} {traduccion.Forma} ");
            sb.Append($"{traduccion.Perimetro} {(formas.Sum(x => x.CalcularPerimetro())):#.##} ");
            sb.Append($"Area {(formas.Sum(x => x.CalcularArea())):#.##}");


            return sb.ToString();
        }

        private static string ObtenerLinea(IReadOnlyCollection<FormaGeometrica> formas, TraduccionReporte traduccion)
        {
            return formas.Any() ?
                $"{formas.Count} {TraducirForma(formas.First().GetType().Name, formas.Count, traduccion)} | Area {formas.Sum(x => x.CalcularArea()):#.##} | {traduccion.Perimetro} {formas.Sum(x => x.CalcularPerimetro()):#.##} <br/>"
                : string.Empty;
        }

        private static string TraducirForma(string tipo, int cantidad, TraduccionReporte traduccion)
        {
            var traduccionForma = traduccion.TraduccionFormas.FirstOrDefault(x => x.FormaGeometrica == tipo);
            if (traduccionForma == null) return string.Empty;
            return cantidad == 1 ? traduccionForma.Singular : traduccionForma.Plural;
        }

    }
}
