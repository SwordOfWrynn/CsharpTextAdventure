using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Item
    {
        public readonly string ID;

        public readonly string Name;

        string m_Description;
        public string Description { get { return m_Description; } }

        public Item(string itemID, string name, string desc)
        {
            ID = itemID;
            Name = name;
            m_Description = desc;
        }
    }
}
