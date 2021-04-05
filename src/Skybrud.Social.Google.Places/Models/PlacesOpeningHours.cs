using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {
    
    /// <summary>
    /// Class describing the opening hours of a Google place.
    /// </summary>
    public class PlacesOpeningHours : GoogleApiObject {
        
        #region Properties

        public bool IsOpenNow { get; }

        public PlacesOpeningHoursPeriod[] Periods { get; }

        public string[] WeekdayText { get; }

        #endregion

        #region Constructors

        private PlacesOpeningHours(JObject obj) : base(obj) {
            IsOpenNow = obj.GetBoolean("open_now");
            Periods = obj.GetArrayItems("periods", PlacesOpeningHoursPeriod.Parse);
            WeekdayText = obj.GetStringArray("weekday_text");
        }

        #endregion
        
        #region Static methods
        
        /// <summary>
        /// Parses specified <paramref name="obj"/> into an instance of <see cref="PlacesOpeningHours"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="PlacesOpeningHours"/>.</returns>
        public static PlacesOpeningHours Parse(JObject obj) {
            return obj == null ? null : new PlacesOpeningHours(obj);
        }

        #endregion

    }

}