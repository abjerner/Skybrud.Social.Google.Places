using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Class representing the geometry of a <see cref="PlacesDetails"/>.
/// </summary>
public class PlacesGeometry : GoogleObject {

    #region Properties

    /// <summary>
    /// Gets the geocoded latitude and longitude value. For normal address lookups, this field is typically the
    /// most important.
    /// </summary>
    public PlacesGeometryLocation Location { get; }

    /// <summary>
    /// Gets the recommended viewport for displaying the returned result, specified as two latitude and longitude
    /// values defining the southwest and northeast corner of the viewport bounding box. Generally the viewport is
    /// used to frame a result when displaying it to a user.
    /// </summary>
    public PlacesGeometryViewport Viewport { get; }

    #endregion

    #region Constructors

    private PlacesGeometry(JObject obj) : base(obj) {
        Location = obj.GetObject("location", PlacesGeometryLocation.Parse);
        Viewport = obj.GetObject("viewport", PlacesGeometryViewport.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Gets an instance of <see cref="PlacesGeometry"/> from the specified <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> representing the geometry object.</param>
    /// <returns>An instance of <see cref="PlacesGeometry"/>.</returns>
    public static PlacesGeometry Parse(JObject obj) {
        return obj == null ? null : new PlacesGeometry(obj);
    }

    #endregion

}