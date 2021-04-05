using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {
    
    /// <summary>
    /// Class representing the response body of a call to get the details about a place in the Google Places API.
    /// </summary>
    public class PlacesGetDetailsResponseBody : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the place returned in the response.
        /// </summary>
        public PlacesDetailsResult Result { get; }

        /// <summary>
        /// Gets the status of the response from the Places API.
        /// </summary>
        public PlacesResponseStatusCode Status { get; }

        #endregion

        #region Constructors

        private PlacesGetDetailsResponseBody(JObject obj) : base(obj) {
            Result = obj.GetObject("result", PlacesDetailsResult.Parse);
            Status = obj.GetEnum<PlacesResponseStatusCode>("status");
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="PlacesGetDetailsResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesGetDetailsResponseBody"/>.</returns>
        public static PlacesGetDetailsResponseBody Parse(JObject obj) {
            return obj == null ? null : new PlacesGetDetailsResponseBody(obj);
        }

        #endregion

    }

}