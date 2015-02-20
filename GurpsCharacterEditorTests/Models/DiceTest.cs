using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GurpsCharacterEditor.Models;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void DiceConstructor()
        {
            Dice target = new Dice(3, 2);

            Assert.AreEqual(3, target.Count);
            Assert.AreEqual(2, target.Modifier);
            Assert.AreEqual("3d+2", target.ToString());
        }

        [TestMethod]
        public void DiceConstructorTwoArgs()
        {
            Dice target = new Dice(2);

            Assert.AreEqual(2, target.Count);
            Assert.AreEqual(0, target.Modifier);
            Assert.AreEqual("2d", target.ToString());
        }
    }
}
