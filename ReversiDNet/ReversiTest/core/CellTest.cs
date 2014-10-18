using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Reversi.core;

namespace ReversiTest.core
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void コンストラクタでコピーできるか()
        {
            Cell original = new Cell();
            original.setStone( TurnEnum.FIRST );
            Cell copy = new Cell( original );
            Assert.AreEqual( original.getStone(), copy.getStone() );
        }
    }
}
