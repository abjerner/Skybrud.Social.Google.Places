using Skybrud.Essentials.Http;
using Skybrud.Social.Google.Places.Models;

namespace Skybrud.Social.Google.Places.Responses {

    /// <summary>
    /// Class representing the response of a text search in the Google Places API.
    /// </summary>
    public class PlacesTextSearchResponse : PlacesResponse<PlacesTextSearchResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public PlacesTextSearchResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, PlacesTextSearchResponseBody.Parse);
        }

    }

}