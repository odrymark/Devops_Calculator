using Calculator;
using Calculator1.Dtos;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Calculator1;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly CachedCalculator _calculator;
    private readonly CalculatorDbContext _db;

    public CalculatorController(CachedCalculator calculator, CalculatorDbContext db)
    {
        _calculator = calculator;
        _db = db;
    }

    [HttpGet("add")]
    public ActionResult<int> Add([FromQuery] CalculateReqDto calculateReqDto)
    {
        var result = _calculator.Add(calculateReqDto.a, calculateReqDto.b);
        SaveCalculation('+', result);
        return Ok(result);
    }

    [HttpGet("subtract")]
    public ActionResult<int> Subtract([FromQuery] CalculateReqDto calculateReqDto)
    {
        var result = _calculator.Subtract(calculateReqDto.a, calculateReqDto.b);
        SaveCalculation('-', result);
        return Ok(result);
    }

    [HttpGet("multiply")]
    public ActionResult<int> Multiply([FromQuery] CalculateReqDto calculateReqDto)
    {
        var result = _calculator.Multiply(calculateReqDto.a, calculateReqDto.b);
        SaveCalculation('*', result);
        return Ok(result);
    }

    [HttpGet("divide")]
    public ActionResult<int> Divide([FromQuery] CalculateReqDto calculateReqDto)
    {
        if (calculateReqDto.b == 0)
            return BadRequest("Cannot divide by zero.");

        var result = _calculator.Divide(calculateReqDto.a, calculateReqDto.b);
        SaveCalculation('/', result);
        return Ok(result);
    }

    [HttpGet("factorial")]
    public ActionResult<int> Factorial([FromQuery] CalculateReqDto calculateReqDto)
    {
        if (calculateReqDto.a < 0)
            return BadRequest("Factorial is not defined for negative numbers.");

        var result = _calculator.Factorial(calculateReqDto.a);
        SaveCalculation('!', result);
        return Ok(result);
    }

    [HttpGet("isprime")]
    public ActionResult<bool> IsPrime([FromQuery] CalculateReqDto calculateReqDto)
    {
        var result = _calculator.IsPrime(calculateReqDto.a);
        SaveCalculation('p', result ? 1 : 0);
        return Ok(result);
    }

    private void SaveCalculation(char type, double result)
    {
        _db.Calculations.Add(new Calculations
        {
            id = Guid.NewGuid(),
            type = type,
            result = result,
            date = DateTime.UtcNow
        });
        _db.SaveChanges();
    }
}