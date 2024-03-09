using System;
using JetBrains.Annotations;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.Places.Options;

namespace Skybrud.Social.Google.Places.Http;

/// <summary>
/// HTTP client used for communicationg with the Google Places API.
/// </summary>
/// <see>
///     <cref>https://developers.google.com/places/web-service/details</cref>
/// </see>
/// <see>
///     <cref>https://developers.google.com/places/web-service/search</cref>
/// </see>
public class PlacesHttpClient : GoogleHttpClientBase {

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified Google OAuth <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The Google OAuth client to be used.</param>
    public PlacesHttpClient(GoogleOAuthClient client) : base(client) { }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets details about the place with the specified <paramref name="placeId"/>.
    /// </summary>
    /// <param name="placeId">The ID of the place</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/details</cref>
    /// </see>
    public IHttpResponse GetDetails(string placeId) {
        if (string.IsNullOrWhiteSpace(placeId)) throw new ArgumentNullException(nameof(placeId));
        return GetDetails(new PlacesGetDetailsOptions(placeId));
    }

    /// <summary>
    /// Gets details about the place matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/details</cref>
    /// </see>
    public IHttpResponse GetDetails(PlacesGetDetailsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="latitude"/>,
    /// <paramref name="longitude"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public IHttpResponse NearbySearch([ValueRange(-180, +180)] double latitude, [ValueRange(-180, +180)] double longitude, [ValueRange(0, 50000)] int radius) {
        return NearbySearch(new PlacesNearbySearchOptions(latitude, longitude, radius));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="location"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public IHttpResponse NearbySearch(IPoint location, [ValueRange(0, 50000)] int radius) {
        if (location == null) throw new ArgumentNullException(nameof(location));
        return NearbySearch(new PlacesNearbySearchOptions(location, radius));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="pageToken"/>.
    /// </summary>
    /// <param name="pageToken">The page token for the next page.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public IHttpResponse NearbySearch(string pageToken) {
        if (string.IsNullOrWhiteSpace(pageToken)) throw new ArgumentNullException(nameof(pageToken));
        return NearbySearch(new PlacesNearbySearchOptions(pageToken));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public IHttpResponse NearbySearch(PlacesNearbySearchOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public IHttpResponse TextSearch(string query) {
        if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));
        return TextSearch(new PlacesTextSearchOptions(query));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public IHttpResponse TextSearch(string query, [ValueRange(-180, +180)] double latitude, [ValueRange(-180, +180)] double longitude, [ValueRange(0, 50000)] int radius) {
        return TextSearch(new PlacesTextSearchOptions(query, latitude, longitude, radius));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public IHttpResponse TextSearch(string query, IPoint location, [ValueRange(0, 50000)] int radius) {
        if (location == null) throw new ArgumentNullException(nameof(location));
        return TextSearch(new PlacesTextSearchOptions(query, location, radius));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public IHttpResponse TextSearch(PlacesTextSearchOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

}