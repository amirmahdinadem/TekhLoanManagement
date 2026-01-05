using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Domain.Abstractions
{
    public class BaseEntity<Tkey>
    {
        public Tkey Id { get; protected set; }
    }
}
