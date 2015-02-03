// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadCareAPI.cs" company="CoMetrics">
//   Copyright 2014 CoMetrics
// </copyright>
// <summary>
//   TODO: Fill out the description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UploadCareAPI
{
    using System;

    using RestSharp;
    using RestSharp.Validation;

    /// <summary>
    /// TODO: Fill out the description.
    /// </summary>
    /// 


    public class Call
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class UploadCareAPI
    {
        #region Fields (Private)

        const string BaseUrl = "https://api.uploadcare.com/";

        private const string FilesUrl = BaseUrl + "files/";

        readonly string _accountSid;
        readonly string _secretKey;

        #endregion

        #region Constructors

        public UploadCareAPI(string accountSid, string secretKey)
        {
            this._accountSid = accountSid;
            this._secretKey = secretKey;
        }

        #endregion

        #region Properties

        public bool AutoRotate { get; set; } // autorotate/yes/

        public bool MoveToS3 { get; set; }

        #endregion

        #region Public Methods

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(FilesUrl); // https://api.uploadcare.com/files/
            client.Authenticator = new HttpBasicAuthenticator(this._accountSid, this._secretKey);
            request.AddHeader("Accept", "application/vnd.uploadcare-v0.3+json");
            request.AddHeader("Date", DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss zzzz"));
            request.AddHeader(
                "Authorization",
                string.Format("Uploadcare.Simple {0}:{1}", this._accountSid, this._secretKey));

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        public void SaveToStorage()
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("source", "cbd3a0bf-97da-45ab-b9d3-17800b4ac039");
            request.AddParameter("store", "true");

            Execute<int>(request);



        }

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
