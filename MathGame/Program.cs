/*

depending on gamemode 1 = add, 2 = sub, 3 = div, 4 = mull & 5 = rand


*/
using System.Dynamic;
using static System.Net.Mime.MediaTypeNames;

class Program {
    Leaderboard l;
    Game game;

    public Program() {
        l = new Leaderboard();
        game = new Game();
    }




    static void Main(string[] args) {
        Program p = new Program();
        Console.WriteLine ("Welcome to Math Madness!");
        p.printMenu();
        while(true) {
            p.input();
        }
    }


    void input() {
        var choice = Console.ReadLine().ToLower();
        switch (choice)
        {
            case "h":
                Console.WriteLine("Welcome to Math Madness!\nThe rules are as follows: In 20 seconds you should try to answer as many equations as possible. Each correct answer gives one point while each wrong subtracts two... so be certain when you answer! Have fun and good luck!");
                break;
            case "1":
                game.play(l, 1);
                break;
            case "2":
                game.play(l, 1);
                break;
            case "3":
                game.play(l, 1);
                break;
            case "4":
                game.play(l, 1);
                break;
            case "5":
                game.play(l, 1);
                break;
            case "l":
                l.printHistory(0);
                break;
            case "l+":
                l.printHistory(1);
                break;
            case "q":
                Console.WriteLine("Are you sure you want to quit? y/n");
                choice = Console.ReadLine().ToLower();
                if (choice.Equals("y")) {
                    Environment.Exit(0);
                }
                break;
            default:
                Console.WriteLine("Invalid input, please enter one of the options below");
                printMenu();
                break;
        }


    }
    void printMenu() {
        Console.WriteLine("1   -   addition");
        Console.WriteLine("2   -   help");
        Console.WriteLine("3   -   addition");
        Console.WriteLine("4   -   help");
        Console.WriteLine("5   -   addition");
        Console.WriteLine("h   -   help");
        Console.WriteLine("l   -   leaderboard");
        Console.WriteLine("l+   -   detailed leaderboard");
        Console.WriteLine("q   -   quit");
    }

}
