using System;

namespace LearningInterfaces {
    public interface ILearn {
        void SetName(string name);
        string GetName();
        void PrintName();
    }

    /*
    Initializing a class that uses an Interface
    is done by using ": IFaceName" when defining
    the class as seen below.
    */
    public class Person : ILearn {
        private string Name;

        public void SetName(string name) {
            Name = name;
        }
        public string GetName() {
            return Name;
        }
        public void PrintName() {
            Console.WriteLine(Name);
        }
        /*
        Constructor. You can have several constructors for
        overloading purposes like the following that accept
        different parameters on initialization:

        public Person(string name) {};
        public Person(string name, int age) {};
        public Person(string fname, string lname, int age) {}
        etc
        */
        public Person(string name) {
            Name = name;
        }
        /*
        ReturnGarbage (method below) is not a part of the interface,
        yet still works. This is important if you are if you are using
        the interface for executing similar, but different objects.
        You may want the individual classes to have helper methods that
        may differ from one another, but the executor methods are still
        required to exist.  ie, obj.run() / obj.execute() yet different
        helper methods like say this interface:  Interface IAnimal
        then calling dog.wagtail() vs human.wavehand() which wouldn't
        be part of the interface because both objects do not have the
        same body parts, yet both may have obj.SetName() which would be
        part of the Interface.
        */
        public string ReturnGarbage() {
            return "Garbage";
        }
    }
    class Program {
        static void Main() {
            var p = new Person("Chris");
            p.PrintName();
            Console.WriteLine(p.GetName());
            p.SetName("David");
            p.PrintName();
            // Call to non-interface defined method of class
            Console.WriteLine(p.ReturnGarbage());
        }
    }
}