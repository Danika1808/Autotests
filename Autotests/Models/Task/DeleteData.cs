namespace Autotests.Models.Task
{
    public class DeleteData
    {
        public TaskData TaskData { get; }

        public DeleteData(TaskData taskData)
        {
            TaskData = taskData;
        }
    }
}