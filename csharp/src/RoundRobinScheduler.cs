public class Process
{
    public int Id { get; set; }
    public int BurstTime { get; set; }
    public int RemainingTime { get; set; }
    public int CompletionTime { get; set; }
    public int TurnaroundTime { get; set; }
    public int WaitingTime { get; set; }

    public Process(int id, int burstTime)
    {
        Id = id;
        BurstTime = burstTime;
        RemainingTime = burstTime;
    }
}

public class RoundRobinScheduler
{
    public static void Main(string[] args)
    {
        var processes = new List<Process>
        {
            new Process(1, 10),
            new Process(2, 4),
            new Process(3, 5),
            new Process(4, 7)
        };

        var quantum = 3;

        RoundRobin(processes, quantum);
        PrintResults(processes);
    }

    public static void RoundRobin(List<Process> processes, int quantum)
    {
        var queue = new Queue<Process>(processes);
        var currentTime = 0;

        while (queue.Count > 0)
        {
            var currentProcess = queue.Dequeue();

            if (currentProcess.RemainingTime > quantum)
            {
                currentTime += quantum;
                currentProcess.RemainingTime -= quantum;
                queue.Enqueue(currentProcess);
            }
            else
            {
                currentTime += currentProcess.RemainingTime;
                currentProcess.CompletionTime = currentTime;
                currentProcess.TurnaroundTime = currentProcess.CompletionTime;
                currentProcess.WaitingTime =
                    currentProcess.TurnaroundTime - currentProcess.BurstTime;
                currentProcess.RemainingTime = 0;
            }
        }
    }

    public static void PrintResults(List<Process> processes)
    {
        Console.WriteLine("PID\tBurst\tCompletion\tTurnaround\tWaiting");
        foreach (var process in processes)
        {
            Console.WriteLine(
                $"{process.Id}\t{process.BurstTime}\t{process.CompletionTime}\t\t{process.TurnaroundTime}\t\t{process.WaitingTime}"
            );
        }
    }
}
