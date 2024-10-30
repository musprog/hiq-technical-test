using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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

            Assert.IsTrue(result);
        }

        [Test]
        public void MoveForward_ShouldMoveCarForward()
        {
            bool result = _car.MoveForward();

            Assert.IsTrue(result);
            Assert.AreEqual(2, _car.X);
            Assert.AreEqual(3, _car.Y);
        }

        [Test]
        public void MoveBackward_ShouldMoveCarBackward()
        {
            bool result = _car.MoveBackward();

            Assert.IsTrue(result);
            Assert.AreEqual(2, _car.X);
            Assert.AreEqual(1, _car.Y);
        }

        [Test]
        public void TurnLeft_ShouldTurnCarLeft()
        {
            bool result = _car.TurnLeft();

            Assert.IsTrue(result);
            Assert.AreEqual(Directions.W, _car.Direction);
        }

        [Test]
        public void TurnRight_ShouldTurnCarRight()
        {
            bool result = _car.TurnRight();

            Assert.IsTrue(result);
            Assert.AreEqual(Directions.E, _car.Direction);
        }
    }
}
