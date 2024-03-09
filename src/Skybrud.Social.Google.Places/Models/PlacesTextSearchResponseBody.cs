using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    public class PlacesTextSearchResponseBody : GoogleObject {

        #region Properties

        public string NextPageToken { get; }

        public bool HasNextPageToken {
            get { return string.IsNullOrWhiteSpace(NextPageToken) == false; }
        }

        /// <summary>
        /// Gets an array of places returned in the response.
        /// </summary>
        public PlacesDetails[] Results { get; }

        /// <summary>
        /// Gets the status of the response from the Places API.
        /// </summary>
        public PlacesResponseStatusCode Status { get; }

        #endregion

        #region Constructors

        private PlacesTextSearchResponseBody(JObject obj) : base(obj) {
            NextPageToken = obj.GetString("next_page_token");
            Results = obj.GetArrayItems("results", PlacesDetails.Parse);
            Status = obj.GetEnum<PlacesResponseStatusCode>("status");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="PlacesTextSearchResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesTextSearchResponseBody"/>.</returns>
        public static PlacesTextSearchResponseBody Parse(JObject obj) {
            return obj == null ? null : new PlacesTextSearchResponseBody(obj);
        }

        #endregion

    }

}