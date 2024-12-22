class Leaderboard {
    List<LeaderboardItem> leaderboard;

    public Leaderboard() {
        leaderboard = new List<LeaderboardItem>();
    }
    public void printHistory(int type) {

    }

    public LeaderboardItem createItem() {
        return new LeaderboardItem();
    }



    public class LeaderboardItem {
        int score;
        List<String> history;
        int gamemode;


        public int getScore() {
            return 0;
        }

        


    }


}