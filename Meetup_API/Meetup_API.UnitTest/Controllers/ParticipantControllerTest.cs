//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Meetup_API.Web.Controllers;
//using Meetup_API.Services;
//using Meetup_API.Entities;
//using Moq;

//namespace Meetup_API.UnitTest.Controllers
//{
//    [TestClass]
//    public class ParticipantControllerTest
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }

//        /// <summary>    
//        /// This method used to get employee controller    
//        /// </summary>    
//        /// <param name="repository"></param>    
//        /// <returns></returns>    
//        [TestMethod]
//        public void GetAllParticipantFromRepository()
//        {
//            // Arrange    
//            Participant Participant1 = GetParticipantName(1, "Rahul Saxena", 30, new DateTime(1990,07,01), false, "Delhi", 2, "Address 1");
//            Participant Participant2 = GetParticipantName(2, "Abhishek Saxena", 40, new DateTime(1980,06,21), true, "Noida", 1,"Address 2");
//            ParticipantsService participantsService = new ParticipantsService();
//            participantsService.SaveParticipant(Participant1);
//            participantsService.SaveParticipant(Participant2);
//            var controller = GetEmployeeController(emprepository);
//            var result = controller.Index(null, null, null, null);
//            var datamodel = (IEnumerable<Employee>)result.ViewData.Model;
//            CollectionAssert.Contains(datamodel.ToList(), employee1);
//            CollectionAssert.Contains(datamodel.ToList(), employee2);
//        }

//        Participant GetParticipantName(int ID, string Name, int Age, DateTime DOB, Boolean Profession, string Locality, int NumGuests, string Address)
//        {
//            return new Participant
//            {      
//                ID = ID,
//                Name = Name,
//                Age = Age,
//                DOB = DOB,
//                Profession = Profession,
//                Locality = Locality,
//                NumGuests = NumGuests,
//                Address = Address
//            };
//        }
//    }
//}
