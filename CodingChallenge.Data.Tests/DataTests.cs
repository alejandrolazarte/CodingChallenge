using CodingChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private readonly List<TraduccionReporte> _traducciones;

        public DataTests()
        {
            //Simula datos de una Base de Datos
            _traducciones = new List<TraduccionReporte>()
            {
                new TraduccionReporte()
                {
                    Idioma = "Castellano",
                    ListaVacia = "<h1>Lista vacía de formas!</h1>",
                    Header = "<h1>Reporte de Formas</h1>",
                    Forma = "formas",
                    Perimetro = "Perimetro",
                    TraduccionFormas = new List<TraduccionForma>()
                    {
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Cuadrado",
                            Singular = "Cuadrado",
                            Plural = "Cuadrados"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Circulo",
                            Singular = "Círculo",
                            Plural = "Círculos"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "TrianguloEquilatero",
                            Singular = "Triángulo",
                            Plural = "Triángulos"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Trapecio",
                            Singular = "Trapecio",
                            Plural = "Trapecios"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Rectangulo",
                            Singular = "Rectangulo",
                            Plural = "Rectangulos"
                        }
                    }
                },
                new TraduccionReporte()
                {
                    Idioma = "Ingles",
                    ListaVacia = "<h1>Empty list of shapes!</h1>",
                    Header = "<h1>Shapes report</h1>",
                    Forma = "shapes",
                    Perimetro = "Perimeter",
                    TraduccionFormas = new List<TraduccionForma>()
                    {
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Cuadrado",
                            Singular = "Square",
                            Plural = "Squares"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Circulo",
                            Singular = "Circle",
                            Plural = "Circles"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "TrianguloEquilatero",
                            Singular = "Triangle",
                            Plural = "Triangles"
                        }
                    }
                },
                new TraduccionReporte()
                {
                    Idioma = "Frances",
                    ListaVacia = "<h1>Liste vide de formes!</h1>",
                    Header = "<h1>Rapport sur les formulaires</h1>",
                    Forma = "des formes",
                    Perimetro = "Périmètre",
                    TraduccionFormas = new List<TraduccionForma>()
                    {
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Cuadrado",
                            Singular = "Carré",
                            Plural = "Carrés"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "Circulo",
                            Singular = "Cercle",
                            Plural = "Cercles"
                        },
                        new TraduccionForma()
                        {
                            FormaGeometrica = "TrianguloEquilatero",
                            Singular = "Triangle",
                            Plural = "Triangles"
                        }
                    }
                }
            };

        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Castellano");
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), traduccion));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Ingles");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), traduccion));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Castellano");

            var cuadrados = new List<FormaGeometrica> { new Cuadrado { Lado = 5 } };

            var resumen = Reporte.Imprimir(cuadrados, traduccion);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Ingles");

            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado{Lado = 5},
                new Cuadrado{Lado = 1},
                new Cuadrado{Lado = 3}
            };

            var resumen = Reporte.Imprimir(cuadrados, traduccion);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Ingles");

            var formas = new List<FormaGeometrica>
            {
                new Cuadrado{Lado = 5},
                new Circulo{Lado = 3},
                new TrianguloEquilatero{Lado = 4},
                new Cuadrado{Lado = 2},
                new TrianguloEquilatero{Lado = 9},
                new Circulo{Lado = 2.75m},
                new TrianguloEquilatero{Lado = 4.2m}
            };

            var resumen = Reporte.Imprimir(formas, traduccion);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Castellano");

            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(){Lado = 5},
                new Circulo(){Lado = 3},
                new TrianguloEquilatero(){Lado = 4},
                new Cuadrado(){Lado = 2},
                new TrianguloEquilatero(){Lado = 9},
                new Circulo(){Lado = 2.75m},
                new TrianguloEquilatero(){Lado = 4.2m}
            };

            var resumen = Reporte.Imprimir(formas, traduccion);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        //Nuevos

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Castellano");

            var cuadrados = new List<FormaGeometrica> { new Trapecio() { Lado = 3,Lado2 = 3,BaseMenor = 4,BaseMayor = 5,Altura = 2.8m} };

            var resumen = Reporte.Imprimir(cuadrados, traduccion);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 12,6 | Perimetro 15 <br/>TOTAL:<br/>1 formas Perimetro 15 Area 12,6", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Castellano");

            var cuadrados = new List<FormaGeometrica> { new Rectangulo() { Lado = 2, Lado2 = 4 }};

            var resumen = Reporte.Imprimir(cuadrados, traduccion);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectangulo | Area 12 | Perimetro 8 <br/>TOTAL:<br/>1 formas Perimetro 8 Area 12", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectanguloFrances()
        {
            var traduccion = _traducciones.FirstOrDefault(x => x.Idioma == "Frances");

            var cuadrados = new List<FormaGeometrica> { new Rectangulo() { Lado = 2, Lado2 = 4 } };

            var resumen = Reporte.Imprimir(cuadrados, traduccion);

            Assert.AreEqual("<h1>Rapport sur les formulaires</h1>1  | Area 12 | Périmètre 8 <br/>TOTAL:<br/>1 des formes Périmètre 8 Area 12", resumen);
        }

    }
}
