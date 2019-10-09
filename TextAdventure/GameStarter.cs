using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAdventure
{
    class GameStarter
    {
        const string XML_FILE_LOC = @"\xml";
        const string SAVE_LOC = @"\saves";

        static List<Mod> modsList;

        public static void PrepareGame()
        {
            Console.WriteLine("Preparing Game...");

            LoadMods();

            Console.WriteLine("\n[1] New Game \n");
            Console.WriteLine("[2] Load Game \n");
            Console.WriteLine("[3] Exit Game");

            int choice;
            while (int.TryParse(ConsoleUtilities.ReadFromConsole("Choose an option: "), out choice) == false || (choice < 1 || choice > 3))
            {
                Console.WriteLine("invalid input. type 1, 2 or 3 and hit enter");
            }
            switch (choice)
            {
                case 1:
                    NewGame();
                    break;
                case 2:
                    throw new NotImplementedException();
                    break;
                case 3:
                    throw new NotImplementedException();
                    break;
            }
        }

        static void NewGame()
        {
            Dictionary<int, Mod> modsDict = new Dictionary<int, Mod>();

            for (int i = 0; i < modsList.Count; i++)
            {
                modsDict.Add(i + 1, modsList[i]);
            }

            foreach(var key in modsDict.Keys)
            {
                Console.WriteLine($"[{key}] {modsDict[key]}");
            }

            int choice;
            while(int.TryParse(ConsoleUtilities.ReadFromConsole("choose a mod to play: "), out choice) == false || modsDict.ContainsKey(choice) == false)
            {
                Console.WriteLine("invalid input. enter a valid choice number");
            }
            Mod chosenMod = modsList[choice - 1];
            Console.WriteLine($"Loading {chosenMod.Name}");
            LoadXmlFiles(chosenMod.Path);

            GameController.StartGame(chosenMod);
        }

        static void LoadMods()
        {
            modsList = new List<Mod>();

            string path = Environment.CurrentDirectory + XML_FILE_LOC;
            if (Directory.Exists(path) == false)
            {
                Console.WriteLine("error - attempted to load xml files at invalid directory");
                ErrorReporter.Instance.Report("Error - Attempted to load xml files at invalid directory");
            }
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                if (Directory.GetFiles(dir).Length > 0)
                {
                    foreach (var file in Directory.EnumerateFiles(dir, "*.xml"))
                    {
                        Console.WriteLine(file);
                        Mod mod = ModLoader.GetMod(file);
                        if(mod.ID == string.Empty)
                        {
                            continue;
                        }
                        Console.WriteLine($"found mod {mod.Name}");
                        modsList.Add(mod);
                    }
                }
                else Console.WriteLine("no mods found!");
            }
        }

        static void LoadXmlFiles(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Console.WriteLine($"error - attempted to load xml files at invalid directory at {path}");
                ErrorReporter.Instance.Report("Error - Attempted to load xml files at invalid directory");
                return;
            }

            foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
            {
                Console.WriteLine("Loading " + file);
                XmlObjectLoader xmlLoader = new XmlObjectLoader(Path.Combine(path, file));
            }
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                LoadXmlFiles(dir);
            }
        }
    }
}
