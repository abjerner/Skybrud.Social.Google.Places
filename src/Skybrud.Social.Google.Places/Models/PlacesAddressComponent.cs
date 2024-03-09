using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Class representing an address component of a <see cref="PlacesDetails"/>.
/// </summary>
public class PlacesAddressComponent : GoogleObject {

    #region Properties

    /// <summary>
    /// Gets the long name of the address component.
    /// </summary>
    public string LongName { get; }

    /// <summary>
    /// Gets the short name of the address component.
    /// </summary>
    public string ShortName { get; }

    /// <summary>
    /// Gets an array of tags/keywords that describe the type of the address component.
    /// </summary>
    public IReadOnlyList<string> Types { get; }

    #endregion

    #region Constructors

    private PlacesAddressComponent(JObject obj) : base(obj) {
        LongName = obj.GetString("long_name")!;
        ShortName = obj.GetString("short_name")!;
        Types = obj.GetStringArray("types");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Gets an instance of <see cref="PlacesAddressComponent"/> from the specified <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> representing the address component.</param>
    /// <returns>An instance of <see cref="PlacesAddressComponent"/>.</returns>
    public static PlacesAddressComponent Parse(JObject obj) {
        return new PlacesAddressComponent(obj);
    }

    #endregion

}