using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Class partially describing the opening hours of a Google place.
/// </summary>
public class PlacesOpeningHoursPeriod : GoogleObject {

    #region Properties

    public PlacesOpeningHoursPeriodItem? Open { get; }

    [MemberNotNullWhen(true, "Open")]
    public bool HasOpen => Open != null;

    public PlacesOpeningHoursPeriodItem? Close { get; }

    [MemberNotNullWhen(true, "Close")]
    public bool HasClose => Close != null;

    #endregion

    #region Constructors

    private PlacesOpeningHoursPeriod(JObject obj) : base(obj) {
        Open = obj.GetObject("open", PlacesOpeningHoursPeriodItem.Parse);
        Close = obj.GetObject("close", PlacesOpeningHoursPeriodItem.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses specified <paramref name="obj"/> into an instance of <see cref="PlacesOpeningHoursPeriod"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
    /// <returns>An instance of <see cref="PlacesOpeningHoursPeriod"/>.</returns>
    public static PlacesOpeningHoursPeriod Parse(JObject obj) {
        return new PlacesOpeningHoursPeriod(obj);
    }

    #endregion

}