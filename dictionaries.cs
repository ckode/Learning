using System;
using System.Collections.Generic;

/*
The following file is to help understand dictionaries and using them to manage lists of objects.

My intention was to use structures instead of classes as I read that working with structures
is a much faster operations.  The issue I ran into is you cannot update structures within a
dictionary. (it returns a copy of the struct) Well. You can, by making a copy of the struct
updating it and then replacing the old struct in the dictionary, but now while completing the
iterating over the dictionary. It will throw the numeration of the loop off and exploded.  (it 
will compile, but explode when ran)

If you use class objects within the dictionary, then a reference is returned  as you iterate 
through the foreach loop allowing you to update the object and not corrupting the enumeration.

 */
namespace LearningApp {
    class Player {
        public string Name;
        public string CharClass;
        public string CharRace;
        public PlayerStats PlayerStat;
        public Player(string name, string charclass, string charrace, int s, int a, int i, int w, int h, int c) {
            Name = name;
            CharClass = charclass;
            CharRace = charrace;
            PlayerStat = new PlayerStats(s, a, i, w, h, c);
        }
    }

    class PlayerStats {
        public int Strength;
        public int Agility;
        public int Intellect;
        public int Wisdom;
        public int Heath;
        public int Charm;

        public PlayerStats(int s, int a, int i, int w, int h, int c) {
            Strength = s;
            Agility = a;
            Intellect = i;
            Wisdom = w;
            Heath = h;
            Charm = c;
        }
    }

    class Program {
        static void Main() {
            Dictionary<string, Player> PlayerList = new Dictionary<string, Player>();

            PlayerList.Add("IP1", new Player("Admiral", "Mystic", "Dark-Elf", 80, 120, 60, 40, 90, 50));
            PlayerList.Add("IP2", new Player("Frag", "Warrior", "Dwarf", 110, 100, 70, 40, 120, 40));
            PlayerList.Add("IP3", new Player("Jack", "Bard", "Dark-Elf", 70, 120, 65, 40, 90, 80));
            PlayerList.Add("IP4", new Player("Djinn", "Mage", "Gaunt One", 40, 120, 140, 40, 70, 50));
            PlayerList.Add("IP5", new Player("Sekhmet", "Priest", "Goblin", 40, 100, 50, 100, 90, 50));

            foreach (KeyValuePair<string, Player> element in PlayerList) {
                Console.WriteLine(string.Format("{0} is a {1} {2}", element.Value.Name,
                                                                    element.Value.CharRace,
                                                                    element.Value.CharClass));
                Console.WriteLine(string.Format("Strength: {0}, Agility: {1}, Intellect: {2}, Wisdom: {3}, Health: {4}, Charm: {5}",
                                                                                                    element.Value.PlayerStat.Strength,
                                                                                                    element.Value.PlayerStat.Agility,
                                                                                                    element.Value.PlayerStat.Intellect,
                                                                                                    element.Value.PlayerStat.Wisdom,
                                                                                                    element.Value.PlayerStat.Heath,
                                                                                                    element.Value.PlayerStat.Charm));
                if (element.Value.Name == "Jack") {
                    element.Value.CharClass = "Warrior";
                }
                //The line below can use element.Value.Name/CharRace/CharClass varables also.
                Console.WriteLine(string.Format("{0} is a {1} {2}", PlayerList[element.Key].Name,
                                                                    PlayerList[element.Key].CharRace,
                                                                    PlayerList[element.Key].CharClass));
            }
        }
    }
}