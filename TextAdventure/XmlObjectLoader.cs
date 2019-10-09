using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TextAdventure
{
    enum XmlType { Room, Item, Entity}

    class XmlObjectLoader
    {
        private XmlType m_Type;
        public XmlType type { get { return m_Type; } }

        public XmlObjectLoader(XElement xmlObject)
        {
            LoadXML(xmlObject);
        }

        public XmlObjectLoader(string path)
        {
            LoadXML(XElement.Load(path));
        }

        void LoadXML(XElement xmlObject)
        {

            switch (xmlObject.Name.ToString())
            {
                case "Room":
                    m_Type = XmlType.Room;
                    LoadRoomXml(xmlObject);
                    break;
                case "Item":
                    m_Type = XmlType.Item;
                    LoadItemXml(xmlObject);
                    break;
                case "Entity":
                    m_Type = XmlType.Entity;
                    LoadEntityXml(xmlObject);
                    break;
                default:
                    Console.WriteLine("Error - XmlObject: Unregonized xml type");
                    break;
            }
        }

        void LoadRoomXml(XElement xmlRoom)
        {
            string roomID = xmlRoom.Element("ID").Value;
            string roomName = xmlRoom.Element("Name").Value;
            string roomDescription = xmlRoom.Element("Description").Value;

            RoomExit[] roomExits = GetRoomExitsXML(xmlRoom);

            RoomItem[] roomItems = GetItemsXML(xmlRoom);

            Room newRoom = new Room(roomID, roomName, roomDescription, roomExits, roomItems);

            GameController.AddRoom(newRoom);
        }

        RoomExit[] GetRoomExitsXML(XElement xmlObject)
        {
            //Create a LINQ query to find the Exits element, then get its children ordered by name
            var exitQuery =
                from element in xmlObject.Elements()
                where element.Name == "Exits"
                from exit in element.Elements()
                orderby exit.Name.ToString()
                select exit;

            List<RoomExit> roomExits = new List<RoomExit>();
            //Iterate over the query for the results
            foreach (var exit in exitQuery)
            {
                string exitID = exit.Element("RoomID").Value;
                string exitName = exit.Element("Name").Value;
                string exitDirection = exit.Element("Direction").Value;
                string exitDesc = exit.Element("Description").Value;

                RoomExit roomExit = new RoomExit(exitID, exitName, exitDirection, exitDesc);
                roomExits.Add(roomExit);
            }

            return roomExits.ToArray();
        }

        RoomItem[] GetItemsXML(XElement xmlObject)
        {
            //Create a LINQ query to find the Items element, then get its children ordered by name
            var itemQuery =
                from element in xmlObject.Elements()
                where element.Name == "Items"
                from item in element.Elements()
                orderby item.Name.ToString()
                select item;

            List<RoomItem> roomItems = new List<RoomItem>();
            //Iterate over the query for the results
            foreach (var item in itemQuery)
            {
                string itemID = item.Element("ItemID").Value;
                string itemName = item.Element("Name").Value;
                string itemDesc = item.Element("Description").Value;

                RoomItem roomItem = new RoomItem(itemID, itemName, itemDesc);
                roomItems.Add(roomItem);
            }

            return roomItems.ToArray();
        }

        void LoadItemXml(XElement xmlItem)
        {
            string itemID = xmlItem.Element("ID").Value;
            string itemName = xmlItem.Element("Name").Value;
            string itemType = xmlItem.Element("ItemType").Value;
            string itemDesc = xmlItem.Element("Description").Value;

            Item newItem = new Item(itemID, itemName, itemType, itemDesc);

            GameController.AddItem(newItem);
        }

        void LoadEntityXml(XElement xmlEntity)
        {
            throw new NotImplementedException();
        }

    }
}
