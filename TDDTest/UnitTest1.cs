using FluentAssertions;
using TDD;

namespace TDDTest
{
    // story:

    public class FlightBookingTest
    {
        /// <summary>
        /// 用户正常订座
        /// </summary>
        [Fact]
        public void Normal_booking()
        {
            // given
            var flight = new Flight(seatCapacity: 6);

            // when
            flight.Book("jay@qq.com", 3);

            // then
            flight.SeatCapacity.Should().Be(3);
        }

        /// <summary>
        /// 用户无效订座
        /// </summary>
        [Fact]
        public void Invalid_booking()
        {
            // given
            var flight = new Flight(seatCapacity: 6);

            // when
            var error = flight.Book("jay@qq.com", 0);

            // then
            error.Should().BeOfType<InvalidbookingError>();
        }

        /// <summary>
        /// 用户超额订座
        /// </summary>
        [Fact]
        public void Avoids_overbooking()
        {
            // given
            var flight = new Flight(seatCapacity: 3);

            // when
            var error = flight.Book("jay@163.com", 4);

            // then
            error.Should().BeOfType<OverbookingError>();
        }

        /// <summary>
        /// 用户信息验证
        /// </summary>
        /// public void InvalidUser_booking()
       
    }
}