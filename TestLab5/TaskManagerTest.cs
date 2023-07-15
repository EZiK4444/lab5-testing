using lab5test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLab5
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }

        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new lab5test.Task("Test task");

            // Act
            _taskManager.AddTask(task);

            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new lab5test.Task("Test task");
            task.Id = 1;
            _taskManager.AddTask(task);

            // Act
            _taskManager.RemoveTask(1);

            // Assert
            Assert.AreEqual(0, _taskManager.GetTasks().Count);
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = new lab5test.Task("Task must be completed");
            task.Id = 1;
            _taskManager.AddTask(task);

            // Act
            _taskManager.MarkTaskAsCompleted(1);

            // Assert
            Assert.IsTrue(task.IsCompleted);
        }

        [Test]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new lab5test.Task("Task for testing 1");
            var task2 = new lab5test.Task("Task for testing 2");
            var task3 = new lab5test.Task("Bonus task for testing");
            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);
            _taskManager.AddTask(task3);

            // Act
            var tasks = _taskManager.GetTasks();

            // Assert
            Assert.AreEqual(3, tasks.Count);
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
            Assert.Contains(task3, tasks);
        }
    }
}