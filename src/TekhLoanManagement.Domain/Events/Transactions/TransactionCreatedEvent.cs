using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Domain.Events.Transactions
{
    public class TransactionCreatedEvent : INotification
    {
        public Transaction Transaction { get; }
        public string IdempotencyKey { get; }
        public Guid UserId { get; }

        public TransactionCreatedEvent(Transaction transaction, string idempotencyKey, Guid userId)
        {
            Transaction = transaction;
            IdempotencyKey = idempotencyKey;
            UserId = userId;
        }
    }
}
