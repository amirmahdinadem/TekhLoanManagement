using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Domain.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
