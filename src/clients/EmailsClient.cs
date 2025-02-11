/***
 * Lockstep Platform SDK for C#
 *
 * (c) 2021-2022 Lockstep, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Lockstep Network <support@lockstep.io>
 * @copyright  2021-2022 Lockstep, Inc.
 * @link       https://github.com/Lockstep-Network/lockstep-sdk-csharp
 */



using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace LockstepSDK
{
    /// <summary>
    /// API methods related to Emails
    /// </summary>
    public class EmailsClient
    {
        private readonly LockstepApi _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public EmailsClient(LockstepApi client) {
            _client = client;
        }

        /// <summary>
        /// Retrieves the email with the specified email identifier.
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="id">The unique ID number of the Email to retrieve.</param>
        /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Attachments, CustomFields, Notes, ResponseOrigin</param>
        public async Task<LockstepResponse<EmailModel>> RetrieveEmail(Guid id, string include = null)
        {
            var url = $"/api/v1/Emails/{id}";
            var options = new Dictionary<string, object>();
            if (include != null) { options["include"] = include; }
            return await _client.Request<EmailModel>(HttpMethod.Get, url, options, null, null);
        }

        /// <summary>
        /// Updates an existing Email with the information supplied to this PATCH call.
        ///
        /// The PATCH method allows you to change specific values on the object while leaving other values alone.  As input you should supply a list of field names and new values.  If you do not provide the name of a field, that field will remain unchanged.  This allows you to ensure that you are only updating the specific fields desired.
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="id">The unique Lockstep Platform ID number of the email to update</param>
        /// <param name="body">A list of changes to apply to this Email</param>
        public async Task<LockstepResponse<EmailModel>> UpdateEmail(Guid id, object body)
        {
            var url = $"/api/v1/Emails/{id}";
            return await _client.Request<EmailModel>(new HttpMethod("PATCH"), url, null, body, null);
        }

        /// <summary>
        /// Deletes the Email referred to by this unique identifier.
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="id">The unique Lockstep Platform ID number of the Email to delete</param>
        public async Task<LockstepResponse<ActionResultModel>> DeleteEmail(Guid id)
        {
            var url = $"/api/v1/Emails/{id}";
            return await _client.Request<ActionResultModel>(HttpMethod.Delete, url, null, null, null);
        }

        /// <summary>
        /// Retrieves a signature logo for the email with the specified identifier and increments &#39;ViewCount&#39;.
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="emailId">The unique ID number of the Email to retrieve.</param>
        /// <param name="nonce">The random nonce applied at time of url creation.</param>
        public async Task<LockstepResponse<string>> RetrieveEmailLogo(Guid emailId, Guid nonce)
        {
            var url = $"/api/v1/Emails/{emailId}/logo/{nonce}";
            return await _client.Request<string>(HttpMethod.Get, url, null, null, null);
        }

        /// <summary>
        /// Creates one or more emails from the specified array of Email Models
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="body">The array of emails to be created</param>
        public async Task<LockstepResponse<EmailModel[]>> CreateEmails(EmailModel[] body)
        {
            var url = $"/api/v1/Emails";
            return await _client.Request<EmailModel[]>(HttpMethod.Post, url, null, body, null);
        }

        /// <summary>
        /// Queries Emails on the Lockstep Platform using the specified filtering, sorting, nested fetch, and pagination rules requested.
        ///
        /// More information on querying can be found on the [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight) page on the Lockstep Developer website.
        ///
        /// An Email represents a communication sent from one company to another.  The creator of the email is identified by the `CompanyId` field, recipient(s) by the `EmailTo` field, and cc recipient(s) by the &#39;EmailCC&#39; field. The Email Model represents an email and a number of different metadata attributes related to the creation, storage, and ownership of the email.
        ///
        /// </summary>
        /// <param name="filter">The filter to use to select from the list of available applications, in the [Searchlight query syntax](https://github.com/tspence/csharp-searchlight).</param>
        /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Attachments, CustomFields, Notes, ResponseOrigin</param>
        /// <param name="order">The sort order for the results, in the [Searchlight order syntax](https://github.com/tspence/csharp-searchlight).</param>
        /// <param name="pageSize">The page size for results (default 200). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
        /// <param name="pageNumber">The page number for results (default 0). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
        public async Task<LockstepResponse<FetchResult<EmailModel>>> QueryEmails(string filter = null, string include = null, string order = null, int? pageSize = null, int? pageNumber = null)
        {
            var url = $"/api/v1/Emails/query";
            var options = new Dictionary<string, object>();
            if (filter != null) { options["filter"] = filter; }
            if (include != null) { options["include"] = include; }
            if (order != null) { options["order"] = order; }
            if (pageSize != null) { options["pageSize"] = pageSize; }
            if (pageNumber != null) { options["pageNumber"] = pageNumber; }
            return await _client.Request<FetchResult<EmailModel>>(HttpMethod.Get, url, options, null, null);
        }
    }
}
