using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    public class PlacesNearbySearchResponseBody : GoogleApiObject {
        
        #region Properties

        public string NextPageToken { get; private set; }

        public bool HasNextPageToken => string.IsNullOrWhiteSpace(NextPageToken) == false;

        /// <summary>
        /// Gets an array of places returned in the response.
        /// </summary>
        public PlacesDetails[] Results { get; private set; }

        /// <summary>
        /// Gets the status of the response from the Places API.
        /// </summary>
        public PlacesResponseStatusCode Status { get; private set; }

        #endregion

        #region Constructors

        private PlacesNearbySearchResponseBody(JObject obj) : base(obj) {
            NextPageToken = obj.GetString("next_page_token");    
            Results = obj.GetArrayItems("results", PlacesDetails.Parse);
            Status = obj.GetEnum<PlacesResponseStatusCode>("status");
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="PlacesNearbySearchResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesNearbySearchResponseBody"/>.</returns>
        public static PlacesNearbySearchResponseBody Parse(JObject obj) {
            return obj == null ? null : new PlacesNearbySearchResponseBody(obj);
        }

        #endregion

    }

}