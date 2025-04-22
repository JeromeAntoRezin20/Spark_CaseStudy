using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementCS.entity;


namespace ProjectManagementCS.dao
{
    public interface IProjectRepository
    {
        bool CreateEmployee(Employee emp);
        bool CreateProject(Project proj);
        bool CreateTask(EntityTask task);
        bool AssignProjectToEmployee(int empId, int projectId);
        bool AssignTaskInProjectToEmployee(int taskId,int projectId, int empId);
        bool DeleteEmployee(int empId);
        bool DeleteProject(int projectId);
        List<EntityTask> GetAllTasks(int empId, int projectId);
    }
}
