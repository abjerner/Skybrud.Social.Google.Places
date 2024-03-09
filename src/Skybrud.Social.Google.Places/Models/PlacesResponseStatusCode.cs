namespace Skybrud.Social.Google.Places.Models {

    /// <summary>
    /// Represents the status code of the response received in the Google Places API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/details#PlaceDetailsStatusCodes</cref>
    /// </see>
    /// <see>
    ///     <cref>https://developers.google.com/places/web-service/search#PlaceSearchStatusCodes</cref>
    /// </see>
    public enum PlacesResponseStatusCode {

        /// <summary>
        /// Indicates that no errors occurred; that the request was successful.
        /// </summary>
        Ok,

        /// <summary>
        /// Indicates a server-side error; trying again may be successful.
        /// </summary>
        UnknownError,

        /// <summary>
        /// Indicates that the referenced location (<c>place_id</c>) was valid but no longer refers to a valid result. This may occur if the establishment is no longer in business.
        /// </summary>
        ZeroResults,

        /// <summary>
        /// Indicates any of the following:
        ///
        /// <ul>
        /// <li>You have exceeded the QPS limits.</li>
        /// <li>Billing has not been enabled on your account.</li>
        /// <li>The monthly $200 credit, or a self-imposed usage cap, has been exceeded.</li>
        /// <li>The provided method of payment is no longer valid (for example, a credit card has expired).</li>
        /// </ul>
        ///
        /// See the <a href="https://developers.google.com/maps/faq#over-limit-key-error">Maps FAQ</a> for more information about how to resolve this error.
        /// </summary>
        OverQueryLimit,

        /// <summary>
        /// Indicates that your request was denied, generally because:
        ///
        /// <ul>
        /// <li>The request is missing an API key.</li>
        /// <li>The <c>key</c> parameter is invalid.</li>
        /// </ul>
        /// </summary>
        RequestDenied,

        /// <summary>
        /// Generally indicates that the query (<c>place_id</c>) is missing.
        /// </summary>
        InvalidRequest,

        /// <summary>
        /// Indicates that the referenced location (<c>place_id</c>) was not found in the Places database.
        /// </summary>
        NotFound

    }

}