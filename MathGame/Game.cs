/*
depending on gamemode 1 = add, 2 = sub, 3 = div, 4 = mull & 5 = rand
monitor?
varje game får en monitor och en timer samt en game metod, end when timeout.
*/

using System.Reflection;
using System.Runtime.CompilerServices;
using static Leaderboard;

class GameMonitor {
    Semaphore sem = new Semaphore(1,1);
    Boolean ended = false;
    Leaderboard l;
    LeaderboardItem item;
    EqThread eqt;
    TimerThread time;
    Thread t1;
    Thread t2;
    CancellationTokenSource token = new CancellationTokenSource();

    public GameMonitor(Leaderboard l) {
        this.l = l;
        eqt = new EqThread(this);
        time = new TimerThread(this);
    }    

    public bool hasEnded() {
        return ended;
    }

    public void lockConsole() {
        sem.WaitOne();
    }

    public void unlockConsole() {
        sem.Release();
    }

    public void play(int mode){
        lockConsole();
        token = new CancellationTokenSource();
        item = l.createItem();
        t1 = new Thread(() => eqt.Run(mode, token.Token));
        t2 = new Thread(() => time.Run());
        t1.Start();

    }

    public void end() {
        token.Cancel();
    }

    internal void correct(string eq, int v, String ans)
    {
        item.setScore(1);
    }

    internal void wrong(string eq, int v, String ans)
    {   
        item.setScore(-2);
    }
}