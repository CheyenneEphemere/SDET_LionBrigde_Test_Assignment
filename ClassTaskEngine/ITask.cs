using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEngineLib
{
    public enum TaskState { Idle, Running, Ran }

    //As I can assume that the task to run is a method with no parameter and returning void
    //here is below the corresponding delegate.
    public delegate void TaskToRun();
    
    public interface ITask
    {
        string Name { get; set; }
        List<ITask> childTasks { get; set; }
        TaskState taskState { get; set; }
        TaskToRun taskToRun { get; set; }
        void Run(ITask task);
    }
}
