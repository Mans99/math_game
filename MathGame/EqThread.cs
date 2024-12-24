using System;

class EqThread {
    GameMonitor monitor;
    Random rand = new Random();
    int a;
    int b;
    String ans;
    String eq;
    CancellationToken token;

    public EqThread(GameMonitor monitor) {
        this.monitor = monitor;
        this.token = token;
    }



    public void Run(int mode, CancellationToken token) {
        int m = mode;
        while(!monitor.hasEnded()) {
            if(mode == 5) {
                m = rand.Next(1,4);
            }

            switch(m) {
                case 1:
                    addition();
                    break;
                case 2:
                    subtraction();
                    break;
                case 3:
                    division();
                    break;
                default:
                    multiplication();
                    break;
            }

        }
    }

    void setRand(int n) {
        a = rand.Next(1, n);
        b = rand.Next(1, n);
    }
    

    void addition() {
        setRand(10);
        eq = $"{a} + {b}";
        Console.WriteLine(eq);
        ans = WaitForInputWithTimeout();
        if($"{a+b}".Equals(ans)) {
            monitor.correct(eq, a + b, ans);
        } else {
            monitor.wrong(eq, a + b, ans);
        }
    }

    void subtraction() {
        setRand(10);
        eq = $"{a} - {b}";
        Console.WriteLine(eq);
        ans = WaitForInputWithTimeout();
        if($"{a-b}".Equals(ans)) {
            monitor.correct(eq, a - b, ans);
        } else {
            monitor.wrong(eq, a - b, ans);
        }
    }

    void division() {
        setRand(30);
        do{
            setRand(30);
        }while(a%b != 0);
        eq = $"{a} / {b}";
        Console.WriteLine(eq);
        ans = WaitForInputWithTimeout();
        if($"{a/b}".Equals(ans)) {
            monitor.correct(eq, a / b, ans);
        } else {
            monitor.wrong(eq, a / b, ans);
        }
    }

    void multiplication() {
        setRand(10);
        eq = $"{a} * {b}";
        Console.WriteLine(eq);
        ans = WaitForInputWithTimeout();
        if($"{a*b}".Equals(ans)) {
            monitor.correct(eq, a * b, ans);
        } else {
            monitor.wrong(eq, a * b, ans);
        }
    }


    private string WaitForInputWithTimeout()
    {
        string input = "";
        DateTime start = DateTime.Now;

        while (!token.IsCancellationRequested)
        {
            if (Console.KeyAvailable) // Check if a key is pressed
            {
                input = Console.ReadLine(); // Read input
                break;
            }

            // Optional: Exit if waiting exceeds a threshold (to prevent infinite loops in testing)
            if ((DateTime.Now - start).TotalSeconds > 10) break;

            Thread.Sleep(50); // Avoid busy waiting by adding a small delay
        }

        return input;
    }
}