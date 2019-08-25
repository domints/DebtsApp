using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtsApp.Web.Helpers
{
    public static class LoanResolver
    {
        public static List<LoanDescriptor<T>> MinimumAmountTransferred<T>(IEnumerable<LoanDescriptor<T>> loans)
            where T : IEquatable<T>
        {
            List<LoanDescriptor<T>> results = new List<LoanDescriptor<T>>();
            var balances = LoadBalances(loans);
            var bim = balances.Keys
                .Select((key, index) => new { K = key, I = index })
                .ToDictionary(k => k.I, v => v.K);
            var i = 0;
            var j = 0;
            while(i != balances.Count && j != balances.Count)
            {
                if (balances[bim[i]] <= 0)
                {
                    i++;
                }
                else if (balances[bim[j]] >= 0)
                {
                    j++;
                }
                else
                {
                    decimal m = 0m;
                    if (balances[bim[i]] < -balances[bim[j]])
                        m = balances[bim[i]];
                    else
                        m = -balances[bim[j]];

                    Console.WriteLine($"{bim[i]} -> {bim[j]}: {m}");
                    results.Add(new LoanDescriptor<T> { From = bim[i], To = bim[j], Amount = m });
                    balances[bim[i]] -= m;
                    balances[bim[j]] += m;
                }
            }

            return results;
        }

        private static Dictionary<T, decimal> LoadBalances<T>(IEnumerable<LoanDescriptor<T>> loans)
            where T : IEquatable<T>
        {
            var balances = new Dictionary<T, decimal>();
            foreach(var loan in loans)
            {
                if(!balances.ContainsKey(loan.From))
                    balances.Add(loan.From, loan.Amount);
                else
                    balances[loan.From] += loan.Amount;

                if(!balances.ContainsKey(loan.To))
                    balances.Add(loan.To, -loan.Amount);
                else
                    balances[loan.To] -= loan.Amount;
            }

            return balances;
        }
    }

    public class LoanDescriptor<T>
        where T : IEquatable<T>
    {
        public T From { get; set; }
        public T To { get; set; }
        public decimal Amount { get; set; }
    }
}