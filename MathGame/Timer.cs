class TimerThread {
    GameMonitor? monitor;
    CancellationToken token;

    public TimerThread(GameMonitor monitor) {
        this.monitor = monitor;
        this.token = token;
    }

    public void Run() {
        Thread.Sleep(20000);
        monitor.end();
    }
}