using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MathAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        [Route("")]
        [Route("Sumar")]
        [Route("Sumar/{ValueA}/{ValueB}")]
        [HttpGet]
        public int GetAddition(int ValueA, int ValueB)
        {
            return ValueA + ValueB;
        }

        [Route("Restar")]
        [Route("Restar/{ValueA}/{ValueB}")]
        [HttpGet]
        public int getSubtraction(int ValueA, int ValueB)
        {
            return ValueA - ValueB;
        }

        [Route("Multiplicar")]
        [Route("Multiplicar/{ValueA}/{ValueB}")]
        [HttpGet]
        public int GetMultiplication(int ValueA, int ValueB)
        {
            return ValueA * ValueB;
        }

        [Route("Dividir")]
        [Route("Dividir/{ValueA}/{ValueB}")]
        [HttpGet]
        public float GetDivision(int ValueA, int ValueB)
        {
            return ValueA / ValueB;
        }

        [Route("Factorial")]
        [HttpGet]
        public ulong GetFactorial(int Value)
        {
            // Condition for factorial zero
            ulong factorial = Value == 0 ? 1 : (ulong) Value;

            for (ulong iteration = factorial - 1; iteration > 0; iteration--) factorial *= iteration;

            return factorial;
        }

        [Route("CalcularExpresion")]
        [HttpGet]
        public string GetFromExpresion(string Value)
        {
            Match match = Regex.Match(Value, "(\\b[0-9]*\\b)\\s*([+]|[-]|[\\/]|[*])\\s*(\\b[0-9]+\\b)");

            if (match.Success) {
                switch (match.Groups[2].Value)
                {
                    case "+":
                        return (Int32.Parse(match.Groups[1].Value) + Int32.Parse(match.Groups[3].Value)).ToString();
                    case "-":
                        return (Int32.Parse(match.Groups[1].Value) - Int32.Parse(match.Groups[3].Value)).ToString();
                    case "*":
                        return (Int32.Parse(match.Groups[1].Value) * Int32.Parse(match.Groups[3].Value)).ToString();
                    case "/":
                        return (Int32.Parse(match.Groups[1].Value) / Int32.Parse(match.Groups[3].Value)).ToString();
                }
            }

            return "Unexpected Error";
        }
    }
}
