using System.Net.Mail;

namespace Orderling.Domain.ValueObjects
{
    public record Payment
    {
        public string CardNumber { get; private set; } = default!;

        public string? CardName { get; private set; } = default!;
        public string Expiration { get; private set; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment()
        {

        }

        private Payment(string cardNumber,string cardName,string expiration,string cvv,int paymentMethod)
        {
            CardNumber=cardNumber; CardName=cardName; Expiration=expiration; CVV=cvv; PaymentMethod=paymentMethod;
        }

        public static Payment Of(string cardNumber, string cardName, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length,3);

            return new Payment(cardNumber,cardName,expiration,cvv,paymentMethod);
        }
    }
}
