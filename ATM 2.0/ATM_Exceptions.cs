using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_2._0
{

    class OutOfMoneyException : ApplicationException
    {

        private string _mes;

        public OutOfMoneyException()
        {
            _mes = "OutOfMoneyException";//
        }

        public  string Message { get => _mes; }

    }     

    class NoUserFoundException : ApplicationException
    {

        private string _mes;

        public NoUserFoundException()
        {
            _mes = "NoUserFoundException";//
        }

        public string Message { get => _mes; }

    }

    class NoOperationFoundException : ApplicationException
    {

        private string _mes;

        public NoOperationFoundException()
        {
            _mes = "NoOperationsFoundException";//
        }

        public string Message { get => _mes; }

    }

    class InvalidDetailException : ApplicationException
    {

        private string _mes;

        public InvalidDetailException()
        {
            _mes = "InvalidDetailsException";//
        }

        public string Message { get => _mes; }

    }



    class OutOfCardBalanceLimitException : ApplicationException
    {

        private string _mes;

        public OutOfCardBalanceLimitException()
        {
            _mes = "CardBalanceLimitException";//
        }

        public string Message { get => _mes; }

    }
}






