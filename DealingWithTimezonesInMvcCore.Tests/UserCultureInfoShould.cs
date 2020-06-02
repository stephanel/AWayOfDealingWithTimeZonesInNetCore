using DealingWithTimezonesInMvcCore.Infrastructure;
using DealingWithTimezonesInMvcCore.Services;
using Moq;
using System;
using Xunit;

namespace DealingWithTimezonesInMvcCore.Tests
{
    public class UserCultureInfoShould
    {
        private readonly UserCultureInfo _sut;
        private readonly Mock<ITimeService> _mockedTimeService;

        private readonly DateTime _utcTime = new DateTime(2020, 6, 2, 19, 28, 14, DateTimeKind.Utc);
        private readonly DateTime _userLocalTime = new DateTime(2020, 6, 2, 9, 28, 14, DateTimeKind.Local);

        public UserCultureInfoShould()
        {
            _mockedTimeService = new Mock<ITimeService>();

            _sut = new UserCultureInfo(_mockedTimeService.Object);
        }

        [Fact]
        public void ReturnUserLocalTime()
        {
            _mockedTimeService.SetupGet(x => x.Now).Returns(_utcTime);
            Assert.Equal(_userLocalTime, _sut.GetUserLocalTime());
        }

        [Fact]
        public void ReturnUtcTimeBasedOnUserLocalTime()
        {
            Assert.Equal(_utcTime, _sut.GetUtcTime(_userLocalTime));
        }
    }
}
