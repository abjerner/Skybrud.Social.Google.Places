using System;
using System.Globalization;
using JetBrains.Annotations;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Places.Models;

namespace Skybrud.Social.Google.Places.Options;

/// <see>
///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
/// </see>
public class PlacesTextSearchOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Required: Gets or sets the text string on which to search, for example: <c>restaurant</c> or
    /// <c>123 Main Street</c>. The Google Places service will return candidate matches based on this string and
    /// order the results based on their perceived relevance. This parameter becomes optional if the
    /// <see cref="Type"/> parameter is also used in the search request.
    /// </summary>
    public string? Query { get; set; }

    /// <summary>
    /// Optional: Gets or sets the latitude/longitude around which to retrieve place information. If you specify a
    /// <see cref="Location"/> parameter, you must also specify a <see cref="Radius"/> parameter.
    /// </summary>
    public IPoint? Location { get; set; }

    /// <summary>
    /// Required: Gets or sets the distance (in meters) within which to bias place results. The maximum allowed
    /// radius is <c>50000</c> meters. Results inside of this region will be ranked higher than results
    /// outside of the search circle; however, prominent results from outside of the search radius may be included.
    /// </summary>
    [ValueRange(0, 50000)]
    public int? Radius { get; set; }

    /// <summary>
    /// Optional: Gets or sets the language code, indicating in which language the results should be returned, if
    /// possible. See the <a href="https://developers.google.com/maps/faq#languagesupport">list of supported
    /// languages</a> and their codes.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Optional: Gets or sets the minimum price level of the places that should be returned by the search.
    /// </summary>
    public PlacesPriceLevel? MinPrice { get; set; }

    /// <summary>
    /// Optional: Gets or sets the maximum price level of the places that should be returned by the search.
    /// </summary>
    public PlacesPriceLevel? MaxPrice { get; set; }

    /// <summary>
    /// Gets or sets the type of the places that should be returned by the search.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets a page token from a from a previously run search to return the next 20 results. Setting a
    /// <see cref="PageToken"/> parameter will execute a search with the same parameters used previously — all
    /// parameters other than <see cref="PageToken"/> will be ignored.
    /// </summary>
    public string? PageToken { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public PlacesTextSearchOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="query"/>.
    /// </summary>
    public PlacesTextSearchOptions(string query) {
        Query = query;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="query"/>, <paramref name="latitude"/>, <paramref name="longitude"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    public PlacesTextSearchOptions(string query, [ValueRange(-180, +180)] double latitude, [ValueRange(-180, +180)] double longitude, [ValueRange(0, 50000)] int radius) {
        Query = query;
        Location = new Point(latitude, longitude);
        Radius = radius;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="query"/>, <paramref name="location"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    public PlacesTextSearchOptions(string query, IPoint location, [ValueRange(0, 50000)] int radius) {
        Query = query;
        Location = location;
        Radius = radius;
    }

    #endregion


    #region Member methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {

        if (Location == null) throw new PropertyNotSetException(nameof(Location));

        // Make sure either Latitude or Longitude are specified ("0,0" is considered invalid)
        if (Math.Abs(Location.Latitude) < double.Epsilon && Math.Abs(Location.Longitude) < double.Epsilon) throw new PropertyNotSetException(nameof(Location.Latitude));

        // Initialize the query string
        IHttpQueryString query = new HttpQueryString();
        if (!string.IsNullOrWhiteSpace(Query)) query.Add("query", Query!);
        query.Add("location", string.Format(CultureInfo.InvariantCulture, "{0},{1}", Location.Latitude, Location.Longitude));
        if (Radius > 0) query.Add("radius", Radius);
        if (!string.IsNullOrWhiteSpace(Language)) query.Add("language", Language!);
        if (MinPrice is not null) query.Add("minprice", (int) MinPrice.Value - 1);
        if (MaxPrice is not null) query.Add("maxprice", (int) MaxPrice.Value - 1);
        if (!string.IsNullOrWhiteSpace(Type)) query.Add("type", Type!);
        if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pagetoken", PageToken!);

        // Create the request
        return HttpRequest.Get("https://maps.googleapis.com/maps/api/place/textsearch/json", query);

    }

    #endregion

}