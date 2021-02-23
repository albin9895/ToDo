//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using ToDoApplication.Entities.Repository;
//using ToDoApplication.Entity;
//using ToDoApplication.Service;

//namespace ToDoApplicationTestProject.TestMethods
//{
//    public class ToDoTest
//    {
//        private Mock<IRepository<ToDo>> toDoRepository;
//        private List<ToDo> toDos;

//        [SetUp]
//        public void Setup()
//        {
//            toDoRepository = new Mock<IRepository<ToDo>>();
//            toDos = new List<ToDo>();
//            toDos.Add(new ToDo() {  Id = 1 , TaskName = "Drink Water" });
//            toDos.Add(new ToDo() {  Id = 2 , TaskName = "Do Work" });
//            toDos.Add(new ToDo() {  Id = 3 , TaskName = "Drink Water" });
//            toDos.Add(new ToDo() {  Id = 4 , TaskName = "Drink Water" });
//        }
//        [Test]
//        public void TestGetUsers()
//        {
//            toDoRepository.Setup(a => a.GetAll()).Returns(toDos.AsQueryable());
//            var ToDoService = new ToDoListService(toDoRepository.Object);
//            var ToDoList = ToDoService.Get();

//            Assert.IsTrue(ToDoList.Count == 4);

//        }
//    }
//}
