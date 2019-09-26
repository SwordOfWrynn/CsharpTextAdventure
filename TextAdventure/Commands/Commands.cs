using System;
using System.Text;

//Every command should be a 'public static string' in a 'public static class'
namespace TextAdventure.Commands
{
    /// <summary>
    /// Attribute for the help description commands
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandDescription : System.Attribute
    {
        string helpDescription;
        public CommandDescription(string _description)
        {
            helpDescription = _description;
        }
        public string GetHelpDescription()
        {
            return helpDescription.ToLower();
        }
    }
    
    public static class BasicCommands
    {
        [CommandDescription("moves in the given direction. e.g. 'go north'")]
        public static string Go(string _input)
        {
            string response = string.Empty;
            if (GameController.Instance.roomNavigation.AttemptToChangeRooms(_input, out response))
            {
                return string.Format("you head off to the {0} \n{1}", _input, response);
            }

            return string.Format("you can't go {0}", _input);
        }

        [CommandDescription("describes the room")]
        public static string Look()
        {
            throw new NotImplementedException();
        }

        [CommandDescription("attempt to put an item in your inventory. e.g.'take wrench'")]
        public static string Take(string _Input)
        {
            string response = string.Empty;

            foreach (Item item in GameController.Instance.roomNavigation.CurrentRoom.Items)
            {
                if (item.PickupNoun.ToLower() == _Input || item.ItemName.ToLower() == _Input)
                {
                    response = GameController.Instance.AddToInventory(item);
                }
            }
                return response;
        }

        [CommandDescription("displays your inventory")]
        public static string Inventory()
        {
            if (GameController.Instance.Inventory.Count == 0)
                return "You inventory is empty";

            StringBuilder sb = new StringBuilder();
            sb.Append("You check your inventory. You have: \n");
            foreach (Item item in GameController.Instance.Inventory)
            {
                sb.Append(string.Format("\n {0}", item.ItemName));
            }

            return sb.ToString();
        }

        [CommandDescription("examines an item in the room or your inventory. e.g. 'examine wrench'")]
        public static string Examine()
        {
            throw new NotImplementedException();
        }

        [CommandDescription("uses an item. e.g. 'use wrench'")]
        public static string Use()
        {
            throw new NotImplementedException();
        }

        [CommandDescription("saves the game under the give name. e.g. 'save foo' saves the game as foo")]
        public static string Save()
        {
            throw new NotImplementedException();
        }

        [CommandDescription("loads the given game, e.g. 'load foo'. if no name is given for the game, it will display all saved games.")]
        public static string Load()
        {
            throw new NotImplementedException();
        }

        [CommandDescription("restarts the game")]
        public static string Restart()
        {
            GameController.Instance.Restart();
            return string.Empty;
        }

        [CommandDescription("quits the game")]
        public static string Quit()
        {
            Environment.Exit(0);
            return string.Empty;
        }

        public static string Info()
        {

            throw new NotImplementedException();
        }

        public static string Sing()
        {
            Random random = new Random();
            int num = random.Next(1, 5);
            GameController.Instance.IncreaseMoves();
            switch (num)
            {
                case 1:
                    return("What are you doing?");
                case 2:
                    return("Don't you have better things to do?");
                case 3:
                    return("Why are you singing?");
                case 4:
                    return("Survival first, singing later");
                default:
                    return("Does that make you feel better?");
            }
        }

        public static string Credits()
        {
            throw new NotImplementedException();
        }

        public static string Help()
        {
            return GameController.Instance.GetHelpDescriptions();
        }
          
    }
}
