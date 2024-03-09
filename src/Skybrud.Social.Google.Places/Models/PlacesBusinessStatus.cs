namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Indicates the operational status of the place, if it is a business. It can contain one of the following values.
/// If no data exists, business_status is not returned.
/// </summary>
public enum PlacesBusinessStatus {

    /// <summary>
    /// Indicatest hat the place is operational.
    /// </summary>
    Operational,

    /// <summary>
    /// Indicatest hat the place is temporarily closed.
    /// </summary>
    ClosedTemporarily,

    /// <summary>
    /// Indicatest hat the place is permanently closed.
    /// </summary>
    ClosedPermanently

}