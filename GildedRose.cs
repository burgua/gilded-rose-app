using System;
using System.Collections.Generic;

namespace csharp;

public class GildedRose
{
    // beware the goblin
    IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        this.Items = items;
    }

    // Constants representing the minimum and maximum quality values
    private const int MinQuality = 0;
    private const int MaxQuality = 50;

    // Method to update the quality of each item based on its type
    public void UpdateQuality()
    {
        foreach (var item in this.Items)
        {
            // this item is legendary, nothing can be changed
            if (item.Name == "Sulfuras, Hand of Ragnaros") continue;

            // Switch based on the type of item
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrieItem(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePassItem(item);
                    break;
                case "Conjured Mana Cake":
                    UpdateConjuredManaCakeItem(item);
                    break;
                default:
                    UpdateDefaultItem(item);
                    break;
            }

            // relevant for every item except legendary item "Sulfuras, Hand of Ragnaros"
            item.SellIn--;
        }
    }

    // Updates a default type item's quality and sell-in period
    private static void UpdateDefaultItem(Item item)
    {
        var qualityDecrementValue = item.SellIn <= 0 ? 2 : 1;

        item.Quality -= qualityDecrementValue;

        item.Quality = Math.Max(item.Quality, MinQuality);
    }

    // Updates an Aged Brie type item's quality and sell-in period
    private static void UpdateAgedBrieItem(Item item)
    {
        var qualityIncrementValue = item.SellIn <= 0 ? 2 : 1;

        item.Quality += qualityIncrementValue;

        item.Quality = Math.Min(item.Quality, MaxQuality);
    }

    // Updates a Conjured Mana Cake type item's quality and sell-in period
    private static void UpdateConjuredManaCakeItem(Item item)
    {
        var qualityDecrementValue = item.SellIn <= 0 ? 4 : 2;

        item.Quality -= qualityDecrementValue;

        item.Quality = Math.Max(item.Quality, MinQuality);
    }

    // Gets value for updating Backstage Pass type item quality depending on sell-in period
    private static int GetBackstagePassQualityUpdate(Item item)
    {
        return item.SellIn switch
        {
            <= 0 => -item.Quality,
            < 6 => 3,
            < 11 => 2,
            _ => 1
        };
    }

    // Updates a Backstage Pass type item's quality and sell-in period
    private static void UpdateBackstagePassItem(Item item)
    {
        var qualityUpdateValue = GetBackstagePassQualityUpdate(item);

        item.Quality += qualityUpdateValue;

        item.Quality = Math.Min(item.Quality, MaxQuality);
    }
}