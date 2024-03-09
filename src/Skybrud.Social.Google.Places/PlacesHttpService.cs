using System;
using JetBrains.Annotations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Places.Http;
using Skybrud.Social.Google.Places.Options;
using Skybrud.Social.Google.Places.Responses;

namespace Skybrud.Social.Google.Places;

/// <summary>
/// Service implementation for the Google Places API.
/// </summary>
/// <see>
///     <cref>https://developers.google.com/places/web-service/details</cref>
/// </see>
/// <see>
///     <cref>https://developers.google.com/places/web-service/search</cref>
/// </see>
public class PlacesHttpService : GoogleHttpServiceBase {

    #region Properties

    /// <summary>
    /// Gets a reference to the Places HTTP client.
    /// </summary>
    public PlacesHttpClient Client => Service.Client.Places();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified Google <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The Google service to be used.</param>
    public PlacesHttpService(GoogleHttpService service) : base(service) { }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets details about the place with the specified <paramref name="placeId"/>.
    /// </summary>
    /// <param name="placeId">The ID of the place</param>
    /// <returns>An instance of <see cref="PlacesDetailsResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/details</cref>
    /// </see>
    public PlacesDetailsResponse GetDetails(string placeId) {
        return new PlacesDetailsResponse(Client.GetDetails(placeId));
    }

    /// <summary>
    /// Gets details about the place matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="PlacesDetailsResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/details</cref>
    /// </see>
    public PlacesDetailsResponse GetDetails(PlacesGetDetailsOptions options) {
        return new PlacesDetailsResponse(Client.GetDetails(options));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="latitude"/>,
    /// <paramref name="longitude"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="PlacesNearbySearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public PlacesNearbySearchResponse NearbySearch([ValueRange(-180, +180)] double latitude, [ValueRange(-180, +180)] double longitude, [ValueRange(0, 50000)] int radius) {
        return new PlacesNearbySearchResponse(Client.NearbySearch(latitude, latitude, radius));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="location"/> and <paramref name="radius"/>.
    /// </summary>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="PlacesNearbySearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public PlacesNearbySearchResponse NearbySearch(IPoint location, [ValueRange(0, 50000)] int radius) {
        return new PlacesNearbySearchResponse(Client.NearbySearch(location, radius));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="pageToken"/>.
    /// </summary>
    /// <param name="pageToken">The page token for the next page.</param>
    /// <returns>An instance of <see cref="PlacesNearbySearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public PlacesNearbySearchResponse NearbySearch(string pageToken) {
        return new PlacesNearbySearchResponse(Client.NearbySearch(pageToken));
    }

    /// <summary>
    /// Performs a search for places within a area, based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="PlacesNearbySearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchRequests</cref>
    /// </see>
    public PlacesNearbySearchResponse NearbySearch(PlacesNearbySearchOptions options) {
        return new PlacesNearbySearchResponse(Client.NearbySearch(options));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <returns>An instance of <see cref="PlacesTextSearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public PlacesTextSearchResponse TextSearch(string query) {
        if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));
        return new PlacesTextSearchResponse(Client.TextSearch(query));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="latitude">The latitude of the center location the search should be based on.</param>
    /// <param name="longitude">The longitude of the center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="PlacesTextSearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public PlacesTextSearchResponse TextSearch(string query, [ValueRange(-180, +180)] double latitude, [ValueRange(-180, +180)] double longitude, [ValueRange(0, 50000)] int radius) {
        return new PlacesTextSearchResponse(Client.TextSearch(query, latitude, longitude, radius));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The text string to search for.</param>
    /// <param name="location">The center location the search should be based on.</param>
    /// <param name="radius">The distance (in meters) within which to return place results. The maximum allowed radius is <c>50000</c> meters.</param>
    /// <returns>An instance of <see cref="PlacesTextSearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public PlacesTextSearchResponse TextSearch(string query, IPoint location, [ValueRange(0, 50000)] int radius) {
        return new PlacesTextSearchResponse(Client.TextSearch(query, location, radius));
    }

    /// <summary>
    /// Performs a text based search for places matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the call to the API.</param>
    /// <returns>An instance of <see cref="PlacesTextSearchResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#TextSearchRequests</cref>
    /// </see>
    public PlacesTextSearchResponse TextSearch(PlacesTextSearchOptions options) {
        return new PlacesTextSearchResponse(Client.TextSearch(options));
    }

    #endregion

}