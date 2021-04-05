using Skybrud.Essentials.Http;
using Skybrud.Social.Google.Places.Models;

namespace Skybrud.Social.Google.Places.Responses {

    public class PlacesNearbySearchResponse : PlacesResponse<PlacesNearbySearchResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public PlacesNearbySearchResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, PlacesNearbySearchResponseBody.Parse);
        }

    }

}