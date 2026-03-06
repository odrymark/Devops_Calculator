using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    private SimpleCalculator _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new SimpleCalculator();
    }

    #region Add

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        Assert.That(_calc.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Add_WithNegativeNumber_ReturnsSum()
    {
        Assert.That(_calc.Add(-1, 3), Is.EqualTo(2));
    }

    [Test]
    public void Add_TwoNegativeNumbers_ReturnsNegativeSum()
    {
        Assert.That(_calc.Add(-2, -3), Is.EqualTo(-5));
    }

    [Test]
    public void Add_WithZero_ReturnsSameNumber()
    {
        Assert.That(_calc.Add(5, 0), Is.EqualTo(5));
    }

    #endregion

    #region Subtract

    [Test]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        Assert.That(_calc.Subtract(10, 4), Is.EqualTo(6));
    }

    [Test]
    public void Subtract_ResultIsNegative_ReturnsNegativeValue()
    {
        Assert.That(_calc.Subtract(3, 7), Is.EqualTo(-4));
    }

    [Test]
    public void Subtract_SameNumbers_ReturnsZero()
    {
        Assert.That(_calc.Subtract(5, 5), Is.EqualTo(0));
    }

    [Test]
    public void Subtract_WithZero_ReturnsSameNumber()
    {
        Assert.That(_calc.Subtract(8, 0), Is.EqualTo(8));
    }

    #endregion

    #region Multiply

    [Test]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        Assert.That(_calc.Multiply(3, 4), Is.EqualTo(12));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        Assert.That(_calc.Multiply(99, 0), Is.EqualTo(0));
    }

    [Test]
    public void Multiply_TwoNegativeNumbers_ReturnsPositive()
    {
        Assert.That(_calc.Multiply(-3, -4), Is.EqualTo(12));
    }

    [Test]
    public void Multiply_PositiveAndNegative_ReturnsNegative()
    {
        Assert.That(_calc.Multiply(3, -4), Is.EqualTo(-12));
    }

    [Test]
    public void Multiply_ByOne_ReturnsSameNumber()
    {
        Assert.That(_calc.Multiply(7, 1), Is.EqualTo(7));
    }

    #endregion

    #region Divide

    [Test]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        Assert.That(_calc.Divide(10, 2), Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByOne_ReturnsSameNumber()
    {
        Assert.That(_calc.Divide(7, 1), Is.EqualTo(7));
    }

    [Test]
    public void Divide_NegativeByNegative_ReturnsPositive()
    {
        Assert.That(_calc.Divide(-10, -2), Is.EqualTo(5));
    }

    [Test]
    public void Divide_PositiveByNegative_ReturnsNegative()
    {
        Assert.That(_calc.Divide(10, -2), Is.EqualTo(-5));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));
    }

    [Test]
    public void Divide_IntegerDivision_ReturnsTruncatedResult()
    {
        // 7 / 2 = 3 (integer division, not 3.5)
        Assert.That(_calc.Divide(7, 2), Is.EqualTo(3));
    }

    #endregion

    #region Factorial

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        Assert.That(_calc.Factorial(0), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_One_ReturnsOne()
    {
        Assert.That(_calc.Factorial(1), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_PositiveNumber_ReturnsCorrectResult()
    {
        Assert.That(_calc.Factorial(5), Is.EqualTo(120));
    }

    [Test]
    public void Factorial_LargerNumber_ReturnsCorrectResult()
    {
        Assert.That(_calc.Factorial(10), Is.EqualTo(3628800));
    }

    [Test]
    public void Factorial_NegativeNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calc.Factorial(-1));
    }

    [Test]
    public void Factorial_NegativeNumber_ExceptionMessageIsDescriptive()
    {
        var ex = Assert.Throws<ArgumentException>(() => _calc.Factorial(-5));
        Assert.That(ex.Message, Does.Contain("negative"));
    }

    #endregion

    #region IsPrime

    [Test]
    public void IsPrime_Two_ReturnsTrue()
    {
        Assert.That(_calc.IsPrime(2), Is.True);
    }

    [Test]
    public void IsPrime_Three_ReturnsTrue()
    {
        Assert.That(_calc.IsPrime(3), Is.True);
    }

    [Test]
    public void IsPrime_CompositeNumber_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(9), Is.False);
    }

    [Test]
    public void IsPrime_LargePrime_ReturnsTrue()
    {
        Assert.That(_calc.IsPrime(97), Is.True);
    }

    [Test]
    public void IsPrime_LargeComposite_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(100), Is.False);
    }

    [Test]
    public void IsPrime_One_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(1), Is.False);
    }

    [Test]
    public void IsPrime_Zero_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(0), Is.False);
    }

    [Test]
    public void IsPrime_NegativeNumber_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(-7), Is.False);
    }

    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(7)]
    [TestCase(11)]
    [TestCase(13)]
    public void IsPrime_KnownPrimes_ReturnsTrue(int prime)
    {
        Assert.That(_calc.IsPrime(prime), Is.True);
    }

    [TestCase(4)]
    [TestCase(6)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    public void IsPrime_KnownComposites_ReturnsFalse(int composite)
    {
        Assert.That(_calc.IsPrime(composite), Is.False);
    }

    #endregion
}