using CarTuningConfigurator;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CarTuningConfiguratorTest
{
    [TestClass]
    public class CTCControllerUnitTest
    {
        [TestMethod]
        public void TestAdditionalLabelCalculation()
        {
            const string ExpectedTopspeed = "+210";
            const string ExpectedBreakingForce = "+220";
            const string ExpectedAcceleration = "-3";

            Car initialCar = new Car(1, 280, 120, 5, 40, 700, "Esse", "Eater", "Red", false, 1400, "/images/car1.jpg", 17999.99);
            Car finalCar = new Car(1, 500, 330, 2, 40, 700, "Esse", "Eater", "Red", false, 1400, "/images/car1.jpg", 17999.99);

            string[] resultString = new CTCController().SetAdditionalLabels(initialCar, finalCar);
            Assert.AreEqual(ExpectedTopspeed, resultString[0]);
            Assert.AreEqual(ExpectedBreakingForce, resultString[1]);
            Assert.AreEqual(ExpectedAcceleration, resultString[2]);
        }

        [TestMethod]
        public void TestCalculatePriceAndStats()
        {
            CTCController controller = new CTCController();

            Spoiler setSpoiler = controller.model.Spoilers[1];
            Break setBreak = controller.model.Breaks[1];
            Engine setEngine = controller.model.Engines[1];
            Exhaust setExhaust = controller.model.Exhausts[1];
            Car car = new Car(9, 280, 120, 5, 40, 700, "Bugatti", "Veyron", "Red", false, 1400, "images/car2.jpg", 17999.99);

            double ExpectedPrice = setSpoiler.Price + setBreak.Price + setEngine.Price + setExhaust.Price + controller.GetDefaultCarModel("images/car2.jpg").Price;


            car.Spoiler = setSpoiler;
            car.Break = setBreak;
            car.Engine = setEngine;
            car.Exhaust = setExhaust;

            double ActualPrice = (double) controller.CalculatePriceAndStats(car)[0];
            Assert.AreEqual(ExpectedPrice, ActualPrice);
        }

        [TestMethod]
        public void TestApplyingTuningParts()
        {
            CTCController controller = new CTCController();
            Car car = new Car(9, 280, 120, 5, 40, 700, "Bugatti", "Veyron", "Red", false, 1400, "/images/car1.jpg", 17999.99);
            Engine ExpectedEngine = controller.model.Engines[0];

            Car newCar = controller.ApplyTuningItemToCar(ExpectedEngine, car, "");

            Assert.AreEqual(ExpectedEngine, newCar.Engine);
        }

    }
}