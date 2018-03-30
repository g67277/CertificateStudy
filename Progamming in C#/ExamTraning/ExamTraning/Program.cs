using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Chapter1 {
    public static class Program {

        #region Example 1 - Creating a Thread with the Thread Class
        //public static void ThreadMethod() {
        //    for (int i = 0; i < 10; i++) {
        //        Console.WriteLine("ThreadProc: {0}", i);
        //        Thread.Sleep(0);
        //    }
        //}
        #endregion

        #region Example 3 - Using the ParameterizedThreadStart
        //public static void ThreadMethod(object o){
        //    for (int i = 0; i < (int)o; i++) {
        //        Console.WriteLine("ThreadProc: {0}", i);
        //        Thread.Sleep(0);
        //    }
        //}
        #endregion


        [ThreadStatic]
        public static int _field;

        public static ThreadLocal<int> _fieldThreadLocal = new ThreadLocal<int>(() => {
            return Thread.CurrentThread.ManagedThreadId;
        });

        public static void Main(string[] args) {

            #region Example 3 - Using the ParameterizedThreadStart
            //Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //t.Start(5);
            #endregion

            #region Example 4 - Stopping a thread
            //bool stopped = false;
            //Thread t = new Thread(new ThreadStart(() => {
            //    while (!stopped) {
            //        Console.WriteLine("Running...");
            //        Thread.Sleep(1000);
            //    }
            //}));

            //t.Start();
            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();

            //stopped = true;
            //t.Join();

            #endregion

            #region Example 5 - Using the Thread Static Attribute
            //new Thread(() => {
            //    for (int i = 0; i < 10; i++) {
            //        _field++;
            //        Console.WriteLine("Thread A: {0}", _field);
            //    }
            //}).Start();

            //new Thread(() => {
            //    for (int i = 0; i < 10; i++) {
            //        _field++;
            //        Console.WriteLine("Thread B: {0}", _field);
            //    }
            //}).Start();
            //Console.ReadKey();

            #endregion

            #region Example 6 - Using ThreadLocal<T>
            //new Thread(() => {
            //    for (int i = 0; i < _fieldThreadLocal.Value; i++) {
            //        Console.WriteLine("Thread A: {0}", i);
            //    }
            //}).Start();
            //new Thread(() => {
            //    for (int i = 0; i < _fieldThreadLocal.Value; i++) {
            //        Console.WriteLine("Thread B: {0}", i);
            //    }
            //}).Start();
            //Console.ReadKey();
            #endregion

            #region Example 7 - Queuing some work to the thread pool
            //ThreadPool.QueueUserWorkItem((s) => {
            //    Console.WriteLine("Working on a thread from threadpool");
            //});
            //Console.ReadLine();
            #endregion

            #region Example 8 - Starting a new Task
            //Task t = Task.Run(() => {
            //    for (int x = 0; x < 100; x++) {
            //        Console.Write('*');
            //    }
            //});

            //t.Wait();
            #endregion

            #region Example 9 - Using a task that returns a value
            //Task<int> t = Task.Run(() => {
            //    return 42;
            //});
            //Console.WriteLine(t.Result);
            #endregion

            #region Example 10 - Adding a continuation
            //Task<int> t = Task.Run(() => {
            //    return 42;
            //}).ContinueWith((i) => {
            //    return i.Result * 2;
            //});
            //Console.WriteLine(t.Result);
            #endregion

            #region Example 11 - Scheduling different continuation tasks
            //Task<int> t = Task.Run(() => {
            //    return 42;
            //});

            //t.ContinueWith((i) => {
            //    Console.WriteLine("Canceled");
            //}, TaskContinuationOptions.OnlyOnCanceled);
            //t.ContinueWith((i) => {
            //    Console.WriteLine("Faulted");
            //}, TaskContinuationOptions.OnlyOnFaulted);
            //var completedTask = t.ContinueWith((i) => {
            //    Console.WriteLine("Complete");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            //completedTask.Wait();

            #endregion

            #region Example 12 - Attaching child tasks to a parent task
            //Task<int[]> parent = Task.Run(() => {
            //    var results = new int[3];
            //    new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

            //    return results;
            //});

            //var finalTask = parent.ContinueWith(
            //    parentTask => {
            //        foreach (int i in parentTask.Result)
            //            Console.WriteLine(i);
            //    });

            //finalTask.Wait();
            #endregion

            #region Example 13 - Using a Task Factory

            //Task<int[]> parent = Task.Run(() => {
            //    var results = new int[3];
            //    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
            //    tf.StartNew(() => results[0] = 0);
            //    tf.StartNew(() => results[1] = 1);
            //    tf.StartNew(() => results[2] = 2);

            //    return results;
            //});

            //var finalTask = parent.ContinueWith(
            //    parentTask => {
            //        foreach (int i in parentTask.Result)
            //            Console.WriteLine(i);
            //    });

            //finalTask.Wait();
            #endregion

            #region Example 14 - Using Task.WaitAll
            //Task[] tasks = new Task[3];

            //tasks[0] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("1");
            //    return 1;
            //});
            //tasks[1] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("2");
            //    return 1;
            //});
            //tasks[2] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("3");
            //    return 1;
            //});
            //Task.WaitAll(tasks);
            #endregion

            #region Example 15 - Task.WaitAny
            //Task<int>[] tasks = new Task<int>[3];
            //tasks[0] = Task.Run(() => {
            //    Thread.Sleep(2000);
            //    return 1;
            //});
            //tasks[1] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    return 2;
            //});
            //tasks[2] = Task.Run(() => {
            //    Thread.Sleep(3000);
            //    return 3;
            //});

            //while (tasks.Length > 0){
            //    int i = Task.WaitAny(tasks);
            //    Console.WriteLine(i);
            //    Task<int> completedTask = tasks[i];
            //    Console.WriteLine(completedTask.Result);
            //    var temp = tasks.ToList();
            //    temp.RemoveAt(i);
            //    tasks = temp.ToArray();
            //}
            #endregion

            #region Example 16 - using Parallel.For and Parallel.ForEach
            //Parallel.For(0, 10, i => {
            //    Thread.Sleep(1000);
            //});

            //var numbers = Enumerable.Range(0, 10);
            //Parallel.ForEach(numbers, i => {
            //    Thread.Sleep(1000);
            //});
            #endregion

            #region Example 17 - Using Parallel.Break
            //ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopstate) => {
            //    if (i == 500) {
            //        Console.WriteLine("Breaking loop");
            //        loopstate.Break();
            //    }
            //    return;
            //});
            #endregion

            #region Example 18 - async and await
            //string result = DownloadContent().Result;
            //Console.WriteLine(result);
            #endregion

            #region Example 19 - Scalability vs. Responsiveness

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

            #region Example 

            #endregion

        }

        #region Example 18 - async and await
        //public static async Task<string> DownloadContent(){
        //    using (HttpClient client = new HttpClient()){
        //        string result = await client.GetStringAsync("http://www.microsoft.com");
        //        return result;
        //    }
        //}
        #endregion
    }
}
