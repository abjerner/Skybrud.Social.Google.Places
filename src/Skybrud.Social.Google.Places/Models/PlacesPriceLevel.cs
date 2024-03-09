namespace Skybrud.Social.Google.Places.Models;

/// <summary>
/// Enum class describing the price level of a Google place, on a scale of 0 to 4. The exact amount indicated by a
/// specific value will vary from region to region.
/// </summary>
public enum PlacesPriceLevel {

    /// <summary>
    /// Indicates that a place is in the <strong>Free</strong> price range.
    /// </summary>
    Free,

    /// <summary>
    /// Indicates that a place is in the <strong>Inexpensive</strong> price range.
    /// </summary>
    Inexpensive,

    /// <summary>
    /// Indicates that a place is in the <strong>Moderate</strong> price range.
    /// </summary>
    Moderate,

    /// <summary>
    /// Indicates that a place is in the <strong>Expensive</strong> price range.
    /// </summary>
    Expensive,

    /// <summary>
    /// Indicates that a place is in the <strong>Very Expensive</strong> price range.
    /// </summary>
    VeryExpensive

}