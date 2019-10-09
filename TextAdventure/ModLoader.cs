using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TextAdventure
{
    public struct Mod
    {
        public readonly string ID;
        public readonly string Name;
        public readonly string Title;
        public readonly string StartRoomID;
        public readonly string Path;

        public Mod(string modID, string name, string title, string startRoomID, string path)
        {
            ID = modID;
            Name = name;
            Title = title;
            StartRoomID = startRoomID;
            Path = path;
        }
    }
    class ModLoader
    {

        static Mod GetMod(XElement xmlMod, string path)
        {
            if(xmlMod.Name.LocalName != "Mod")
            {
                Console.WriteLine($"found a xml file that is not a mod xml in mod base folder! this file will not be loaded");
                ErrorReporter.Instance.Report($"found a xml file that is not a mod xml in mod base folder! this file will not be loaded. File at {path}");
                return new Mod();
            }
            string modID = xmlMod.Element("ID").Value;
            string modName = xmlMod.Element("Name").Value;
            string modTitle = xmlMod.Element("Title").Value;
            string modStartRoomID = xmlMod.Element("StartRoomID").Value;
            string modPath = path;

            return new Mod(modID, modName, modTitle, modStartRoomID, modPath);
        }
        public static Mod GetMod(string path)
        {
            return GetMod(XElement.Load(path), path);
        }

    }
}
