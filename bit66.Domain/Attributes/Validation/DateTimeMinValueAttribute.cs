using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.Attributes.Validation;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class DateTimeMinValueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        DateTime? dt = (DateTime?)value;
        if (dt >= DateTime.UtcNow.Date)
        {
            return false;
        }

        return true;
    }
}