using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataStructures.Lists
{
    public class PilotaItem
    {
        public PilotaItem(string data)
        {
            Data = data;
        }

        public PilotaItem ElDeAbajo { get; set; }

        public string Data { get; set; }
    }

    public class Pilota
    {
        private static PilotaItem _meroDeHastaArriba;

        public PilotaItem Indice { get { return _meroDeHastaArriba; } }

        public Pilota(string first)
        {
            _meroDeHastaArriba = new PilotaItem(first);
        }

        public void Putch(string next)
        {
            var pilotaItem = new PilotaItem(_meroDeHastaArriba.Data);
            pilotaItem.ElDeAbajo = _meroDeHastaArriba.ElDeAbajo;
            _meroDeHastaArriba.Data = next;
            _meroDeHastaArriba.ElDeAbajo = pilotaItem;
        }

        public void Poop()
        {
            if (_meroDeHastaArriba.ElDeAbajo != null)
            {
                _meroDeHastaArriba.Data = _meroDeHastaArriba.ElDeAbajo.Data;
                _meroDeHastaArriba.ElDeAbajo = _meroDeHastaArriba.ElDeAbajo.ElDeAbajo;
            }
            else
            {
                _meroDeHastaArriba = null;
            }
        }
    }

    [TestFixture]
    public class PolitaTests
    {
        [Test]
        public void PushEnLaPilota()
        {
            var pilota = new Pilota("rafa");

            pilota.Putch("avila");

            pilota.Putch("martinez");

            pilota.Poop();
            pilota.Poop();
        }
    }
}
