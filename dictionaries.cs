using System;
using System.Collections.Generic;

namespace LearningApp {
    struct MyStruct {
        public string Name;
        public string CharClass;
        public string CharRace;
        public MyStruct(string name, string charclass, string charrace) {
            Name = name;
            CharClass = charclass;
            CharRace = charrace;
        }
    }

    class Program {
        static void Main() {
            Dictionary<string, MyStruct> PlayerList = new Dictionary<string, MyStruct>();
            
            PlayerList.Add("IP1", new MyStruct("Admiral", "Mystic", "Dark-Elf"));
            PlayerList.Add("IP2", new MyStruct("Frag", "Warrior", "Dwarf"));
            PlayerList.Add("IP3", new MyStruct("Jack", "Bard", "Dark-Elf"));
            PlayerList.Add("IP4", new MyStruct("Djinn", "Mage", "Gaunt One"));
            PlayerList.Add("IP5", new MyStruct("Sekhmet", "Priest", "Goblin"));

            foreach (KeyValuePair<string, MyStruct> element in PlayerList) {
                Console.WriteLine(string.Format("{0} is a {1} {2}", element.Value.Name, element.Value.CharRace, element.Value.CharClass));
            }    
        }
    }
}