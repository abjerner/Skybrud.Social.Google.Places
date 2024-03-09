using Skybrud.Essentials.Http;
using Skybrud.Social.Google.Places.Models;

namespace Skybrud.Social.Google.Places.Responses;

/// <summary>
/// Class representing a response about a place in the Google Places API.
/// </summary>
public class PlacesDetailsResponse : PlacesResponse<PlacesDetailsResponseBody> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The underlying raw response the instance should be based on.</param>
    public PlacesDetailsResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, PlacesDetailsResponseBody.Parse);
    }

}