using GurpsCharacterEditor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class DamageTest
    {
        [TestMethod]
        public void DamageConstruction()
        {
            Damage target = new Damage(DamageBase.Thrusting, DamageType.Burning);

            Assert.AreEqual(DamageBase.Thrusting, target.DamageBase);
            Assert.AreEqual(DamageType.Burning, target.DamageType);
        }
    }
}
