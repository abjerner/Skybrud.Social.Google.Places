using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    /// <summary>
    /// Class partially describing the opening hours of a Google place.
    /// </summary>
    public class PlacesOpeningHoursPeriod : GoogleApiObject {
        
        #region Properties

        public PlacesOpeningHoursPeriodItem Open { get; }

        public bool HasOpen => Open != null;

        public PlacesOpeningHoursPeriodItem Close { get; }

        public bool HasClose => Close != null;

        #endregion

        #region Constructors

        private PlacesOpeningHoursPeriod(JObject obj) : base(obj) {
            Open = obj.GetObject("open", PlacesOpeningHoursPeriodItem.Parse);
            Close = obj.GetObject("close", PlacesOpeningHoursPeriodItem.Parse);
        }

        #endregion
        
        #region Static methods
        
        /// <summary>
        /// Parses specified <paramref name="obj"/> into an instance of <see cref="PlacesOpeningHoursPeriod"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesOpeningHoursPeriod"/>.</returns>
        public static PlacesOpeningHoursPeriod Parse(JObject obj) {
            return obj == null ? null : new PlacesOpeningHoursPeriod(obj);
        }

        #endregion

    }

}