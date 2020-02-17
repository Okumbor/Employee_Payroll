using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Services.Implementations
{
    public class NationalInsuranceService : INationalInsuranceService
    {
        private decimal InsuranceRate;
        private decimal InsuranceCost;

        public decimal NationalInsurance(decimal totalInsurance)
        {
            if (totalInsurance <= 30000)
            {
                InsuranceRate = .0m;
                InsuranceCost = totalInsurance * InsuranceRate;
            }
            else if (totalInsurance > 30000 && totalInsurance <= 120000)
            {
                InsuranceRate = .12m;
                InsuranceCost = (totalInsurance - 30000) * InsuranceRate;
            }
            else if (totalInsurance > 120000)
            {
                InsuranceRate = .20m;
                InsuranceCost = ((120000 - 30000) * .12m) + ((totalInsurance - 120000) * InsuranceRate);
            }
            return InsuranceCost;
        }
    }
}
