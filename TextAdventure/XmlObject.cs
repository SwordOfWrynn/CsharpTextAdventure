using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TextAdventure
{
    enum XmlType { Room, Item, Entity }

    class XmlObject
    {
        private XmlType m_Type;
        public XmlType type { get { return m_Type; } }

        public XmlObject(string path)
        {
            XElement xmlFile = XElement.Load(path);

            switch (xmlFile.Name.ToString())
            {
                case "Room":
                    m_Type = XmlType.Room;
                    LoadRoomXml(xmlFile);
                    break;
                case "Item":
                    m_Type = XmlType.Item;
                    LoadItemXml();
                    break;
                case "Entity":
                    m_Type = XmlType.Entity;
                    LoadEntityXml();
                    break;
                default:
                    Console.WriteLine("Error - XmlObject: Unregonized xml type");
                    break;
            }
        }

        void LoadRoomXml(XElement xmlFile)
        {
            throw new NotImplementedException();

            //Create a LINQ query to find the Exits element, then get its children ordered by name
            var exitQuery =
                from element in xmlFile.Elements()
                where element.Name == "Exits"
                from component in element.Elements()
                orderby component.Name.ToString()
                select component;

            //Iterate over the query for the results
            foreach (var exit in exitQuery)
            {
                RoomExit roomExit = new RoomExit();
                roomExit.Name = exit.Name.ToString();
                if (component.HasElements)
                {
                    unitComponent.Values = new List<string>();
                    foreach (var componentelement in component.Elements())
                    {
                        unitComponent.Values.Add(componentelement.Value);
                    }
                }
                unitComponents.Add(unitComponent);
            }
        }

        void LoadItemXml()
        {
            throw new NotImplementedException();
        }

        void LoadEntityXml()
        {
            throw new NotImplementedException();
        }

    }

    public struct RoomItem
    {
        readonly string name;
        readonly string description;
        readonly string itemID;
    }

    public struct RoomExit
    {
        readonly string name;
        readonly string description;
        readonly string roomID;
    }

    public class Room
    {
        public readonly uint ID;

        string m_Name;
        public string RoomName { get { return m_Name; } }

        string m_Description;
        public string RoomDescription { get { return m_Description; } }

        RoomExit[] m_Exits;
        public RoomExit[] Exits { get { return m_Exits; } }

        RoomItem[] m_Items;
        public RoomItem[] Items { get { return m_Items; } }

        public Room(uint ID, string name, string description, RoomExit[] exits, RoomItem[] items)
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
                sbItems.Append(item.ItemRoomDescription);
            }
            StringBuilder sbExits = new StringBuilder();
            foreach (RoomExit exit in Exits)
            {
                sbExits.Append(string.Format("\n {0}", exit.exitDescription));
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
