﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Services
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalTax);
    }
}
