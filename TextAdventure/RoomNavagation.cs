using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class RoomNavagation
    {
        public Room CurrentRoom { get { return m_CurrentRoom; } }
        Room m_CurrentRoom;

        public RoomNavagation(Room startRoom, out string roomEnterText)
        {
            roomEnterText = ChangeRoom(startRoom);
        }

        /// <summary>
        /// Changes the current room to the passed in room, ignoring current room exits
        /// </summary>
        /// <param name="roomToChangeTo"></param>
        public string ChangeRoom(Room roomToChangeTo)
        {
            m_CurrentRoom = roomToChangeTo;
            return m_CurrentRoom.EnterRoom();
        }

        /// <summary>
        /// tries to enter a room from the current room
        /// </summary>
        /// <param name="roomToEnter"></param>
        public string EnterRoom(Room roomToEnter)
        {
            m_CurrentRoom = roomToEnter;
            return m_CurrentRoom.EnterRoom();
        }

    }
}
