using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    /// <summary>
    /// Class representing a point within a <see cref="PlacesDetailsResult"/>.
    /// </summary>
    public class PlacesGeometryLocation : GoogleApiObject, IPoint {

        #region Properties

        /// <summary>
        /// Gets the latitude of the point.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// gets the longitude of the point.
        /// </summary>
        public double Longitude { get; }

        #endregion

        #region Constructors

        private PlacesGeometryLocation(JObject obj) : base(obj) {
            Latitude = obj.GetDouble("lat");
            Longitude = obj.GetDouble("lng");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="PlacesGeometryLocation"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the location.</param>
        /// <returns>An instance of <see cref="PlacesGeometryLocation"/>.</returns>
        public static PlacesGeometryLocation Parse(JObject obj) {
            return obj == null ? null : new PlacesGeometryLocation(obj);
        }

        #endregion

    }

}