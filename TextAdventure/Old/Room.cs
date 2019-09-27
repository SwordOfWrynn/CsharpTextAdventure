using System;
using System.Text;
using TextAdventure;
using TextAdventure.Rooms;

namespace TextAdventure
{
    public class Exit
    {
        public Type exitRoom;
        public string keyword;
        public string exitDescription;

        public Exit(Type _exitType, string _keyword, string _exitDescription)
        {
            //if (_exitType != typeof(Room))
            if(_exitType.IsSubclassOf(typeof(Room)) == false)
                throw new Exception("An exitType passed to an exit was not a room");
            exitRoom = _exitType;
            keyword = _keyword;
            exitDescription = _exitDescription;
        }

    }
    namespace Rooms
    {

        public abstract class Room
        {
            public abstract string RoomName { get; }

            public abstract string RoomDescription { get; }

            public abstract Exit[] Exits { get; }

            public abstract Item[] Items { get; }

            public virtual string EnterRoom()
            {
                StringBuilder sbItems = new StringBuilder();
                foreach (Item item in Items)
                {
                    sbItems.Append(item.ItemRoomDescription);
                }
                StringBuilder sbExits = new StringBuilder();
                foreach (Exit exit in Exits)
                {
                    sbExits.Append(string.Format("\n {0}", exit.exitDescription));
                }
                //As of the moment, there should be no room that has items but no exits
                if(Items.Length > 0)
                    return string.Format("\n{0} \n\n {1} \n {2} \n {3}", RoomName, RoomDescription, sbItems.ToString(), sbExits.ToString());
                else if (Exits.Length > 0)
                    return string.Format("\n{0} \n\n {1} \n {2}", RoomName, RoomDescription, sbExits.ToString());
                else
                    return string.Format("\n{0} \n\n {1}", RoomName, RoomDescription);
            }
        }

        public class StartingRoom : Room
        {
            public override string RoomName => "Space";

            public override string RoomDescription => "Your ship is almost out of fuel and oxygen, but you've found and old space station you may be able to find supplies in";

            public override Exit[] Exits => new Exit[]
            {
                new Exit(typeof(Hangar), "hangar", "type \'go hangar\' to head to the Space Station Hangar."),
                new Exit(typeof(Space), "space", "type 'help' for a list of basic commands")
            };

            public override Item[] Items => new Item[0];

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class Hangar : Room
        {
            public override string RoomName => "Hangar";

            public override string RoomDescription => "Apart from the small ship you arrived in, the hangar is empty";

            public override Exit[] Exits => new Exit[] {
            new Exit(typeof(SouthHallA), "north", "to the north there is a large door that will lead into the space station. (type 'go north' to move here)"),
                new Exit(typeof(Space), "south", "However, you can hop back in your spaceship and head south back out into space. Without fuel, though, you probably won't get far. (type 'go south' to move here)")
        };

            public override Item[] Items => new Item[]
            {
                new Wrench()
            };

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class Space : Room
        {
            public override string RoomName => "Space";

            public override string RoomDescription => "Game Over \n You decided not to land on the station.You ran out of fuel and oxegen and asphyxiated in cold darkess of outer space";

            public override Exit[] Exits => new Exit[0];

            public override Item[] Items => new Item[0];

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        #region SouthHall

        public class SouthHallA : Room
        {
            public override string RoomName => "South Hall A";

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => new Exit[]{
                new Exit(typeof(SouthHallA), "east", ""),
                new Exit(typeof(Hangar), "south", "A door to the south leads to the hangar."),
                new Exit(typeof(SouthHallA), "west", "")
            };

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class SouthHallB : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class Cafeteria : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class Kitchen : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class Pantry : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();

            }
        }

        public class Freezer : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();

            }
        }

        public class SouthHallC : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class GeneratorRoom: Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class SouthHallD : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        public class SouthHallE : Room
        {
            public override string RoomName => throw new NotImplementedException();

            public override string RoomDescription => throw new NotImplementedException();

            public override Exit[] Exits => throw new NotImplementedException();

            public override Item[] Items => throw new NotImplementedException();

            public override string EnterRoom()
            {
                return base.EnterRoom();
            }
        }

        #endregion

        #region WestHall
        #endregion

        #region EastHall
        #endregion

        #region NorthHall
        #endregion

    }
}
