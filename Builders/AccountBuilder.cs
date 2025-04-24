using WebApiBank.DTOs;
using WebApiBank.Models;

namespace WebApiBank.Builders
{
    public class AccountBuilder
    {
        private int _id;
        private int _clientId;
        private decimal _balance;

        public AccountBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public AccountBuilder WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }

        public AccountBuilder WithBalance(decimal balance)
        {
            _balance = balance;
            return this;
        }

        public Account Build()
        {
            return new Account
            {
                Id = _id,
                ClientId = _clientId,
                Balance = _balance
            };
        }

        public AccountDTO BuildDTO()
        {
            return new AccountDTO
            {
                Id = _id,
                ClientId = _clientId,
                Balance = _balance
            };
        }
    }
}
