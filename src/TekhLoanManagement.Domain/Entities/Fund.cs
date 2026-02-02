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
                    Guid walletAccountId)
        {
            MonthlyPaymentAmount = monthlyPaymentAmount;    
            NumberOfInstallments = numberOfInstallments;    
            ProfitRate = profitRate;    
            WalletAccountId = walletAccountId;  
            StartDate = DateOnly.FromDateTime(DateTime.Now);
            SeedMoney = CalculateSeedMoney(monthlyPaymentAmount,
                                            numberOfInstallments);
            

            

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
        public Guid WalletAccountId { get; private set; }
        public WalletAccount WalletAccount { get; private set; }

        private List<Loan> _loans = new List<Loan>(); 

        private List<Member> _members = new List<Member>();
        public IReadOnlyCollection<Loan>? Loans  => _loans ;
        public IReadOnlyCollection<Member>? Members  => _members ;

        private decimal CalculateSeedMoney(decimal monthlyPaymentAmount,
                                          int numberOfInstallments)
        {
           return (monthlyPaymentAmount+
                   (monthlyPaymentAmount/numberOfInstallments))*
                   (numberOfInstallments/2);
        }
               
        public void AddLoan(Loan loan) => _loans.Add(loan);
        public void AddMember(Member member) => _members.Add(member);
        

       

        
    }
}
