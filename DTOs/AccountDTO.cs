﻿namespace WebApiBank.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Balance { get; set; }
    }
}
