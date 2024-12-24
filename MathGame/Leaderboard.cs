class Leaderboard {
    List<LeaderboardItem> leaderboard;
    LeaderboardItem best;

    public Leaderboard() {
        leaderboard = new List<LeaderboardItem>();
    }
    public void printHistory(int type) {

    }

    public LeaderboardItem createItem() {
        return new LeaderboardItem();
    }



    public class LeaderboardItem {
        int score = 0;
        List<String> history;
        int gamemode;


        public int getScore() {
            return 0;
        }

        public void setScore(int delta) {
            score += delta;
        }

        


    }


}