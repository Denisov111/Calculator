using System;
using Calculator.Enums;
using EasyMvvm.Core;

namespace Calculator.Models
{
    internal class Main : BaseModel
    {
        private string _firstOperandString;
        private InputState _inputState;
        private Func<decimal, decimal, decimal> _operation;

        private string _inputString;
        private string _operationString;

        /// <summary>
        /// Строка ввода
        /// </summary>
        public string InputString
        {
            get => _inputString;
            set
            {
                _inputString = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Введённое выражение
        /// </summary>
        public string InputResult => $"{_firstOperandString} {_operationString}";

        /// <summary>
        /// Ввод числа
        /// </summary>
        /// <param name="input"></param>
        internal void InputChar(string input)
        {
            if (_inputState == InputState.ShowResult)
            {
                _inputState = InputState.Input;
                InputString = null;
            }

            if (InputString?.Contains('.') == true && input == ".")
            {
                return;
            }

            InputString += input;
        }

        /// <summary>
        /// Установка операции
        /// </summary>
        /// <param name="operationString"></param>
        internal void SetOperation(string operationString)
        {
            if (operationString == "-")
            {
                if (string.IsNullOrWhiteSpace(InputString))
                {
                    InputChar(operationString);
                    return;
                }

                if (InputString == "-")
                {
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(_firstOperandString)
                    && !string.IsNullOrWhiteSpace(_operationString)
                    && !string.IsNullOrWhiteSpace(InputString))
            {
                Calculate();
            }

            _firstOperandString ??= InputString;
            _operationString = operationString;
            InputString = null;
            OnPropertyChanged(nameof(InputResult));
        }

        /// <summary>
        /// Удаление последнего символа
        /// </summary>
        public void Back()
        {
            InputString = InputString?.Remove(InputString.Length - 1);
        }

        /// <summary>
        /// Сброс
        /// </summary>
        public void Reset()
        {
            InputString = null;
            _operationString = null;
            _firstOperandString = null;
            _operation = null;
            _inputState = InputState.Input;
            OnPropertyChanged(nameof(InputResult));
        }

        /// <summary>
        /// Вычисление результата
        /// </summary>
        public void Calculate()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_firstOperandString)
                    || string.IsNullOrWhiteSpace(_operationString)
                    || string.IsNullOrWhiteSpace(InputString))
                {
                    return;
                }

                if (!decimal.TryParse(InputString, out decimal secondOperandDecimal))
                {
                    return;
                }

                _operation = GetOperation();
                decimal firstOperandDecimal = decimal.Parse(_firstOperandString);
                string result = _operation(firstOperandDecimal, secondOperandDecimal).ToString();
                Reset();
                InputString = result;
                _inputState = InputState.ShowResult;
            }
            catch (DivideByZeroException)
            {
                OnSendMessage("Делить на 0 нельзя!");
            }
            catch (Exception ex)
            {
                OnSendMessage(ex.Message);
            }
        }

        /// <summary>
        /// ПОлучение операции
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Func<decimal, decimal, decimal> GetOperation()
        {
            return _operationString switch
            {
                "/" => (a, b) => a / b,
                "*" => (a, b) => a * b,
                "-" => (a, b) => a - b,
                "+" => (a, b) => a + b,
                _ => throw new NotImplementedException("ой, неизвестная операция")
            };
        }
    }
}

