using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Fund : BaseEntity<Guid> //Sandogh
    {

        public Fund(decimal monthlyPaymentAmount,
                    int numberOfInstallments,
                    double profitRate,
                    Guid walletAccountId
            , WalletAccount walletAccount)
        {
            if (monthlyPaymentAmount < 0) {
                throw new DomainException("incorrect MonthlyPayment");
            }
            MonthlyPaymentAmount = monthlyPaymentAmount;
            if (numberOfInstallments < 0) {
                throw new DomainException("incorrect Instalment Count");

            }
            NumberOfInstallments = numberOfInstallments;
            if (profitRate < 0|| profitRate > 2) { 
                throw new DomainException("incorrect ProfitRate");
            }
            ProfitRate = profitRate;    
            WalletAccountId = walletAccountId;
            WalletAccount = walletAccount;
            StartDate =DateOnly.FromDateTime(DateTime.Now);
            SeedMoney = CalculateSeedMoney(monthlyPaymentAmount,
                                           numberOfInstallments);
            if (!CheckWallet())
            {
                throw new DomainException("Please Charge your Wallet Account");
            }
            IsActive = true;    
           
        }
        protected Fund()
        {

        }
        public decimal MonthlyPaymentAmount { get; private set; }
        public int NumberOfInstallments { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public double ProfitRate { get; private set; }
        public decimal SeedMoney { get; private set; }
        public WalletAccount WalletAccount { get; private set; }
        public Guid WalletAccountId { get; private set; }
        public bool IsActive {  get; private set; }

        private List<Member> _members = new List<Member>();
        public IReadOnlyCollection<Member>? Members  => _members ;

        public void AddMember(Member member) => _members.Add(member);

        private decimal CalculateSeedMoney(decimal monthlyPaymentAmount,
                                          int numberOfInstallments)
        {
           return (monthlyPaymentAmount+
                   (monthlyPaymentAmount/numberOfInstallments))*
                   (numberOfInstallments/2m);
        }
        private bool CheckWallet()
        {
            if (WalletAccount.Balance >= SeedMoney)
            {
                return true;
            }
            else
            {
                return false;       
            }
        }
        public void DeActiveFund() {
            if (IsActive)
            {
                IsActive = false;
                EndDate = DateOnly.FromDateTime(DateTime.Now);
            }
        }
        public decimal FrozenCalculator()
        {
            return ((MonthlyPaymentAmount  / NumberOfInstallments) * (decimal)ProfitRate)*3;
        }



    }
}
