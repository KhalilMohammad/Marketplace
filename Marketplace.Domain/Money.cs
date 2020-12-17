using System;

namespace Marketplace.Domain
{
    public record Money(decimal Amount, string currency = "EUR")
    {
        private const string DefaultCurrency = "EUR";

        public static Money FromDecimal(decimal amount, string currency = DefaultCurrency) =>
            new Money(amount, currency);
        public static Money FromString(string amount, string currency = DefaultCurrency) =>
            new Money(decimal.Parse(amount), currency);

        public decimal Amount { get; }
        public string CurrencyCode { get; }

        public Money Add(Money summand)
        {
            if (CurrencyCode != summand.CurrencyCode)
                throw new CurrencyMismatchException(
                "Cannot sum amounts with different currencies");
            return new Money(Amount + summand.Amount);
        }

        public Money Subtract(Money subtrahend)
        {
            if (CurrencyCode != subtrahend.CurrencyCode)
                throw new CurrencyMismatchException(
                "Cannot subtract amounts with different currencies");
            return new Money(Amount - subtrahend.Amount);
        }

        public static Money operator +(Money summand1, Money summand2) =>
            summand1.Add(summand2);
        public static Money operator -(Money minuend, Money subtrahend) =>
            minuend.Subtract(subtrahend);
    }

    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message)
        {
        }
    }
}
