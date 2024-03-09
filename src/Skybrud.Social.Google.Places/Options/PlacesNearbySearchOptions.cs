using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Google.Places.Models;

namespace Skybrud.Social.Google.Places.Options;

/// <see>
///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
/// </see>
public class PlacesNearbySearchOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Required: Gets or sets the latitude around which to retrieve place information.
    /// </summary>
    [ValueRange(-180, +180)]
    public double Latitude { get; set; }

    /// <summary>
    /// Required: Gets or sets the longitude around which to retrieve place information.
    /// </summary>
    [ValueRange(-90, +90)]
    public double Longitude { get; set; }

    /// <summary>
    /// Required: Gets or sets the distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.
    /// </summary>
    [ValueRange(0, 50000)]
    public int Radius { get; set; }

    /// <summary>
    /// Optional: Gets or sets a term to be matched against all content that Google has indexed for this place, including but not limited to name, type, and address, as well as customer reviews and other third-party content.
    /// </summary>
    public string Keyword { get; set; }

    /// <summary>
    /// Optional: Gets or sets the language code, indicating in which language the results should be returned, if
    /// possible. See the <a href="https://developers.google.com/maps/faq#languagesupport">list of supported
    /// languages</a> and their codes.
    /// </summary>
    public string Language { get; set; }

    /// <summary>
    /// Optional: Gets or sets the minimum price level of the places that should be returned by the search.
    /// </summary>
    public PlacesPriceLevel MinPrice { get; set; }

    /// <summary>
    /// Optional: Gets or sets the maximum price level of the places that should be returned by the search.
    /// </summary>
    public PlacesPriceLevel MaxPrice { get; set; }

    /// <summary>
    /// Gets or sets a term to be matched against all content that Google has indexed for this place. Equivalent to
    /// <see cref="Keyword"/>. The <see cref="Name"/> field is no longer restricted to place names. Values in this
    /// field are combined with values in the <see cref="Keyword"/> field and passed as part of the same search string.
    ///
    /// Google recommends using only the <see cref="Keyword"/> parameter for all search terms.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Specifies the order in which results are listed. Note that <see cref="RankBy"/> must not be included if
    /// <see cref="Radius"/> is specified. Possible values are:
    ///
    /// <strong>prominence</strong> (default). This option sorts results based on their importance. Ranking will
    /// favor prominent places within the specified area. Prominence can be affected by a place's ranking in
    /// Google's index, global popularity, and other factors.
    ///
    /// <strong>distance</strong>. This option biases search results in ascending order by their distance from the
    /// specified location. When <see cref="PlacesRankBy.Distance"/> is specified, one or more of
    /// <see cref="Keyword"/>, <see cref="Name"/>, or <see cref="Type"/> is required.
    /// </summary>
    public PlacesRankBy RankBy { get; set; }

    /// <summary>
    /// Gets or sets the type of the places that should be returned by the search.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets a page token from a from a previously run search to return the next 20 results. Setting a
    /// <see cref="PageToken"/> parameter will execute a search with the same parameters used previously — all
    /// parameters other than <see cref="PageToken"/> will be ignored.
    /// </summary>
    public string PageToken { get; set; }

    public List<string> Fields { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public PlacesNearbySearchOptions() { }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="latitude"/>, <paramref name="longitude"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    public PlacesNearbySearchOptions([ValueRange(-180, +180)] double latitude, [ValueRange(-90, +90)] double longitude, [ValueRange(0, 50000)] int radius) {
        Latitude = latitude;
        Longitude = longitude;
        Radius = radius;
    }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="location"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    public PlacesNearbySearchOptions(IPoint location, [ValueRange(0, 5000)] int radius) {
        if (location == null) throw new ArgumentNullException(nameof(location));
        Latitude = location.Latitude;
        Longitude = location.Longitude;
        Radius = radius;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="pageToken"/>.
    /// </summary>
    /// <param name="pageToken">The page token for the next page.</param>
    public PlacesNearbySearchOptions(string pageToken) {
        PageToken = pageToken;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {

        // Make sure either Latitude or Longitude are specified ("0,0" is considered invalid)
        if (Math.Abs(Latitude) < double.Epsilon && Math.Abs(Longitude) < double.Epsilon) throw new PropertyNotSetException(nameof(Latitude));

        // Initialize the query string
        IHttpQueryString query = new HttpQueryString {
            {"location", string.Format(CultureInfo.InvariantCulture, "{0},{1}", Latitude, Longitude)}
        };

        // Append the language if specified
        if (Radius > 0) query.Add("radius", Radius);
        if (string.IsNullOrWhiteSpace(Keyword) == false) query.Add("keyword", Keyword);
        if (string.IsNullOrWhiteSpace(Language) == false) query.Add("language", Language);
        if (MinPrice != PlacesPriceLevel.Unspecified) query.Add("minprice", (int)MinPrice - 1);
        if (MaxPrice != PlacesPriceLevel.Unspecified) query.Add("maxprice", (int)MaxPrice - 1);
        if (string.IsNullOrWhiteSpace(Name) == false) query.Add("name", Name);
        query.Add("rankby", StringUtils.ToCamelCase(RankBy));
        if (string.IsNullOrWhiteSpace(Type) == false) query.Add("type", Type);
        if (string.IsNullOrWhiteSpace(PageToken) == false) query.Add("pagetoken", PageToken);
        if (Fields != null && Fields.Count > 0) query.Add("fields", string.Join(",", Fields));

        // Create the request
        return HttpRequest.Get("https://maps.googleapis.com/maps/api/place/nearbysearch/json", query);

    }

    #endregion

}