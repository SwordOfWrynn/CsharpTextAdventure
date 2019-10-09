using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TextAdventure
{
    public static class GameController
    {
        const string XML_FILE_LOC = @"\xml";

        static bool gameStarted;
        static Mod loadedMod;

        public static int moves;
        public static int score;

        private static StringBuilder gameHistory = new StringBuilder();

        static Dictionary<string, Room> roomDictionary = new Dictionary<string, Room>();
        static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();
        //static Dictionary<int, Entity> entityDictionary;

        public static void StartGame(Mod modToPlay)
        {
            if (gameStarted)
            {
                return;
            }
            loadedMod = modToPlay;

            Console.Clear();
            Console.WriteLine(loadedMod.Title);

            Run();
        }

        static void Run()
        {
            while (true)
            {
                string consoleInput = ConsoleUtilities.ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput))
                    continue;
                try
                {
                    
                }
                catch (Exception ex)
                {
                    LogStringWithReturn(ex.GetType().ToString());
                    LogStringWithReturn(ex.Message);
                }
            }
        }

        static void LogStringWithReturn(string message)
        {
            string messageToLog = string.Format("\n {0}", message.ToLower());
            Console.WriteLine(messageToLog);
            gameHistory.Append(messageToLog);
        }

        static string RespondToInput()
        {
            throw new NotImplementedException();
        }

        public static void IncreaseMoves()
        {
            moves++;
        }

        public static void IncreaseScore(int num)
        {
            if (num < 0)
            {
                ErrorReporter.Instance.Report("Error - IncreaseScore has been passed a negative value!");
                throw new Exception("IncreaseScore cannot be passed a negative value");
            }

            score += num;
        }

        public static void Restart()
        {
            throw new NotImplementedException();
        }

        public static void AddRoom(Room room)
        {
            if (roomDictionary.ContainsKey(room.ID))
            {
                roomDictionary[room.ID] = room;
            }
            else
            {
                roomDictionary.Add(room.ID, room);
            }
        }

        public static void AddItem(Item item)
        {
            if (itemDictionary.ContainsKey(item.ID))
            {
                itemDictionary[item.ID] = item;
            }
            else
            {
                itemDictionary.Add(item.ID, item);
            }
        }

        static object CoerceArgument(Type requiredType, string inputValue)
        {
            var requiredTypeCode = Type.GetTypeCode(requiredType);
            string exceptionMessage =
                string.Format("Cannnot coerce the input argument {0} to required type {1}",
                inputValue, requiredType.Name);

            object result = null;
            switch (requiredTypeCode)
            {
                case TypeCode.String:
                    result = inputValue;
                    break;
                case TypeCode.Int16:
                    short number16;
                    if (Int16.TryParse(inputValue, out number16))
                    {
                        result = number16;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Int32:
                    int number32;
                    if (Int32.TryParse(inputValue, out number32))
                    {
                        result = number32;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Int64:
                    long number64;
                    if (Int64.TryParse(inputValue, out number64))
                    {
                        result = number64;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Boolean:
                    bool trueFalse;
                    if (bool.TryParse(inputValue, out trueFalse))
                    {
                        result = trueFalse;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Byte:
                    byte byteValue;
                    if (byte.TryParse(inputValue, out byteValue))
                    {
                        result = byteValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Char:
                    char charValue;
                    if (char.TryParse(inputValue, out charValue))
                    {
                        result = charValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.DateTime:
                    DateTime dateValue;
                    if (DateTime.TryParse(inputValue, out dateValue))
                    {
                        result = dateValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Decimal:
                    Decimal decimalValue;
                    if (Decimal.TryParse(inputValue, out decimalValue))
                    {
                        result = decimalValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Double:
                    Double doubleValue;
                    if (Double.TryParse(inputValue, out doubleValue))
                    {
                        result = doubleValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Single:
                    Single singleValue;
                    if (Single.TryParse(inputValue, out singleValue))
                    {
                        result = singleValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt16:
                    UInt16 uInt16Value;
                    if (UInt16.TryParse(inputValue, out uInt16Value))
                    {
                        result = uInt16Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt32:
                    UInt32 uInt32Value;
                    if (UInt32.TryParse(inputValue, out uInt32Value))
                    {
                        result = uInt32Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt64:
                    UInt64 uInt64Value;
                    if (UInt64.TryParse(inputValue, out uInt64Value))
                    {
                        result = uInt64Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                default:
                    throw new ArgumentException(exceptionMessage);
            }
            return result;
        }

    }
}
