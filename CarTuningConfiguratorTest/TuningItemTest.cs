using CarTuningConfigurator;

namespace CarTuningConfiguratorTest
{
    [TestClass]
    public class TuningItemTest
    {
        [TestMethod]
        public void CheckTuningItemsToString()
        {
            const string ExpectedStringTuningItem = "eater";
            const string ExpectedStringEngine = "eater | esse";
            const string ExpectedStringSpoiler = "eater | esser";

            TuningItem item = new TuningItem();
            item.Name = "eater";

            Engine engine  = new Engine();
            engine.Name = "eater";
            engine.Cylinder = "esse";

            Spoiler spoiler = new Spoiler();
            spoiler.Name = "eater";
            spoiler.Type = "esser";

            Assert.AreEqual(ExpectedStringTuningItem, item.ToString());
            Assert.AreEqual(ExpectedStringEngine, engine.ToString());
            Assert.AreEqual(ExpectedStringSpoiler, spoiler.ToString());
        }
    }
}
