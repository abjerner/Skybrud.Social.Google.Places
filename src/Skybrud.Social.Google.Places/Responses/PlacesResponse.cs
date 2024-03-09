using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.Places.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Google.Places.Responses;

/// <summary>
/// Class representing a response from the Google Places API.
/// </summary>
public class PlacesResponse : HttpResponseBase {

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The underlying raw response the instance should be based on.</param>
    protected PlacesResponse(IHttpResponse response) : base(response) {

        // Skip error checking if the server responds with an OK status code
        if (response.StatusCode == HttpStatusCode.OK) return;

        JObject obj = ParseJsonObject(response.Body);

        JObject? error = obj.GetObject("error");

        int code = error.GetInt32("code");
        string? message = error.GetString("message");

        // TODO: Parse "errors"

        throw new PlacesHttpException(response, code, message!);

    }

    #endregion

}

/// <summary>
/// Class representing a response from the Google Places API.
/// </summary>
public class PlacesResponse<T> : PlacesResponse {

    /// <summary>
    /// Gets the body of the response.
    /// </summary>
    public T Body { get; protected set; } = default!;

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The underlying raw response the instance should be based on.</param>
    protected PlacesResponse(IHttpResponse response) : base(response) { }

}