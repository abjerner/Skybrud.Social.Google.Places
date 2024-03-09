﻿using System;

namespace Skybrud.Social.Google.Places.Exceptions;

/// <summary>
/// Class representing an exception related to the implementation for the Google Places API.
/// </summary>
public class PlacesException : Exception {

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public PlacesException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public PlacesException(string message, Exception? innerException) : base(message, innerException) { }

}