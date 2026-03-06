using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    private CachedCalculator _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new CachedCalculator();
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
    public void Add_WithZero_ReturnsSameNumber()
    {
        Assert.That(_calc.Add(5, 0), Is.EqualTo(5));
    }

    [Test]
    public void Add_ResultIsCached()
    {
        _calc.Add(2, 3);
        Assert.That(_calc._cache, Contains.Key("2Add3"));
    }

    [Test]
    public void Add_CalledTwiceWithSameArgs_ReturnsCachedResult()
    {
        _calc.Add(2, 3);
        _calc.Add(2, 3);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
    }

    [Test]
    public void Add_DifferentArgs_StoredAsSeparateCacheEntries()
    {
        _calc.Add(2, 3);
        _calc.Add(4, 5);
        Assert.That(_calc._cache.Count, Is.EqualTo(2));
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
    public void Subtract_ResultIsCached()
    {
        _calc.Subtract(10, 4);
        Assert.That(_calc._cache, Contains.Key("10Subtract4"));
    }

    [Test]
    public void Subtract_CalledTwiceWithSameArgs_ReturnsCachedResult()
    {
        _calc.Subtract(10, 4);
        _calc.Subtract(10, 4);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
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
    public void Multiply_ResultIsCached()
    {
        _calc.Multiply(3, 4);
        Assert.That(_calc._cache, Contains.Key("3Multiply4"));
    }

    [Test]
    public void Multiply_CalledTwiceWithSameArgs_ReturnsCachedResult()
    {
        _calc.Multiply(3, 4);
        _calc.Multiply(3, 4);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
    }

    #endregion

    #region Divide

    [Test]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        Assert.That(_calc.Divide(10, 2), Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));
    }

    [Test]
    public void Divide_ByZero_DoesNotCacheResult()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));
        Assert.That(_calc._cache, Is.Empty);
    }

    [Test]
    public void Divide_ResultIsCached()
    {
        _calc.Divide(10, 2);
        Assert.That(_calc._cache, Contains.Key("10Divide2"));
    }

    [Test]
    public void Divide_CalledTwiceWithSameArgs_ReturnsCachedResult()
    {
        _calc.Divide(10, 2);
        _calc.Divide(10, 2);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
    }

    #endregion

    #region Factorial

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        Assert.That(_calc.Factorial(0), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_PositiveNumber_ReturnsCorrectResult()
    {
        Assert.That(_calc.Factorial(5), Is.EqualTo(120));
    }

    [Test]
    public void Factorial_NegativeNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calc.Factorial(-1));
    }

    [Test]
    public void Factorial_NegativeNumber_DoesNotCacheResult()
    {
        Assert.Throws<ArgumentException>(() => _calc.Factorial(-1));
        Assert.That(_calc._cache, Is.Empty);
    }

    [Test]
    public void Factorial_ResultIsCached()
    {
        _calc.Factorial(5);
        Assert.That(_calc._cache, Contains.Key("5Factorial"));
    }

    [Test]
    public void Factorial_CalledTwiceWithSameArg_ReturnsCachedResult()
    {
        _calc.Factorial(5);
        _calc.Factorial(5);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
    }

    #endregion

    #region IsPrime

    [Test]
    public void IsPrime_PrimeNumber_ReturnsTrue()
    {
        Assert.That(_calc.IsPrime(7), Is.True);
    }

    [Test]
    public void IsPrime_CompositeNumber_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(9), Is.False);
    }

    [Test]
    public void IsPrime_One_ReturnsFalse()
    {
        Assert.That(_calc.IsPrime(1), Is.False);
    }

    [Test]
    public void IsPrime_ResultIsCached()
    {
        _calc.IsPrime(7);
        Assert.That(_calc._cache, Contains.Key("7IsPrime"));
    }

    [Test]
    public void IsPrime_CalledTwiceWithSameArg_ReturnsCachedResult()
    {
        _calc.IsPrime(7);
        _calc.IsPrime(7);
        Assert.That(_calc._cache.Count, Is.EqualTo(1));
    }

    #endregion

    #region Cache isolation

    [Test]
    public void Cache_SameArgsForDifferentOperations_StoredAsSeparateEntries()
    {
        _calc.Add(5, 3);
        _calc.Subtract(5, 3);
        _calc.Multiply(5, 3);
        _calc.Divide(5, 3);
        Assert.That(_calc._cache.Count, Is.EqualTo(4));
    }

    [Test]
    public void Cache_UnaryAndBinaryOperationsWithSameNumber_StoredAsSeparateEntries()
    {
        _calc.Add(5, 0);
        _calc.Factorial(5);
        _calc.IsPrime(5);
        Assert.That(_calc._cache.Count, Is.EqualTo(3));
    }

    [Test]
    public void Cache_IsInitiallyEmpty()
    {
        Assert.That(_calc._cache, Is.Empty);
    }

    [Test]
    public void Cache_MultipleDistinctCalls_AllStoredIndependently()
    {
        _calc.Add(1, 2);
        _calc.Add(3, 4);
        _calc.Factorial(5);
        _calc.IsPrime(7);
        Assert.That(_calc._cache.Count, Is.EqualTo(4));
    }

    #endregion
}