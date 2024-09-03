using FluentValidation;
using Peanut.Trade.TestTask.Models;

namespace Peanut.Trade.TestTask.Validators
{
    public class RatesQueryContractValidator : AbstractValidator<RatesQueryContract>
    {
        public RatesQueryContractValidator()
        {
            RuleFor(c => c.BaseCurrency).NotEmpty();
            RuleFor(c => c.QuoteCurrency).NotEmpty();
        }
    }
}
