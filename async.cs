using System;
using System.Threading.Tasks;

/*
The following is my study of async methods.

There are three types of async programming.
* Asynchronous Programming Model (APM) pattern,
* Event-based Asynchronous Pattern (EAP)
* The most recent one, Task-based Asynchronous Pattern (TAP).
(TAP) is the preferred use of async in c# as it uses
the async / await pattern.

By convention all async method names should
end with the word Async.  Example:  GetUserAsync()

Async method return values can be void, Task, and
Task<T> where as the T is the the type returned.
For instance.  static async Task<int> GetNumberAsync();

An important note here is that even though returning void
in an async method is allowed, it should not be used in
most cases, as the other 2 return types Task and Task<T>
represent void and T subsequently, after the awaitable method
completes and returns result. So the use of void as return type
should be only limited for event handlers.

If you run an async method and return a Task.  You can check
the task (for instance Task<T>) for T.Completed to see if it
finished.

Finally, if you want the result of the returned Task<T> it's T.Result.
 */
class Program {
    static void Main() {
        // get epoch seconds for now.
        int epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        // create next add 1 second
        int next = epoch + 1;
        // call async method.
        var a = ExampleAsync();
        Console.WriteLine("Async task started.");
        while (true) {
            // print tick each second until the async method completes.
            if ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds >= next) {
                Console.WriteLine("Tick");
                next++;
            }
            if (a.IsCompleted) {
                Console.WriteLine("The async method has completed");
                Console.WriteLine(a.Result);
                break;
            }
        }
    }
    /*  By convention, all async method's names should end
        with the word Async.  Example: DoThisAsync() */
    static async Task<int> ExampleAsync() {
        var x = await Task.Run(() => EatTime());
        // Ignore return value.  Console.WriteLine("It took: " + x);
        return x;
    }

    static int EatTime() {
        int size = 0;
        for (int z = 0; z < 250; z++) {
            for (int i = 0; i < 100000; i++) {
                string value = i.ToString();
                size += value.Length;
            }
        }
        return size;
    }
}