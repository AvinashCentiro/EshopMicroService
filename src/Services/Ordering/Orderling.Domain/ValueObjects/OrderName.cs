using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderling.Domain.ValueObjects
{
    public record OrderName
    {

        public const int DefaultLength = 5;
        public string Value
        {
            get;
        }


        private OrderName(string value) => Value = value;

        public static OrderName Of(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == String.Empty)
            {
                throw new DomainException("OrderName can not be empty");
                ArgumentOutOfRangeException.ThrowIfEqual(value.Length,DefaultLength);
            }

            return new OrderName(value);
        }
    }
}
