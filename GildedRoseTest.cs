using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_AnyItem_NameUnchanged()
        {
            // Arrange
            var item = new Item { Name = "Any item", SellIn = 0, Quality = 0 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual("Any item", item.Name);
        }

        [Test]
        public void DefaultItem_ZeroQuality_AfterUpdateQuality_WillStayZero()
        {
            // Arrange
            var agedBrieItem = new Item { Name = "Default item", SellIn = 10, Quality = 0 };
            var gildedRose = new GildedRose(new List<Item> { agedBrieItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(0, agedBrieItem.Quality);
        }

        [Test]
        public void UpdateQuality_DefaultItem_QualityDecreasedBy1()
        {
            // Arrange
            var agedBrieItem = new Item { Name = "Default item", SellIn = 10, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { agedBrieItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(19, agedBrieItem.Quality);
        }

        [Test]
        public void UpdateQuality_DefaultItem_QualityDecreasedBy2()
        {
            // Arrange
            var agedBrieItem = new Item { Name = "Default item", SellIn = 0, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { agedBrieItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(18, agedBrieItem.Quality);
        }

        [Test]
        public void UpdateQuality_AgedBrieItem_QualityIncreasedBy1()
        {
            // Arrange
            var agedBrieItem = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { agedBrieItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(21, agedBrieItem.Quality);
        }

        [Test]
        public void UpdateQuality_AgedBrieItem_QualityIncreasedBy2()
        {
            // Arrange
            var agedBrieItem = new Item { Name = "Aged Brie", SellIn = -2, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { agedBrieItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(22, agedBrieItem.Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePassItem_SellInLessThan11_QualityIncreasedBy1()
        {
            // Arrange
            var backstagePassItem = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 30, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { backstagePassItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(21, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePassItem_SellInLessThan11_QualityIncreasedBy2()
        {
            // Arrange
            var backstagePassItem = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { backstagePassItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(22, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePassItem_SellInLessThan6_QualityIncreasedBy3()
        {
            // Arrange
            var backstagePassItem = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { backstagePassItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(23, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePassItem_AfterConcert_QualityDropsToZero()
        {
            // Arrange
            var backstagePassItem = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { backstagePassItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(0, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_Sulfuras_NeverChanges()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void UpdateQuality_SulfurasAfterSellIn_NeverChanges()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredManaCake_DecreasesTwiceAsFast()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(18, item.Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredManaCakeAfterSellIn_DecreasesFourTimesAsFast()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 20 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(16, item.Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredManaCakeQualityNeverNegative()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void SellIn_DecreasesByOne_ForRegularItems()
        {
            // Arrange
            var item = new Item { Name = "Any item", SellIn = 0, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void SellIn_RemainsUnchanged_ForSulfurasItem()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 0 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.AreEqual(10, item.SellIn);
        }
    }
}