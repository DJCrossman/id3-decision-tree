using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class CreditData
    {
        public int ID { get; set; }
        public string Risk { get; set; }
        public string CreditHistory { get; set; }
        public string Debt { get; set; }
        public string Collateral { get; set; }
        public string Income { get; set; }
        public CreditData()
        {
            ID = 0;
            Risk = "";
            CreditHistory = "";
            Debt = "";
            Collateral = "";
            Income = "";
        }
        public CreditData(int id, string risk, string history, string debt, string collateral, string income)
        {
            ID = id;
            Risk = risk;
            CreditHistory = history;
            Debt = debt;
            Collateral = collateral;
            Income = income;
        }
    }
}
