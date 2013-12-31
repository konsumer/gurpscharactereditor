using GurpsCharacterEditor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class AdvantageTest
    {
        [TestMethod]
        public void AdvantageConstructor()
        {
            Advantage target = new Advantage("abc", "def", 123);

            Assert.AreEqual("abc", target.Name);
            Assert.AreEqual(123, target.Points);
        }
    }
}
