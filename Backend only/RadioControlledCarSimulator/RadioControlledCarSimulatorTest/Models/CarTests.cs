using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator.Tests
{
    public class CarTests
    {
        private Room _room;
        private Car _car;

        [SetUp]
        public void Setup()
        {
            _room = new Room(5, 5);
            _car = new Car(2, 2, Directions.N, _room);
        }

        [Test]
        public void CarStartPosition_ShouldReturnTrue()
        {
            bool result = _car.CarStartPosition();

            Assert.That(result, Is.True);
        }

        [Test]
        public void MoveForward_ShouldMoveCarForward()
        {
            bool result = _car.MoveForward();

            Assert.That(result, Is.True);
            Assert.Equals(2, _car.X);
            Assert.Equals(3, _car.Y);
        }

        [Test]
        public void MoveBackward_ShouldMoveCarBackward()
        {
            bool result = _car.MoveBackward();

            Assert.That(result, Is.True);
            Assert.Equals(2, _car.X);
            Assert.Equals(1, _car.Y);
        }

        [Test]
        public void TurnLeft_ShouldTurnCarLeft()
        {
            bool result = _car.TurnLeft();

            Assert.That(result, Is.True);
            Assert.Equals(Directions.W, _car.Direction);
        }

        [Test]
        public void TurnRight_ShouldTurnCarRight()
        {
            bool result = _car.TurnRight();

            Assert.That(result, Is.True);
            Assert.Equals(Directions.E, _car.Direction);
        }
    }
}
