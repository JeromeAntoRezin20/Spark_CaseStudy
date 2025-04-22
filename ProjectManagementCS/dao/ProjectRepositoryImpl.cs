using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectManagementCS.entity;
using ProjectManagementCS.util;
using ProjectManagementCS.myexceptions;


namespace ProjectManagementCS.dao
{
    public class ProjectRepositoryImpl : IProjectRepository
    {
        public bool CreateEmployee(Employee emp)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "INSERT INTO Employee (Name, Designation, Gender, Salary, Project_Id) VALUES (@Name, @Designation, @Gender, @Salary, @ProjectId)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Designation", emp.Designation);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@ProjectId", emp.ProjectId ?? (object)DBNull.Value);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool CreateProject(Project proj)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "INSERT INTO Project (ProjectName, Description, StartDate, Status) VALUES (@Name, @Desc, @StartDate, @Status)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", proj.ProjectName);
            cmd.Parameters.AddWithValue("@Desc", proj.Description);
            cmd.Parameters.AddWithValue("@StartDate", proj.StartDate);
            cmd.Parameters.AddWithValue("@Status", proj.Status);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool CreateTask(EntityTask task)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "INSERT INTO Task (Task_Name, Project_Id, Employee_Id, Status, AllocationDate, DeadlineDate) VALUES (@Name, @ProjId, @EmpId, @Status, @AllocDate, @Deadline)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", task.TaskName);
            cmd.Parameters.AddWithValue("@ProjId", task.ProjectId);
            cmd.Parameters.AddWithValue("@EmpId", task.EmployeeId);
            cmd.Parameters.AddWithValue("@Status", task.Status);
            cmd.Parameters.AddWithValue("@AllocDate", task.AllocationDate);
            cmd.Parameters.AddWithValue("@Deadline", task.DeadlineDate);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool AssignProjectToEmployee(int empId, int projectId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "UPDATE Employee SET Project_Id = @ProjId WHERE Id = @EmpId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProjId", projectId);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            if (cmd.ExecuteNonQuery() == 0) throw new EmployeeNotFoundException("Employee not found");
            return true;
        }

        public bool AssignTaskInProjectToEmployee(int taskId,int projectId, int empId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "UPDATE Task SET Employee_Id = @EmpId WHERE Task_Id = @TaskId AND Project_Id = @ProjId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters.AddWithValue("@TaskId", taskId);
            cmd.Parameters.AddWithValue("@ProjId", projectId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteEmployee(int empId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "DELETE FROM Employee WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", empId);
            if (cmd.ExecuteNonQuery() == 0) throw new EmployeeNotFoundException("Employee not found");
            return true;
        }

        public bool DeleteProject(int projectId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "DELETE FROM Project WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", projectId);
            if (cmd.ExecuteNonQuery() == 0) throw new ProjectNotFoundException("Project not found");
            return true;
        }

        public List<EntityTask> GetAllTasks(int empId, int projectId)
        {
            List<EntityTask> tasks = new();
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Task WHERE Employee_Id = @EmpId AND Project_Id = @ProjId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters.AddWithValue("@ProjId", projectId);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tasks.Add(new EntityTask
                {
                    TaskId = (int)reader["Task_Id"],
                    TaskName = (string)reader["Task_Name"],
                    ProjectId = (int)reader["Project_Id"],
                    EmployeeId = (int)reader["Employee_Id"],
                    Status = (string)reader["Status"],
                    AllocationDate = (DateTime)reader["AllocationDate"],
                    DeadlineDate = (DateTime)reader["DeadlineDate"]
                });
            }
            return tasks;
        }
    }
}
