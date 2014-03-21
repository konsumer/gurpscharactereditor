using GurpsCharacterEditor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GurpsEditorTests.Models
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void ItemCopyConstructor()
        {
            Item item = new Item("Bucket", 5, 15);
            Item target = new Item(item);

            Assert.IsTrue(item.Equals(target));
        }

        [TestMethod]
        public void ItemEquals()
        {
            Item target = new Item("Bucket", 5, 15);
            target.Description = "Big bucket.";
            Item item = new Item("Bucket", 5, 15);
            item.Description = "Big bucket.";

            Assert.IsFalse(target.Equals(null));
            Assert.IsFalse(target.Equals(new object()));

            Assert.IsTrue(target.Equals(item));
            item.Name = "Paper";
            Assert.IsFalse(target.Equals(item));
            item.Name = "Bucket";
            item.Description = "Small bucket.";
            Assert.IsFalse(target.Equals(item));
            item.Description = "Big bucket.";
            item.Value = 10;
            Assert.IsFalse(target.Equals(item));
            item.Value = 5;
            item.Weight = 20;
            Assert.IsFalse(target.Equals(item));
            item.Weight = 15;
            Assert.IsTrue(target.Equals(item));
        }
    }
}
