using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public enum ItemType
    {
        PickUp,
        Equipment,
        Stationary,
        Unknown
    }

    public class Item
    {
        public readonly string ID;

        public readonly string Name;

        public readonly ItemType ItemType;

        string m_Description;
        public string Description { get { return m_Description; } }

        public Item(string itemID, string name, string itemType, string desc)
        {
            ID = itemID;
            Name = name;
            ItemType = StringToItemType(itemType);

            if(ItemType == ItemType.Unknown)
            {
                ErrorReporter.Instance.Report($"Item {itemID}:{itemID} has an unknown item type: {itemType}");
            }

            m_Description = desc;
        }

        public static ItemType StringToItemType(string itemType)
        {
            switch (itemType.ToLower())
            {
                case "pickup":      return ItemType.PickUp;
                case "stationary":  return ItemType.Stationary;
                case "equipment":   return ItemType.Equipment;
                default:            return ItemType.Unknown;
            }
        }

    }
}
