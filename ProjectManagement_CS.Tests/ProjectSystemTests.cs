using NUnit.Framework;
using NUnit.Framework.Legacy;
using ProjectManagementCS.dao;
using ProjectManagementCS.entity;
using ProjectManagementCS.myexceptions;
using System;
using System.Collections.Generic;

namespace ProjectManagement_CS.Tests
{
    [TestFixture]
    public class ProjectSystemTests
    {
        private IProjectRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new ProjectRepositoryImpl(); 
        }

        // 1. Employee Creation
        [Test]
        public void CreateEmployee_ShouldReturnTrue_WhenEmployeeIsValid()
        {
            var emp = new Employee
            {
                Name = "Test Employee",
                Designation = "Developer",
                Gender = "Female",
                Salary = 60000,
                ProjectId = null
            };

            bool result = _repository.CreateEmployee(emp);

            ClassicAssert.IsTrue(result, "Employee creation failed");
        }

        // 2. Task creation
        [Test]
        public void CreateTask_ShouldReturnTrue_WhenTaskIsValid()
        {
            var task = new EntityTask
            {
                TaskName = "Build UI",
                ProjectId = 3,
                EmployeeId = 6,
                Status = "Assigned",
                AllocationDate = DateTime.Today,
                DeadlineDate = DateTime.Today.AddDays(7)
            };

            bool result = _repository.CreateTask(task);

            ClassicAssert.IsTrue(result, "Task creation failed");
        }

        // 3. Get all Tasks
        [Test]
        public void GetAllTasks_ShouldReturnTasksList_WhenValidEmployeeAndProjectId()
        {
            int empId = 1;      
            int projectId = 1;  

            List<EntityTask> tasks = _repository.GetAllTasks(empId, projectId);

            ClassicAssert.IsNotNull(tasks, "Returned task list is null");
            ClassicAssert.IsTrue(tasks.Count >= 0, "Tasks count is invalid");
        }

        // 4a. Employee not found exception
        [Test]
        public void DeleteEmployee_ShouldThrowException_WhenEmployeeNotFound()
        {
            int nonExistentEmpId = 9999;

            Assert.Throws<EmployeeNotFoundException>(() => _repository.DeleteEmployee(nonExistentEmpId));
        }

        // 4b. Project not found exception
        [Test]
        public void DeleteProject_ShouldThrowException_WhenProjectNotFound()
        {
            int nonExistentProjectId = 9999;

            Assert.Throws<ProjectNotFoundException>(() => _repository.DeleteProject(nonExistentProjectId));
        }

        // 4c. Exception for assigning a project to a non-existent employee
        [Test]
        public void AssignProjectToEmployee_ShouldThrowException_WhenEmployeeNotFound()
        {
            int nonExistentEmpId = 9999;
            int projectId = 1; 

            Assert.Throws<EmployeeNotFoundException>(() => _repository.AssignProjectToEmployee(nonExistentEmpId, projectId));
        }
    }
}
