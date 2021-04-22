using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Meetup_API.Services;
using Moq;
using Meetup_API.DataAccess;
using Meetup_API.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Meetup_API.UnitTest.Services
{
    [TestClass]
    public class ParticipantsServiceTests
    {
        private readonly Mock<MeetupAPIDBContext> _meetupAPIDBContextMock = new Mock<MeetupAPIDBContext>();
        private ParticipantsService _participantsService;        

        Participant participant1 = new Participant
        {
            ID = 1,
            Name = "Ram",
            Age = 21,
            DOB = new DateTime(1989, 05, 11),
            Profession = true,
            Locality = "Mumbai",
            NumGuests = 1,
            Address = "Gore Gaon"
        };

        Participant participant2 = new Participant
        {
            ID = 2,
            Name = "Manohar",
            Age = 21,
            DOB = new DateTime(1989, 05, 11),
            Profession = true,
            Locality = "Delhi",
            NumGuests = 1,
            Address = "Gore Gaon"
        };

        [TestMethod]
        public  void GetParticipant_ShouldReturn_AllParticipants()
        {
            initTests();
            //Act
            List<Participant> participants = _participantsService.GetParticipants();

            //Assert
            Assert.AreEqual(2, participants.Count);
            Assert.AreEqual(participants[0].ID, participant1.ID);
            Assert.AreEqual(participants[1].ID, participant2.ID);
        }

        [TestMethod]
        public void GetParticipant_ByName()
        {
            //Arrange
            initTests();

            //Act
            List<Participant> participants = _participantsService.GetParticipants("Ram", "", 1);

            //Assert
            Assert.AreEqual(1, participants.Count);
            Assert.AreEqual(participant1.ID, participants[0].ID);
            Assert.AreEqual(participant1.Name, participants[0].Name);

            List<Participant> participants2 = _participantsService.GetParticipants("Ramesh", "", 1);
            //Assert
            Assert.AreEqual(0, participants2.Count);
        }

        [TestMethod]
        public void GetParticipant_ByLocality()
        {
            //Arrange
            initTests();

            //Act
            List<Participant> participants = _participantsService.GetParticipants("", "Delhi", 1);
           
            //Assert
            Assert.AreEqual(1, participants.Count);
            Assert.AreEqual(participant2.ID, participants[0].ID);
            Assert.AreEqual(participant2.Locality, participants[0].Locality);

            List<Participant> participants2 = _participantsService.GetParticipants("", "Agra", 1);
            //Assert
            Assert.AreEqual(0, participants2.Count);
        }

        [TestMethod]
        public void GetParticipant_ByLocality_N_ByName()
        {
            //Arrange
            initTests();

            //Act
            List<Participant> participants = _participantsService.GetParticipants("Manohar", "Delhi", 1);

            //Assert
            Assert.AreEqual(1, participants.Count);
            Assert.AreEqual(participant2.ID, participants[0].ID);
            Assert.AreEqual(participant2.Locality, participants[0].Locality);

            List<Participant> participants2 = _participantsService.GetParticipants("Ram", "Delhi", 1);
            //Assert
            Assert.AreEqual(0, participants2.Count);

            List<Participant> participants3 = _participantsService.GetParticipants("Manohar", "Mumbai", 1);
            //Assert
            Assert.AreEqual(0, participants3.Count);
        }

        [TestMethod]
        public void SaveParticipant()
        {
            //Arrange
            initTests();

            Participant p3 = new Participant {
                ID = 3,
                Name = "Vikas",
                Age = 21,
                DOB = new DateTime(1989, 05, 11),
                Profession = true,
                Locality = "Delhi",
                NumGuests = 1,
                Address = "Rohini"
            };
            //Act
            _participantsService.SaveParticipant(p3);
            //mockSet.Verify(m => m.Add(It.IsAny<Participant>()), Times.Once());
            //_meetupAPIDBContextMock.Verify(m => m.SaveChanges(), Times.Once());
            List<Participant> participants = _participantsService.GetParticipants();

            //Assert
            Assert.AreEqual(3, participants.Count);
            Assert.AreEqual(p3.ID, participants[2].ID);
            Assert.AreEqual(p3.Name, participants[2].Name);
            Assert.AreEqual(p3.Locality, participants[2].Locality);
        }
        
        public void initTests()
        {
            var mockSet = new Mock<DbSet<Participant>>();
            List<Participant> pList = new List<Participant>();
            pList.Add(participant1);
            pList.Add(participant2);
            var participantQueryable =  pList.AsQueryable();
            mockSet.As<IQueryable<Participant>>().Setup(m => m.Provider).Returns(participantQueryable.Provider);
            mockSet.As<IQueryable<Participant>>().Setup(m => m.Expression).Returns(participantQueryable.Expression);
            mockSet.As<IQueryable<Participant>>().Setup(m => m.ElementType).Returns(participantQueryable.ElementType);
            mockSet.As<IQueryable<Participant>>().Setup(m => m.GetEnumerator()).Returns(() => participantQueryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Participant>())).Returns((Participant p) =>
            {
                pList.Add(p);
                return p;
            });
            _meetupAPIDBContextMock.Setup(x => x.Set<Participant>()).Returns(mockSet.Object);
            //_meetupAPIDBContextMock.Setup(p => p.SaveChanges(It)).Returns(1);
            _participantsService = new ParticipantsService(_meetupAPIDBContextMock.Object);
           
        }
    }
}
