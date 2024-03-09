using System;
using Skybrud.Social.Google.Places.Http;
using Skybrud.Social.Google.OAuth;

#pragma warning disable 1591

namespace Skybrud.Social.Google.Places {

    public static class PlacesExtensions {

        /// <summary>
        /// Returns the <see cref="PlacesHttpClient"/> of the specified Google OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The Google OAuth client.</param>
        /// <returns>An instance of <see cref="PlacesHttpClient"/>.</returns>
        /// <remarks>
        /// The <see cref="PlacesHttpClient"/> instance keeps an internal registry ensuring that calling this method
        /// multiple times for the same <paramref name="client"/> will result in the same instance of
        /// <see cref="PlacesHttpClient"/>.
        ///
        /// Specifically the <see cref="PlacesHttpClient"/> instance will be created the first time this method is
        /// called, while any subsequent calls to this method will result in the instance saved registry being
        /// returned.
        /// </remarks>
        public static PlacesHttpClient Places(this GoogleOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.GetHttpClient(() => new PlacesHttpClient(client));
        }

        /// <summary>
        /// Returns the <see cref="PlacesHttpService"/> instance of the specified Google <paramref name="service"/>.
        /// </summary>
        /// <param name="service">The Google service.</param>
        /// <returns>An instance of <see cref="PlacesHttpService"/>.</returns>
        /// <remarks>
        /// The <see cref="GoogleHttpService"/> instance keeps an internal registry ensuring that calling this method
        /// multiple times for the same <paramref name="service"/> will result in the same instance of
        /// <see cref="PlacesHttpService"/>.
        ///
        /// Specifically the <see cref="PlacesHttpService"/> instance will be created the first time this method is
        /// called, while any subsequent calls to this method will result in the instance saved registry being
        /// returned.
        /// </remarks>
        public static PlacesHttpService Places(this GoogleHttpService service) {
            if (service == null) throw new ArgumentNullException(nameof(service));
            return service.GetHttpService(() => new PlacesHttpService(service));
        }

    }

}