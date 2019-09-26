using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskEngineLib
{
    public class Task : ITask 
    {
        public List<ITask> childTasks { get; set; }
        public TaskState taskState { get; set; }
        public string Name { get; set; }
        public TaskToRun taskToRun { get; set; }

        public Task(string name)
        {
            Name = name;
            childTasks = new List<ITask>();
            taskState = TaskState.Idle;
        }

        public void AddChildTask(ITask childTask)
        {
            childTasks.Add(childTask);
        }

        //If Run is called with task at null, then this is the root
        public void Run(ITask task)
        {
            //Here is the protection again circular references, and multiple execution
            //The solution chosen, is to stop running dependent child tasks when already ran,
            //An error could be returned, but I choose the quicker implementation 
            if ((task != null) && (task.taskState == TaskState.Ran)) return;

            foreach(ITask childTask in childTasks)
            {
                if (childTask.taskState != TaskState.Ran)
                {
                    childTask.taskState = TaskState.Running;
                    childTask.Run(childTask);
                }
            }
                        
            if (taskToRun != null) taskToRun();
            taskState = TaskState.Ran;
        }
    }
}
