using PSB;

namespace CalculatorControllerTests
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public void TestAdd()
        {
            CalculatorController calcController = new CalculatorController();
            double a = 10, b = 14;
            Assert.AreEqual(24, calcController.Add(a, b));

            a = -10;
            b = 10000000.34;
            Assert.AreEqual(9999990.34, calcController.Add(a, b));

            a = 12.21;
            b = -4.21;
            Assert.AreEqual(8, calcController.Add(a, b));
        }

        [TestMethod]
        public void TestSubtract()
        {
            CalculatorController calcController = new CalculatorController();
            double a = 10, b = 14;
            Assert.AreEqual(-4, calcController.Subtract(a, b));

            a = -10;
            b = 10000000.34;
            Assert.AreEqual(-10000010.34, calcController.Subtract(a, b));

            a = 12.21;
            b = -4.21;
            Assert.AreEqual(16.42, calcController.Subtract(a, b));
        }

        [TestMethod]
        public void TestMultiply()
        {
            CalculatorController calcController = new CalculatorController();
            double a = 10, b = 14;
            Assert.AreEqual(140, calcController.Multiply(a, b));

            a = -10;
            b = 10000000.34;
            Assert.AreEqual(-100000003.4, calcController.Multiply(a, b));

            a = 12.21;
            b = -4.21;
            Assert.AreEqual(-51.4041, calcController.Multiply(a, b));

            a = 0;
            Assert.AreEqual(0.0, calcController.Multiply(a, b));
        }

        [TestMethod]
        public void TestDivide()
        {
            CalculatorController calcController = new CalculatorController();
            double a = 10, b = 14;
            Assert.AreEqual(1.4, calcController.Divide(b, a));

            a = -101;
            b = 2345432;
            Assert.IsTrue(Math.Abs(-23222.099 - calcController.Divide(b, a)) <= 0.00001);

            a = 12.21;
            b = -4.21;
            Assert.IsTrue(Math.Abs(-2.90023753- calcController.Divide(a, b)) <= 0.00001);

            a = 0;
            Assert.ThrowsException<DivideByZeroException>(() => calcController.Divide(b, a));
        }
    }
}