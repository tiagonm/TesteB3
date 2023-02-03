﻿namespace B3.FixedIncome.Domain.Commands.Helpers
{
    public class GenericCommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
            Data = new { };
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
