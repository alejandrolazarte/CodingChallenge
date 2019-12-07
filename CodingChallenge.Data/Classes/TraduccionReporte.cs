using System.Collections.Generic;

namespace CodingChallenge.Data.Classes
{
    public class TraduccionReporte
    {
        public long Id { get; set; }
        public string Idioma { get; set; }
        public string ListaVacia { get; set; }
        public string Header { get; set; }
        public string Forma { get; set; }
        public string Perimetro { get; set; }

        //Propiedades de navegacion
        public ICollection<TraduccionForma> TraduccionFormas {get; set; }
    }
}
