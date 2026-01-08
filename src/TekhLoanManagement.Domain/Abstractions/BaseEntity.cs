using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Domain.Abstractions
{
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; protected set; }
    }
}
