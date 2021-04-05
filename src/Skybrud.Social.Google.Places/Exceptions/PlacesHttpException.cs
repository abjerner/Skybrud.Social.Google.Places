using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Skybrud.Social.Google.Places.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Google Places API.
    /// </summary>
    public class PlacesHttpException : Exception, IHttpException {

        #region Properties

        /// <inheritdoc />
        public IHttpResponse Response { get; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public int Code { get; }

        #endregion

        #region Constructors

        internal PlacesHttpException(IHttpResponse response, int code, string message) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}