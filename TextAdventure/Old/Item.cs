using System;

namespace TextAdventure.Old
{
    public abstract class Item
    {
        public abstract string PickupNoun { get; }

        public abstract string ItemName { get; }

        public abstract string ItemRoomDescription { get; }
    }

    public class Wrench : Item
    {
        public override string ItemName => "Wrench";

        public override string PickupNoun => "Wrench";

        public override string ItemRoomDescription => "A wrench lays on the hangar floor. (type 'take wrench' to pick it up)";
    }
}
