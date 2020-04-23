using CalendarApp.Db;
using CalendarApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalendarApp.Service.Test
{
    [TestClass]
    public class EventManagerServiceTest
    {
        private const string TestDb = "eventTest1";
        private IUnitOfWorkFactory GetUnitOfWorkFactory(string database)
        {
            var mockUnitOfWorkFactory = new Mock<IUnitOfWorkFactory>();

            mockUnitOfWorkFactory.Setup(x => x.Get()).Returns(new MemoryDbContext(database));
            return mockUnitOfWorkFactory.Object;
        }

        [TestInitialize]
        public void SetupDatabase()
        {
            var factory = GetUnitOfWorkFactory(TestDb);
            // Fill Data
            using (var unitOfWork = factory.Get())
            {
                var context = unitOfWork.GetContext<MemoryDbContext>();
                var user = new AppUser() { UserName = "admin", Id = 1, Deleted = false };
                context.Set<AppUser>().Add(user);
                var startDate = new DateTime(2020, 4, 24, 17, 00, 00);
                var endDate = new DateTime(2020, 4, 24, 17, 40, 00);
      
                context.Set<EventSchedule>().Add(new EventSchedule() { Id = 1, Name = "Event1", StartDateTime = startDate, EndDateTime = endDate, Organizer = user });
                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            var factory = GetUnitOfWorkFactory(TestDb);
            // Fill Data
            using (var unitOfWork = factory.Get())
            {
                var context = unitOfWork.GetContext<MemoryDbContext>();
                context.Database.EnsureDeleted();
            }

        }
    
        [TestMethod]
        public void ShouldGiveFalseIfNoOverlappingEventWhenNewEventToBeAfterScheduledEvent()
        {
            var mockUser = new GenericRepository<AppUser>();
            var mockEvent = new GenericRepository<EventSchedule>();
            var factory = GetUnitOfWorkFactory(TestDb);
            var service = new EventAdminService(factory, mockUser, mockEvent);
            var testStartDate = new DateTime(2020, 4, 24, 19, 40, 00);
            var testEndDate = new DateTime(2020, 4, 24, 19, 50, 00);
            var startDate = new DateTime(2020, 4, 24);
            var result = service.IsOverlappingEvent("admin", startDate, "07:40 PM", "07:50 PM");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldGiveFalseIfNoOverlappingEventWhenNewEventToBeBeforeScheduledEvent()
        {
            var mockUser = new GenericRepository<AppUser>();
            var mockEvent = new GenericRepository<EventSchedule>();
            var factory = GetUnitOfWorkFactory(TestDb);
            var service = new EventAdminService(factory, mockUser, mockEvent);
            var startDate = new DateTime(2020, 4, 24);
            var result = service.IsOverlappingEvent("admin", startDate, "04:40 PM", "05:00 PM");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldGiveTrueIfNOverlappingEventScenario1()
        {
            var mockUser = new GenericRepository<AppUser>();
            var mockEvent = new GenericRepository<EventSchedule>();
            var factory = GetUnitOfWorkFactory(TestDb);
            var service = new EventAdminService(factory, mockUser, mockEvent);
            var startDate = new DateTime(2020, 4, 24);
            var result = service.IsOverlappingEvent("admin", startDate, "04:40 PM", "05:20 PM");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldGiveTrueIfNOverlappingEventScenario2()
        {
            var mockUser = new GenericRepository<AppUser>();
            var mockEvent = new GenericRepository<EventSchedule>();
            var factory = GetUnitOfWorkFactory(TestDb);
            var service = new EventAdminService(factory, mockUser, mockEvent);
            var startDate = new DateTime(2020, 4, 24);
            var result = service.IsOverlappingEvent("admin", startDate, "05:20 PM", "05:35 PM");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldGiveTrueIfNOverlappingEventScenario3()
        {
            var mockUser = new GenericRepository<AppUser>();
            var mockEvent = new GenericRepository<EventSchedule>();
            var factory = GetUnitOfWorkFactory(TestDb);
            var service = new EventAdminService(factory, mockUser, mockEvent);
            var startDate = new DateTime(2020, 4, 24);
            var result = service.IsOverlappingEvent("admin", startDate, "05:35 PM", "06:35 PM");
            Assert.IsTrue(result);
        }
    }
}
