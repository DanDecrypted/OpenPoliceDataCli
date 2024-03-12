using FluentValidation;
using OpenPoliceDataCli.Options;
using System.Text.RegularExpressions;

namespace OpenPoliceDataCli.Validators;

public partial class LatLngOptionsValidator : AbstractValidator<LatLngOptions>
{
    public LatLngOptionsValidator()
    {
        RuleFor(x => x.Latitude)
            .Matches(LatRegex())
            .WithMessage(lnglat => $"Latitude must be a valid Latitude value ({lnglat.Latitude})");

        RuleFor(x => x.Longitude)
            .Matches(LngRegex())
            .WithMessage(lnglat => $"Longitude must be a valid Latitude value ({lnglat.Longitude})");

        RuleFor(x => x.Date)
            .Matches(DateRegex())
            .WithMessage(lnglat => $"Date must be in the format yyyy-mm for your chosen date ({lnglat.Date})");
    }

    [GeneratedRegex("^[-+]?([1-8]?\\d(\\.\\d+)?|90(\\.0+)?)$")]
    private static partial Regex LatRegex();

    [GeneratedRegex("^[-+]?(180(\\.0+)?|((1[0-7]\\d)|([1-9]?\\d))(\\.\\d+)?)$")]
    private static partial Regex LngRegex();

    [GeneratedRegex(@"^\d{4}-\d{2}$")]
    private static partial Regex DateRegex();
}
