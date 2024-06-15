namespace escape4u.Tasks
{
    public interface IBehaviorTask<T>
    {
        public void StartTask(T taskDelegate);
        public void FinishTask();
    }
}