using FluentValidation;
using Peanut.Trade.TestTask.Models;

namespace Peanut.Trade.TestTask.Validators
{
    public class EstimateQueryContractValidator : AbstractValidator<EstimateQueryContract>
    {
        public EstimateQueryContractValidator()
        {
            RuleFor(c => c.InputAmount).GreaterThan(decimal.Zero);
            RuleFor(c => c.InputCurrency).NotEmpty();
            RuleFor(c => c.OutputCurrency).NotEmpty();
        }
    }
}
