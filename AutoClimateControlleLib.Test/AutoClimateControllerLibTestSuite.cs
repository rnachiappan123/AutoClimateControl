using System;
using Moq;
using Xunit;
using ITimerControllerLib;
using IECUObserverLib;
using OutsideTemperatureSensorLib;
using PassengerCountSensorLib;
using ITemperatureCalculatorLib;
using ITemperatureRegulatorLib;
using ECULib;
using IECUSystemLib;
using TemperatureRegulatorLib;

namespace AutoClimateControllerLib.Test
{
    public class AutoClimateControllerFixture : IDisposable
    {
        public Mock<IECUSystem> MockECU { get; private set; }
        public AutoClimateController ClimateController { get; private set; }

        public AutoClimateControllerFixture()
        {
            MockECU = new Mock<IECUSystem>();
            ClimateController = new AutoClimateController(MockECU.Object);
        }

        public void Dispose()
        {
            //MockECU = null;
            //ClimateController = null;
        }
    }

    public class AutoClimateControllerTests : IClassFixture<AutoClimateControllerFixture>
    {
        private readonly AutoClimateControllerFixture _fixture;

        public AutoClimateControllerTests(AutoClimateControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void AutoClimateController_TurnOn_CorrectlyRegistersObservers()
        {
            // Act
            _fixture.ClimateController.On();

            // Assert
            _fixture.MockECU.Verify(ecu => ecu.ActivateTemperatureSensor(), Times.Once);
            _fixture.MockECU.Verify(ecu => ecu.ActivatePassengerCountSensor(), Times.Once);
        }

        [Fact]
        public void AutoClimateController_TurnOff_CorrectlyRemovesObservers()
        {
            // Act
            _fixture.ClimateController.Off();

            // Assert
            _fixture.MockECU.Verify(ecu => ecu.DeactivateTemperatureSensor(), Times.Once);
            _fixture.MockECU.Verify(ecu => ecu.DeactivatePassengerCountSensor(), Times.Once);
        }
    }

    public class OutsideTemperatureSensorTests : IClassFixture<AutoClimateControllerFixture>
    {
        private readonly AutoClimateControllerFixture _fixture;

        public OutsideTemperatureSensorTests(AutoClimateControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void OutsideTemperatureSensor_RegisterObserver_CallsStartTimer()
        {
            // Arrange
            var mockTimerController = new Mock<ITimerController>();
            var mockECUObserver = new Mock<IECUObserver>();
            var outsideTempSensorObj = new OutsideTemperatureSensor(mockTimerController.Object);

            // Act
            outsideTempSensorObj.RegisterObserver(mockECUObserver.Object);

            // Assert
            mockTimerController.Verify(tc => tc.StartTimer(), Times.Once);
        }

        [Fact]
        public void OutsideTemperatureSensor_RemoveObserver_CallsStopTimer()
        {
            // Arrange
            var mockTimerController = new Mock<ITimerController>();
            var sensor = new OutsideTemperatureSensor(mockTimerController.Object);

            // Act
            sensor.RemoveObserver();

            // Assert
            mockTimerController.Verify(tc => tc.StopTimer(), Times.Once);
        }
    }

    public class PassengerCountSensorTests : IClassFixture<AutoClimateControllerFixture>
    {
        private readonly AutoClimateControllerFixture _fixture;

        public PassengerCountSensorTests(AutoClimateControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void PassengerCountSensor_RegisterObserver_CallsStartTimer()
        {
            // Arrange
            var mockTimerController = new Mock<ITimerController>();
            var mockECUObserver = new Mock<IECUObserver>();
            var passengerCountSensorObj = new PassengerCountSensor(mockTimerController.Object);

            // Act
            passengerCountSensorObj.RegisterObserver(mockECUObserver.Object);

            // Assert
            mockTimerController.Verify(tc => tc.StartTimer(), Times.Once);
        }

        [Fact]
        public void PassengerCountSensor_RemoveObserver_CallsStopTimer()
        {
            // Arrange
            var mockTimerController = new Mock<ITimerController>();
            var sensor = new PassengerCountSensor(mockTimerController.Object);

            // Act
            sensor.RemoveObserver();

            // Assert
            mockTimerController.Verify(tc => tc.StopTimer(), Times.Once);
        }
    }

    public class TemperatureCalculatorTests
    {
        
        

      
    }
    public class TemperatureRegulatorTests : IClassFixture<AutoClimateControllerFixture>
    {
        private readonly AutoClimateControllerFixture _fixture;

        public TemperatureRegulatorTests(AutoClimateControllerFixture fixture)
        {
            _fixture = fixture;
        }
    }
}
