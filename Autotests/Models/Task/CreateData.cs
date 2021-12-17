namespace Autotests.Models.Task
{
    public class CreateData
    {
        public TaskData TaskData { get; }

        public CreateData(TaskData taskData)
        {
            TaskData = taskData;
        }
    }
}