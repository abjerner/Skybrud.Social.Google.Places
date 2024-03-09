using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.Places.Options;

/// <see>
///     <cref>https://developers.google.com/places/web-service/details</cref>
/// </see>
public class PlacesGetDetailsOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the place to retrieve details about.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string PlaceId { get; set; }
#else
    public string? PlaceId { get; set; }
#endif

    /// <summary>
    /// Optional: Gets or sets the language code, indicating in which language the results should be returned, if
    /// possible. See the <a href="https://developers.google.com/maps/faq#languagesupport">list of supported
    /// languages</a> and their codes.
    /// </summary>
    public string? Language { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public PlacesGetDetailsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="placeId"/>.
    /// </summary>
    /// <param name="placeId">The ID of the place.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public PlacesGetDetailsOptions(string placeId) {
        PlaceId = placeId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {

        if (string.IsNullOrWhiteSpace(PlaceId)) throw new PropertyNotSetException(nameof(PlaceId));

        // Initialize the query string
        IHttpQueryString query = new HttpQueryString {
            { "placeid", PlaceId }
        };

        // Append the language if specified
        if (string.IsNullOrWhiteSpace(Language) == false) query.Add("language", Language);

        // Create the request
        return HttpRequest.Get("https://maps.googleapis.com/maps/api/place/details/json", query);

    }

    #endregion

}