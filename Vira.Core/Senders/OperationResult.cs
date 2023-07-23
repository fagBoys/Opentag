﻿namespace Vira.Core.Senders
{
    public class OperationResult
    {
        public bool isSuccedded { get; set; }
        public string Message { get; set; }


        public OperationResult()
        {
            isSuccedded = false;

        }
        public OperationResult Succedded( string message = "عملیات با موفقیت انجام شد")
        {
            isSuccedded = true;
            Message = message;  
            return this;
        }

        public OperationResult Failed(string message)
        {
            isSuccedded = false;
            Message = message;
            return this;
        }
    }
}
