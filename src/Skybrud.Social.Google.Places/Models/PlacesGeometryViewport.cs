using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    /// <summary>
    /// Class representing the viewport of a <see cref="PlacesDetailsResult"/>.
    /// </summary>
    public class PlacesGeometryViewport : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the north east point of the viewport.
        /// </summary>
        public PlacesGeometryLocation NorthEast { get; }

        /// <summary>
        /// Gets the south west point of the viewport.
        /// </summary>
        public PlacesGeometryLocation SouthWest { get; }

        #endregion

        #region Constructors

        private PlacesGeometryViewport(JObject obj) : base(obj) {
            NorthEast = obj.GetObject("northeast", PlacesGeometryLocation.Parse);
            SouthWest = obj.GetObject("southwest", PlacesGeometryLocation.Parse);
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="PlacesGeometryViewport"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesGeometryViewport"/>.</returns>
        public static PlacesGeometryViewport Parse(JObject obj) {
            return obj == null ? null : new PlacesGeometryViewport(obj);
        }

        #endregion

    }

}