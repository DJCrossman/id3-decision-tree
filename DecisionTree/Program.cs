using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Program
    {

        /*------------ Data Members ------------*/
        private static string[] RiskData = new string[3] { "high", "moderate", "low" };
        private static string[] CreditHistoryData = new string[3] { "good", "bad", "unknown" };
        private static string[] DebtData = new string[2] { "high", "low" };
        private static string[] CollateralData = new string[2] { "none", "adequate" };
        private static string[] IncomeData = new string[3] { "$0 to 15k", "$15 to $35k", "over $35k" };

        /*------------ Main Program ------------*/

        static void Main(string[] args)
        {
            var data = InitiatizeCreditData();      // Examples
            var target = "Risk";                    // Target Attribute

            var props = typeof(CreditData).GetProperties();     // Attributes

            var tree = InduceTree(data, target, props.ToList());
        }

        /*------------ ID3 Functions ------------*/

        private static TreeNode InduceTree(List<CreditData> examples, string targetAttribute, List<System.Reflection.PropertyInfo> attributes)
        {
            var root = new TreeNode();



            var attr = "";
            var prob = 0.00;

            CalculateAttributeProbability(ref attr, ref prob, examples, attributes);

            if (attributes.Count == 0) return root;

            Console.Write("Attr: " + attr + ", Prob: " + prob);
            return new TreeNode();
        }

        private static void CalculateAttributeProbability(ref string attr, ref double prob, List<CreditData> examples, List<System.Reflection.PropertyInfo> attributes)
        {
            foreach(var attribute in attributes)
            {
                switch (attribute.Name.ToString())
                {
                    case "Risk":
                        foreach (var option in RiskData)
                        {
                            if (((double)examples.Where(e => e.Risk == option).Count() / (double)examples.Count()) > prob)
                            {
                                attr = attribute.Name;
                                prob = (double)examples.Where(e => e.Risk == option).Count() / (double)examples.Count();
                            }
                        }
                        break;
                    case "CreditHistory":
                        foreach (var option in CreditHistoryData)
                        {
                            if (((double)examples.Where(e => e.CreditHistory == option).Count() / (double)examples.Count()) > prob)
                            {
                                attr = attribute.Name;
                                prob = (double)examples.Where(e => e.CreditHistory == option).Count() / (double)examples.Count();
                            }
                        }
                        break;
                    case "Debt":
                        foreach (var option in DebtData)
                        {
                            if (((double)examples.Where(e => e.Debt == option).Count() / (double)examples.Count()) > prob)
                            {
                                attr = attribute.Name;
                                prob = (double)examples.Where(e => e.Debt == option).Count() / (double)examples.Count();
                            }
                        }
                        break;
                    case "Collateral":
                        foreach (var option in CollateralData)
                        {
                            if (((double)examples.Where(e => e.Collateral == option).Count() / (double)examples.Count()) > prob)
                            {
                                attr = attribute.Name;
                                prob = (double)examples.Where(e => e.Collateral == option).Count() / (double)examples.Count();
                            }
                        }
                        break;
                    case "Income":
                        foreach (var option in IncomeData)
                        {
                            if (((double)examples.Where(e => e.Income == option).Count() / (double)examples.Count()) > prob)
                            {
                                attr = attribute.Name;
                                prob = (double)examples.Where(e => e.Income == option).Count() / (double)examples.Count();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /*------------ Utility Functions ------------*/

        private static List<CreditData> InitiatizeCreditData()
        {
            var data = new List<CreditData>();
            data.Add(new CreditData(1,  RiskData[0], CreditHistoryData[1], DebtData[0], CollateralData[0], IncomeData[0]));
            data.Add(new CreditData(2,  RiskData[0], CreditHistoryData[2], DebtData[0], CollateralData[0], IncomeData[1]));
            data.Add(new CreditData(3,  RiskData[1], CreditHistoryData[2], DebtData[1], CollateralData[0], IncomeData[1]));
            data.Add(new CreditData(4,  RiskData[0], CreditHistoryData[2], DebtData[1], CollateralData[0], IncomeData[0]));
            data.Add(new CreditData(5,  RiskData[2], CreditHistoryData[2], DebtData[1], CollateralData[0], IncomeData[2]));
            data.Add(new CreditData(6,  RiskData[2], CreditHistoryData[2], DebtData[1], CollateralData[1], IncomeData[2]));
            data.Add(new CreditData(7,  RiskData[0], CreditHistoryData[1], DebtData[1], CollateralData[0], IncomeData[0]));
            data.Add(new CreditData(8,  RiskData[1], CreditHistoryData[1], DebtData[1], CollateralData[1], IncomeData[2]));
            data.Add(new CreditData(9,  RiskData[2], CreditHistoryData[0], DebtData[1], CollateralData[0], IncomeData[2]));
            data.Add(new CreditData(10, RiskData[2], CreditHistoryData[0], DebtData[0], CollateralData[1], IncomeData[2]));
            data.Add(new CreditData(11, RiskData[0], CreditHistoryData[0], DebtData[0], CollateralData[0], IncomeData[0]));
            data.Add(new CreditData(12, RiskData[1], CreditHistoryData[0], DebtData[0], CollateralData[0], IncomeData[1]));
            data.Add(new CreditData(13, RiskData[2], CreditHistoryData[0], DebtData[0], CollateralData[0], IncomeData[0]));
            data.Add(new CreditData(14, RiskData[0], CreditHistoryData[1], DebtData[0], CollateralData[0], IncomeData[1]));
            return data;
        }

        static void PrintCreditData(List<CreditData> items)
        {
            foreach(var item in items)
            {
                Console.Write("No.: " + item.ID + ", RISK: " + item.Risk + ", CREDIT HISTORY: " + item.CreditHistory + ", DEBT: " + item.Debt + ", COLLATERAL: " + item.Collateral + ", INCOME: " + item.Income + Environment.NewLine);
            }
            return;
        }
    }
}
