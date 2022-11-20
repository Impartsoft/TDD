using FluentAssertions;
using TDD;

namespace TDDTest
{
    // story：需要实现- 一个飞机订座功能，让客户能够通过邮箱进行订座，一个容户身份一次性可以订多个座位。
    // 用例：1.使用邮箱订合适数量（飞机剩余的座位大于客户所订的位置 并且 客户信息不为空，客户订的座位大于e） 的位置 
    // 用例：2.客户使用邮箱订超过剩余数量的位置. 邮箱为空 格式等问题 0个引用 

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
    }
}