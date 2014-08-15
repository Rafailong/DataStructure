using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataStructures.Lists
{
    public class Morro
    {
        public Morro(string apodo)
        {
            Apodo = apodo;
        }

        public Morro Siguiente { get; set; }

        public string Apodo { get; set; } 
    }

    public class ColaDeLasTortillas
    {
        private static Morro _apuntador;

        public Morro Apuntador
        {
            get { return _apuntador; }
        }

        public void MandarAlMorror  (string chamaco)
        {
            if (_apuntador == null)
            {
                _apuntador = new Morro(chamaco);
                return;
            }

            EncolarMorro(_apuntador, chamaco);
        }

        private void EncolarMorro(Morro apuntador, string chamaco)
        {
            if (apuntador.Siguiente != null)
            {
                EncolarMorro(apuntador.Siguiente, chamaco);
            }
            else
            {
                apuntador.Siguiente =new Morro(chamaco);
            }
        }

        public string AtenderAlMorroSiguiente()
        {
            if (_apuntador != null)
            {
                var chamaco = _apuntador.Apodo;
                if (_apuntador.Siguiente == null)
                {
                    _apuntador = null;
                }
                else
                {
                    _apuntador.Apodo = _apuntador.Siguiente.Apodo;
                    _apuntador.Siguiente = _apuntador.Siguiente.Siguiente;
                }

                return chamaco;
            }
            
            return null;
        }
    }

    [TestFixture]
    public class Torilleria
    {
        [Test]
        public void Trabajar()
        {
            var colaDeLasTortillas = new ColaDeLasTortillas();

            colaDeLasTortillas.MandarAlMorror("joan");
            colaDeLasTortillas.MandarAlMorror("rafail");

            var morroAtendido = colaDeLasTortillas.AtenderAlMorroSiguiente();
            Console.WriteLine(morroAtendido);

            var morroAtendido1 = colaDeLasTortillas.AtenderAlMorroSiguiente();
            Console.WriteLine(morroAtendido1);

            var morroAtendido2 = colaDeLasTortillas.AtenderAlMorroSiguiente();
            Console.WriteLine(morroAtendido2);
        }
    }
}
