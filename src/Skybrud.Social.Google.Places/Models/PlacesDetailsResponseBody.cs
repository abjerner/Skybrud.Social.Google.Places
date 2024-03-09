using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Class representing the response body of a response about a place in the Google Places API.
/// </summary>
public class PlacesDetailsResponseBody : GoogleObject {

    #region Properties

    /// <summary>
    /// Gets the place returned in the response.
    /// </summary>
    public PlacesDetails Result { get; }

    /// <summary>
    /// Gets the status of the response from the Places API.
    /// </summary>
    public PlacesResponseStatusCode Status { get; }

    #endregion

    #region Constructors

    private PlacesDetailsResponseBody(JObject obj) : base(obj) {
        Result = obj.GetObject("result", PlacesDetails.Parse);
        Status = obj.GetEnum<PlacesResponseStatusCode>("status");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="PlacesDetailsResponseBody"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
    /// <returns>An instance of <see cref="PlacesDetailsResponseBody"/>.</returns>
    public static PlacesDetailsResponseBody Parse(JObject obj) {
        return obj == null ? null : new PlacesDetailsResponseBody(obj);
    }

    #endregion

}