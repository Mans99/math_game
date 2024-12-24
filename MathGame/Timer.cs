class TimerThread {
    GameMonitor monitor;

    public TimerThread(GameMonitor monitor) {
        this.monitor = monitor;
    }

    public void Run() {
        Thread.Sleep(20000);
        monitor.end();
    }
}