/*
depending on gamemode 1 = add, 2 = sub, 3 = div, 4 = mull & 5 = rand
monitor?
varje game får en monitor och en timer samt en game metod, end when timeout.
*/

using System.Reflection;
using System.Runtime.CompilerServices;
using static Leaderboard;

class GameMonitor
{
    Boolean ended = false;
    Leaderboard l;
    LeaderboardItem item;
    TimerThread time;
    Thread t;
    Random rand = new Random();
    String ans;
    String eq;
    int a;
    int b;

    public GameMonitor(Leaderboard l)
    {
        this.l = l;
        time = new TimerThread(this);
    }

    public bool hasEnded()
    {
        return ended;
    }

    public void play(int mode)
    {
        item = l.createItem();
        t = new Thread(() => time.Run());
        ended = false;
        t.Start();
        go(mode);
    }

    public void go(int mode)
    {
        int m = mode;
        while (!hasEnded())
        {
            if (mode == 5)
            {
                m = rand.Next(1, 4);
            }

            switch (m)
            {
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

    public void timeEnd()
    {
        ended = true;
    }

    public void end()
    {
        ended = true;
        Console.WriteLine($"Game over!\nYour score: {item.getScore()}");
    }

    internal void correct(string eq, int v, String ans)
    {
        item.setScore(1);
    }

    internal void wrong(string eq, int v, String ans)
    {
        item.setScore(-2);
    }


    void setRand(int n)
    {
        a = rand.Next(1, n);
        b = rand.Next(1, n);
    }


    void addition()
    {
        SolveEquation((x, y) => x + y, "+", 20);
    }

    void subtraction()
    {
        SolveEquation((x, y) => x - y, "-", 20);
    }

    void division()
    {
        SolveEquation((x, y) => x / y, "/", 30);
    }

    void multiplication()
    {
        SolveEquation((x, y) => x * y, "*", 10);
    }

    void SolveEquation(Func<int, int, int> operation, string operatorSymbol, int range)
    {
        setRand(range);
        if (operatorSymbol == "/" || operatorSymbol == "-")
        {
            // Ensure valid division or subtraction setup
            do
            {
                setRand(range);
            } while (operatorSymbol == "/" && a % b != 0); // Valid division only
        }

        eq = $"{a} {operatorSymbol} {b}";
        Console.WriteLine(eq);

        ans = WaitForInputWithTimeout();

        int correctAnswer = operation(a, b); // Perform the operation
        if ($"{correctAnswer}".Equals(ans))
        {
            correct(eq, correctAnswer, ans);
        }
        else
        {
            wrong(eq, correctAnswer, ans);
        }
    }

    private string WaitForInputWithTimeout()
    {
        string input = "";
        DateTime start = DateTime.Now;

        while (!hasEnded())
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
