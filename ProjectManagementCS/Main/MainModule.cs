using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementCS.dao;
using ProjectManagementCS.entity;

namespace ProjectManagementCS.main
{
    class ProjectApp
    {
        static void Main(string[] args)
        {
            IProjectRepository repo = new ProjectRepositoryImpl();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n1. Add Employee\n2. Add Project\n3. Add Task\n4. Assign Project to Employee\n5. Assign Task\n6. Delete Employee\n7. Delete Project\n8. Get Employee Tasks\n9. Exit\nChoose option:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Designation: "); string desg = Console.ReadLine();
                        Console.Write("Gender: "); string gender = Console.ReadLine();
                        Console.Write("Salary: "); double sal = double.Parse(Console.ReadLine());
                        bool added1 = repo.CreateEmployee(new Employee { Name = name, Designation = desg, Gender = gender, Salary = sal });
                        Console.WriteLine(added1 ? "Employee Created Sucessfully." : "Failed to Create Employee.");
                        break;
                    case 2:
                        Console.Write("Project Name: "); string pname = Console.ReadLine();
                        Console.Write("Desc: "); string desc = Console.ReadLine();
                        Console.Write("Start Date: "); DateTime sdate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Status: "); string status = Console.ReadLine();
                        bool added2 = repo.CreateProject(new Project { ProjectName = pname, Description = desc, StartDate = sdate, Status = status });
                        Console.WriteLine(added2 ? "Project Created Sucessfully." : "Failed to Create Project.");
                        break;
                    case 3:
                        Console.Write("Task Name: "); string tname = Console.ReadLine();
                        Console.Write("Project ID: "); int tpid = int.Parse(Console.ReadLine());
                        Console.Write("Employee ID: "); int teid = int.Parse(Console.ReadLine());
                        Console.Write("Status (Assigned/Started/Completed): "); string tstatus = Console.ReadLine();
                        Console.Write("Allocation Date (yyyy-mm-dd): "); DateTime alloc = DateTime.Parse(Console.ReadLine());
                        Console.Write("Deadline Date (yyyy-mm-dd): "); DateTime ddl = DateTime.Parse(Console.ReadLine());
                        bool added3 = repo.CreateTask(new ProjectManagementCS.entity.EntityTask { TaskName = tname, ProjectId = tpid, EmployeeId = teid, Status = tstatus, AllocationDate = alloc, DeadlineDate = ddl });
                        Console.WriteLine(added3 ? "Task Created Sucessfully." : "Failed to Create Task.");
                        break;

                    case 4:
                        Console.Write("Project ID: "); int apid = int.Parse(Console.ReadLine());
                        Console.Write("Employee ID: "); int aeid = int.Parse(Console.ReadLine());
                        bool assign1 = repo.AssignProjectToEmployee(aeid, apid);
                        Console.WriteLine(assign1 ? "Project Assigned to Employee" : "Failed to Assign Project.");
                        break;

                    case 5:
                        Console.Write("Task ID: "); int tid = int.Parse(Console.ReadLine());
                        Console.Write("Project ID: "); int prjId = int.Parse(Console.ReadLine());
                        Console.Write("Employee ID: "); int empId = int.Parse(Console.ReadLine());
                        bool assign2 = repo.AssignTaskInProjectToEmployee(tid, prjId, empId);
                        Console.WriteLine(assign2 ? "Task Assigned to Employee" : "Failed to Assign Task.");
                        break;

                    case 6:
                        Console.Write("Employee ID: "); int delEmpId = int.Parse(Console.ReadLine());
                        bool delete1 = repo.DeleteEmployee(delEmpId);
                        Console.WriteLine(delete1 ? "Employee Deleted Sucessfully" : " ");
                        break;

                    case 7:
                        Console.Write("Project ID: "); int delProjId = int.Parse(Console.ReadLine());
                        bool delete2 = repo.DeleteProject(delProjId);
                        Console.WriteLine(delete2 ? "Project Deleted Sucessfully" : " ");
                        break;

                    case 8:
                        Console.Write("Employee ID: "); int getEmpId = int.Parse(Console.ReadLine());
                        Console.Write("Project ID: "); int getProjId = int.Parse(Console.ReadLine());
                        List<ProjectManagementCS.entity.EntityTask> tasks = repo.GetAllTasks(getEmpId, getProjId);
                        Console.WriteLine($"Tasks for Employee {getEmpId} in Project {getProjId}:");
                        foreach (var t in tasks)
                        {
                            Console.WriteLine($"Task ID: {t.TaskId}, Name: {t.TaskName}, Status: {t.Status}, Deadline: {t.DeadlineDate.ToShortDateString()}");
                        }
                        break;

                    case 9:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}