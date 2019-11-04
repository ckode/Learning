using System;


/*
Figuring out how to create character varables from numeric
representation as we do in the SonzoTelnet in Python

Python Example:  x = chr(120)

In the example above, if your print the varable x out.  It will print
a literal x. As 13 = CR, 8 = backspace, 27 = escape, and 9 = tab.
 */
namespace Testing {
    class Program {
        static void Main() {
            // 100 represents a lowercase d.
            char c = (char)100;
            // prints a d to the console.
            Console.WriteLine(c);
        }
    }
}