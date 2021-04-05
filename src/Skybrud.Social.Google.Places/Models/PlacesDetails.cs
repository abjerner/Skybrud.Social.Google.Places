using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Places.Models {

    /// <summary>
    /// Class representing details about a place as received from the Google Places API.
    /// </summary>
    public class PlacesDetails : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets an array of separate address components used to compose a given address. For example, the address
        /// <c>111 8th Avenue, New York, NY</c> contains separate address components for <c>111</c> (the
        /// street number, <c>8th Avenue</c> (the route), <c>New York</c> (the city) and <c>NY</c>
        /// (the US state).
        /// </summary>
        public PlacesAddressComponent[] AddressComponents { get; }

        /// <summary>
        /// Gets a representation of the place's address in the <strong>adr microformat</strong>.
        /// </summary>
        public string AdrAddress { get; }

        /// <summary>
        /// Gets the operational status of the place, if it is a business. If no data exists, the value of this
        /// property will be <see cref="PlacesBusinessStatus.Unspecified"/>.
        /// </summary>
        public PlacesBusinessStatus BusinessStatus { get; }

        /// <summary>
        /// Gets whether a business status is available for this place.
        /// </summary>
        public bool HasPlacesBusinessStatus => BusinessStatus != PlacesBusinessStatus.Unspecified;

        /// <summary>
        /// Gets a a string containing the human-readable address of this place. Often this address is equivalent to
        /// the "postal address," which sometimes differs from country to country. This address is generally composed
        /// of one or more <see cref="AddressComponents"/> fields.
        /// </summary>
        public string FormattedAddress { get; }

        /// <summary>
        /// Gets the formatted phone number of the place. Use <see cref="HasPhoneNumber"/> to check whether a phone
        /// number has been specified for the place.
        /// </summary>
        public string FormattedPhoneNumber { get; }

        /// <summary>
        /// Gets whether a phone number was specified for the place. If <c>false</c>, <see cref="FormattedPhoneNumber"/> will be empty.
        /// </summary>
        public bool HasPhoneNumber => string.IsNullOrWhiteSpace(FormattedPhoneNumber) == false;

        /// <summary>
        /// Gets geometric information about the place.
        /// </summary>
        public PlacesGeometry Geometry { get; }

        /// <summary>
        /// Gets the URL of a suggested icon which may be displayed to the user when indicating this result on a map.
        /// </summary>
        public string Icon { get; }

        /// <summary>
        /// Gets the place's phone number in international format. International format includes the country code, and
        /// is prefixed with the plus (+) sign. For example, the <see cref="InternationalPhoneNumber"/> for Google's
        /// Sydney, Australia office is <c>+61 2 9374 4000</c>.
        /// </summary>
        public string InternationalPhoneNumber { get; }

        /// <summary>
        /// Gets the human-readable name for the returned result. For <c>establishment</c> results, this is
        /// usually the canonicalized business name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets information about the opening hours of the place. Use the <see cref="HasOpeningHours"/> property to
        /// see whether opening hours has been specified for the place.
        /// </summary>
        public PlacesOpeningHours OpeningHours { get; }

        /// <summary>
        /// Gets whether opening hours has been specified for the place.
        /// </summary>
        public bool HasOpeningHours => OpeningHours != null;

        /// <summary>
        /// Gets whether the place has permanently shut down.
        /// </summary>
        public bool HasPermanentlyClosed { get; }

        // TODO: Add support for the "photos" property

        /// <summary>
        /// Gets a textual identifier that uniquely identifies a place.
        /// </summary>
        public string PlaceId { get; }

        /// <summary>
        /// Gets the price level of the place, on a scale of <c>0</c> to <c>4</c>. The exact amount
        /// indicated by a specific value will vary from region to region.
        /// </summary>
        public PlacesPriceLevel PriceLevel { get; }

        /// <summary>
        /// Indicates whether a price level (see <see cref="PriceLevel"/>) was specified for the place.
        /// </summary>
        public bool HasPriceLevel => PriceLevel != PlacesPriceLevel.Unspecified;

        /// <summary>
        /// Gets the the place's rating, from <c>1.0</c> to <c>5.0</c>, based on aggregated user reviews. Not all places have a rating.
        /// </summary>
        public float Rating { get; }

        /// <summary>
        /// Gets whether the rating has a value.
        /// </summary>
        public bool HasRating => Rating < float.Epsilon;

        /// <summary>
        /// Decprecated in favor of <see cref="PlaceId"/>.
        /// </summary>
        public string Reference { get; }

        // TODO: Add support for the "reviews" property

        public string Scope { get; }

        /// <summary>
        /// Gets an array of feature types describing the given result.
        /// </summary>
        public string[] Types { get; }

        /// <summary>
        /// Gets the URL of the official Google page for this place. This will be the Google-owned page that contains
        /// the best available information about the place. Applications must link to or embed this page on any screen
        /// that shows detailed results about the place to the user.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the place's current timezone offset from UTC.
        /// </summary>
        public TimeSpan UtcOffset { get; }

        /// <summary>
        /// Gets a simplified address for the place, including the street name, street number, and locality, but not
        /// the province/state, postal code, or country. For example, Google's Sydney, Australia office has a
        /// <see cref="Vicinity"/> value of <c>48 Pirrama Road, Pyrmont</c>.
        /// </summary>
        public string Vicinity { get; }

        /// <summary>
        /// Gets the authoritative website for this place, such as a business' homepage.
        /// </summary>
        public string Website { get; }

        /// <summary>
        /// Gets whether a website was specified for the place (whether the <see cref="Website"/> property has a value). 
        /// </summary>
        public bool HasWebsite => string.IsNullOrWhiteSpace(Website) == false;

        #endregion

        #region Constructors

        private PlacesDetails(JObject obj) : base(obj) {
            AddressComponents = obj.GetArray("address_components", PlacesAddressComponent.Parse);
            AdrAddress = obj.GetString("adr_address");
            BusinessStatus = obj.GetString("business_status", ParseBusinessStatus);
            FormattedAddress = obj.GetString("formatted_address");
            FormattedPhoneNumber = obj.GetString("formatted_phone_number");
            Geometry = obj.GetObject("geometry", PlacesGeometry.Parse);
            Icon = obj.GetString("icon");
            InternationalPhoneNumber = obj.GetString("international_phone_number");
            Name = obj.GetString("name");
            OpeningHours = obj.GetObject("opening_hours", PlacesOpeningHours.Parse);
            HasPermanentlyClosed = obj.GetBoolean("permanently_closed");
            PlaceId = obj.GetString("place_id");
            PriceLevel = obj.HasValue("price_level") ? obj.GetEnum<PlacesPriceLevel>("price_level") : PlacesPriceLevel.Unspecified;
            Rating = obj.GetFloat("rating");
            Reference = obj.GetString("reference");
            Scope = obj.GetString("scope");
            Types = obj.GetStringArray("types");
            Url = obj.GetString("url");
            UtcOffset = obj.GetDouble("utc_offset", TimeSpan.FromMinutes);
            Vicinity = obj.GetString("vicinity");
            Website = obj.GetString("website");
        }

        #endregion

        #region Member methods

        private PlacesBusinessStatus ParseBusinessStatus(string value) {
            if (string.IsNullOrWhiteSpace(value)) return PlacesBusinessStatus.Unspecified;
            return EnumUtils.ParseEnum<PlacesBusinessStatus>(value);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a user from the specified <c>obj</c>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="PlacesDetails"/> representing the place.</returns>
        public static PlacesDetails Parse(JObject obj) {
            return obj == null ? null : new PlacesDetails(obj);
        }

        #endregion

    }

}