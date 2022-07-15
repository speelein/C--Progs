using System;
using System.Threading.Tasks;

class DebuggingTaskExceptions {
    static void Main() {
        var task = Task.Factory.StartNew(() => { int i = 0; int j = 12 / i; });
        try {
            task.Wait();
        } catch (Exception ex) { 
            Console.WriteLine(ex.Message);
        }
     }
}
