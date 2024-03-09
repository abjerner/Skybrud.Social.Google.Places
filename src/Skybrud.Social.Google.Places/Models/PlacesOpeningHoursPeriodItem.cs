using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Class partially describing the opening hours of a Google place.
/// </summary>
public class PlacesOpeningHoursPeriodItem : GoogleObject {

    #region Properties

    public DayOfWeek Day { get; }

    public TimeSpan Time { get; }

    #endregion

    #region Constructors

    private PlacesOpeningHoursPeriodItem(JObject obj) : base(obj) {
        Day = obj.GetEnum<DayOfWeek>("day");
        Time = TimeSpan.ParseExact(obj.GetString("time"), "hhmm", CultureInfo.InvariantCulture);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses specified <paramref name="obj"/> into an instance of <see cref="PlacesOpeningHoursPeriodItem"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
    /// <returns>An instance of <see cref="PlacesOpeningHoursPeriodItem"/>.</returns>
    public static PlacesOpeningHoursPeriodItem Parse(JObject obj) {
        return obj == null ? null : new PlacesOpeningHoursPeriodItem(obj);
    }

    #endregion

}