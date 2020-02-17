using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Services.Implementations
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal Tax;

        public decimal TaxAmount(decimal totalTax)
        {
            if (totalTax <= 18000)
            {
                taxRate = .0m;
                Tax = totalTax * taxRate;
            }
            else if (totalTax > 18000 && totalTax <= 150000)
            {
                taxRate = .20m;
                Tax = (totalTax - 18000) * taxRate;
            }
            else if (totalTax > 150000 && totalTax <= 300000)
            {
                taxRate = .40m;
                Tax = ((150000 - 18000) * .20m) + ((totalTax - 150000) * taxRate);
            }
            else if (totalTax > 300000)
            {
                taxRate = .45m;
                Tax = ((150000 - 18000) * .20m) + ((300000 - 150000) * .40m) + ((totalTax - 300000) * taxRate);
            }
            return Tax;
        }
    }
}
