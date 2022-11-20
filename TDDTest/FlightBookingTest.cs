using FluentAssertions;
using TDD;

namespace TDDTest
{
    // story����Ҫʵ��- һ���ɻ��������ܣ��ÿͻ��ܹ�ͨ��������ж�����һ���ݻ����һ���Կ��Զ������λ��
    // ������1.ʹ�����䶩�����������ɻ�ʣ�����λ���ڿͻ�������λ�� ���� �ͻ���Ϣ��Ϊ�գ��ͻ�������λ����e�� ��λ�� 
    // ������2.�ͻ�ʹ�����䶩����ʣ��������λ��. ����Ϊ�� ��ʽ������ 0������ 

    public class FlightBookingTest
    {
        /// <summary>
        /// �û���������
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
        /// �û���Ч����
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
        /// �û������
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