using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("somar/{firstNumber}/{secondNumber}")]
        public IActionResult Somar(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var somar = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(somar.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("subtrair/{firstNumber}/{secondNumber}")]
        public IActionResult Subtrair(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtrair = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtrair.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("dividir/{firstNumber}/{secondNumber}")]
        public IActionResult Divir(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var dividir = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(dividir.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplicacao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplicacao.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(media.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult raiz(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var raiz = Math.Sqrt((double)(ConvertToDecimal(firstNumber)));

                return Ok(raiz.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
