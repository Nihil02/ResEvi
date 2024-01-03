using ResEvi.Data;
using ResEvi.Data.DAO;
using ResEvi.Data.Entities;
using ResEvi.Exceptions;

namespace Tests.Data
{
    public sealed class AdvisorDAOTests
    {
        private AppDbContext GetContext()
        {
            return new AppDbContext(OptionsManager.Options);
        }

        [Fact]
        public async Task AdvisorDAO_Get_ReturnListOfAdvisors()
        {
            // Arrange
            await using var context = GetContext();
            context.Advisors.Add(MockDataProvider.fakeAdvisors[0]);
            context.SaveChanges();
            

            // Act
            var dao = new AdvisorDAO(context);
            var res = await dao.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Single(res);

        }

        [Fact]
        public async Task AdvisorDAO_Get_ReturnOneAdvisor()
        {

            // Arrange
            await using var context = GetContext();
            var advisor = MockDataProvider.fakeAdvisors[0];
            context.Advisors.Add(advisor);
            context.SaveChanges();
            var dao = new AdvisorDAO(context);

            // Act
            var res = await dao.Get(1);

            // Assert
            Assert.NotNull(res);
            Assert.StrictEqual(1, res.Id);

        }

        [Fact]
        public async Task AdvisorDAO_Delete_ReturnAdvisor()
        {
            // Arrange
            await using var context = GetContext();
            var dao = new AdvisorDAO(context);
            var advisor = MockDataProvider.fakeAdvisors[0];
            context.Add(advisor);
            context.SaveChanges();

            // Act
            await dao.Delete(1);

            // Assert
            _ = Assert.ThrowsAsync<EntityNotFoundException>(() => dao.Get(1));
        }

        [Fact]
        public async Task AdvisorDAO_Save_ReturnVoid()
        {
            // Arrange
            using var context = GetContext();
            var dao = new AdvisorDAO(context);
            var advisor = MockDataProvider.fakeAdvisors[0];

            // Act
            var res = await dao.Save(advisor);

            // Assert
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(Advisor));
            Assert.StrictEqual(1, res.Id);
        }

        [Fact]
        public async Task AdvisorDAO_Update_ReturnAdvisor()
        {
            // Arrange
            using var context = GetContext();
            var dao = new AdvisorDAO(context);
            var advisor = MockDataProvider.fakeAdvisors.First();
            context.Advisors.Add(advisor);
            context.SaveChanges();

            // Act
            advisor.Name = "Fulanito";
            var newAdvisor = await dao.Update(advisor);

            // Assert
            Assert.NotNull(newAdvisor);
            Assert.Equal("Fulanito",newAdvisor.Name);
        }


    }
}