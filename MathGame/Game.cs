/*
depending on gamemode 1 = add, 2 = sub, 3 = div, 4 = mull & 5 = rand
monitor?
varje game får en monitor och en timer samt en game metod, end when timeout.
*/

using System.Reflection;
using System.Runtime.CompilerServices;
using static Leaderboard;

class GameMonitor {
    Boolean ended = false;
    Leaderboard l;
    LeaderboardItem item;

    public GameMonitor(Leaderboard l) {
        this.l = l;
    }    
    bool hasEnded() {
        return ended;
    }





    public void play(int mode){
        item = l.createItem();

    }

    

}