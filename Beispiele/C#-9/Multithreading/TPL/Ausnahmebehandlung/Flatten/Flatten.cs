using System;
using System.Threading.Tasks;

class HarmlessException : Exception {
    public HarmlessException(String message) : base(message) { }
}
class SeriousException : Exception {
    public SeriousException(String message) : base(message) { }
}

class FlattenDemo {
    static void WithChildTasks() {
        Task t1 = Task.Factory.StartNew(
          () => { int i = 0; int j = 12 / i; },
          TaskCreationOptions.AttachedToParent);
        Task t2 = Task.Factory.StartNew(
          () => { throw new HarmlessException("Harmlos"); },
          TaskCreationOptions.AttachedToParent);
        throw new SeriousException("Ernstfall");
    }


    static bool InternalExceptionHandler(Exception e) {
        Console.WriteLine(e.Message);
        return true;
    }

    static void Main() {
        Task t = Task.Factory.StartNew(WithChildTasks);
        try {
            t.Wait();
        } catch (AggregateException ae) {
            ae.Flatten().Handle(InternalExceptionHandler);
        }
    }
}
