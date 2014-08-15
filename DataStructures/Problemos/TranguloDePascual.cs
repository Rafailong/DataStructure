using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataStructures.Problemos
{
    public class TranguloDePascual
    {
        private int _niveles;

        private List<int[]> _triangulo;

        public TranguloDePascual(int niveles)
        {
            _niveles = niveles;
        }

        public int Niveles
        {
            get { return _niveles; }
        }

        public List<int[]> GenerarTriangulazo()
        {
            
            if (_niveles <= 1)
            {
                return _triangulo;
            }

            _triangulo = new List<int[]>();
            var triangulo1 = new[] { 1 };
            _triangulo.Add(triangulo1);

            Generar(triangulo1);
            
            return _triangulo;
        }

        void Generar(int[] triangulo)
        {
            if (triangulo.Length == (_niveles +1))
            {
                return;
            }

            var nuevo = new List<int>();
            nuevo.Add(1);

            for (int i = 1; i < triangulo.Length; i++)
            {
                int suma = triangulo[i - 1] + triangulo[i];
                nuevo.Add(suma);
            }

            nuevo.Add(1);
            _triangulo.Add(nuevo.ToArray());
            Generar(nuevo.ToArray());
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var pascual = new TranguloDePascual(3);
            List<int[]> triangulazo = pascual.GenerarTriangulazo();
        }
    }
}
