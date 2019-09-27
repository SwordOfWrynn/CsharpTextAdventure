using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public struct RoomItem
    {
        public readonly string ID;
        public readonly string Name;
        public readonly string Description;

        public RoomItem(string itemID, string name, string desc)
        {
            ID = itemID;
            Name = name;
            Description = desc;
        }
    }

    public struct RoomExit
    {
        public readonly string ID;
        public readonly string Name;
        public readonly string Direction;
        public readonly string Description;

        public RoomExit(string roomID, string name, string direction, string desc)
        {
            ID = roomID;
            Name = name;
            Direction = direction;
            Description = desc;
        }
    }

    public class Room
    {
        public readonly string ID;

        string m_Name;
        public string RoomName { get { return m_Name; } }

        string m_Description;
        public string RoomDescription { get { return m_Description; } }

        RoomExit[] m_Exits;
        public RoomExit[] Exits { get { return m_Exits; } }

        RoomItem[] m_Items;
        public RoomItem[] Items { get { return m_Items; } }

        public Room(string ID, string name, string description, RoomExit[] exits, RoomItem[] items)
        {
            this.ID = ID;
            m_Name = name;
            m_Description = description;
            m_Exits = exits;
            m_Items = items;
        }

        public string EnterRoom()
        {
            StringBuilder sbItems = new StringBuilder();
            foreach (RoomItem item in Items)
            {
                sbItems.Append(item.Description);
            }
            StringBuilder sbExits = new StringBuilder();
            foreach (RoomExit exit in Exits)
            {
                sbExits.Append(string.Format("\n {0}", exit.Description));
            }
            //As of the moment, there should be no room that has items but no exits
            if (Items.Length > 0)
                return string.Format("\n{0} \n\n {1} \n {2} \n {3}", RoomName, RoomDescription, sbItems.ToString(), sbExits.ToString());
            else if (Exits.Length > 0)
                return string.Format("\n{0} \n\n {1} \n {2}", RoomName, RoomDescription, sbExits.ToString());
            else
                return string.Format("\n{0} \n\n {1}", RoomName, RoomDescription);
        }
    }
}
