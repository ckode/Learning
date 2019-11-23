using System;
using System.Collections.Generic;

/*
  The following code implements polymorphism in c#. 

  This represents the scheduler and event engine that
  was originially written for the minions mud server. 
  The main difference was I used a base event class 
  in the minions code to derive all the different 
  types of events from.  

  Then use a list of of items of the base event
  class to execute all the event objects.

  In this c# example, instead of using a base event
  class. I use an Interface that each class implements
  and then create the event list of type Iface (the interface)

  ***NOTE***
     Ignore the random number calls and how I'm using
     them in class objects.  It's stupid and a bad
     idea.  :)

  */

namespace PolyMorph {
    // The Interface only discribes the Execute() method.
    public interface Iface {
        public void Execute();
        public abstract int GetDamage();
    }

    // Spell class implementing Iface
    public class Spell : Iface {
        string spellText = "You cast fireball causing {0} damage!";
        Random random;
        public Spell(int seed) { random = new Random(seed); }

        public void Execute() {
            Console.WriteLine(String.Format(spellText, GetDamage()));
        }
        public int GetDamage() {
            return random.Next(50, 250);
        }
    }
    // Melee class implementing Iface
    public class Melee : Iface {
        string meleeText = "You swing your axe causing {0} damage!";
        Random random;
        public Melee(int seed) { random = new Random(seed); }
        public void Execute() {
            Console.WriteLine(String.Format(meleeText, GetDamage()));
        }
        public int GetDamage() {
            return random.Next(50, 250);
        }
    }

    class Program {
        public static Random random = new Random();
        static void Main() {
            
            // Now create a list of of objects of type Iface
            List<Iface> mylist = new List<Iface>();
            // Add objects of both Melee and Spell type.
            mylist.Add(new Spell(random.Next()));
            mylist.Add(new Melee(random.Next()));
            mylist.Add(new Melee(random.Next()));
            mylist.Add(new Melee(random.Next()));
            mylist.Add(new Spell(random.Next()));
            mylist.Add(new Spell(random.Next()));
            mylist.Add(new Spell(random.Next()));

            // Loops through each calling the Iface defined
            // method Execute() on each.
            foreach (Iface item in mylist) {
                item.Execute();
            }
        }
    }
}
