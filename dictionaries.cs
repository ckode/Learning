using System;
using System.Collections.Generic;

namespace LearningApp {
    struct MyStruct {
        public string Name;
        public string CharClass;
        public string CharRace;
        public PlayerStats PlayerStat;
        public MyStruct(string name, string charclass, string charrace, int s, int a, int i, int w, int h, int c) {
            Name = name;
            CharClass = charclass;
            CharRace = charrace;
            PlayerStat = new PlayerStats(s, a, i, w, h, c);
        }
    }

    struct PlayerStats {
        public int Strength;
        public int Agility;
        public int Intellect;
        public int Widsom;
        public int Heath;
        public int Charm;

        public PlayerStats(int s, int a, int i, int w, int h, int c){
            Strength = s;
            Agility = a;
            Intellect = i;
            Widsom = w;
            Heath = h;
            Charm = c;
        }
    }

    class Program {
        static void Main() {
            Dictionary<string, MyStruct> PlayerList = new Dictionary<string, MyStruct>();
            
            PlayerList.Add("IP1", new MyStruct("Admiral", "Mystic", "Dark-Elf", 80, 120, 60, 40, 90, 50));
            PlayerList.Add("IP2", new MyStruct("Frag", "Warrior", "Dwarf", 110, 100, 70, 40, 120, 40));
            PlayerList.Add("IP3", new MyStruct("Jack", "Bard", "Dark-Elf", 70, 120, 65, 40, 90, 80));
            PlayerList.Add("IP4", new MyStruct("Djinn", "Mage", "Gaunt One", 40, 120, 140, 40, 70, 50));
            PlayerList.Add("IP5", new MyStruct("Sekhmet", "Priest", "Goblin", 40, 100, 50, 100, 90, 50));

            foreach (KeyValuePair<string, MyStruct> element in PlayerList) {
                Console.WriteLine(string.Format("{0} is a {1} {2}", element.Value.Name, element.Value.CharRace, element.Value.CharClass));
                Console.WriteLine(string.Format("Strength: {0}, Agility: {1}, Intellect: {2}, Wisdom: {3}, Health: {4}, Charm: {5}",
                                                                                                    element.Value.PlayerStat.Strength,
                                                                                                    element.Value.PlayerStat.Agility, 
                                                                                                    element.Value.PlayerStat.Intellect, 
                                                                                                    element.Value.PlayerStat.Widsom, 
                                                                                                    element.Value.PlayerStat.Heath, 
                                                                                                    element.Value.PlayerStat.Charm));
            }    
        }
    }
}