/***
 * Lockstep Software Development Kit for C#
 *
 * (c) 2021-2022 Lockstep, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <tspence@lockstep.io>
 * @copyright  2021-2022 Lockstep, Inc.
 * @version    2022.2
 * @link       https://github.com/Lockstep-Network/lockstep-sdk-csharp
 */

namespace LockstepSDK;



using RestSharp;

public class InvoicesClient
{
    private readonly LockstepApi client;

    public InvoicesClient(LockstepApi client) {
        this.client = client;
    }

    /// <summary>
    /// Retrieves the Invoice specified by this unique identifier, optionally including nested data sets.
    /// 
    /// An Invoice represents a bill sent from one company to another.  The creator of the invoice is identified by the `CompanyId` field, and the recipient of the invoice is identified by the `CustomerId` field.  Most invoices are uniquely identified both by a Lockstep Platform ID number and a customer ERP "key" that was generated by the system that originated the invoice.  Invoices have a total amount and a due date, and when some payments have been made on the Invoice the `TotalAmount` and the `OutstandingBalanceAmount` may be different.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of this invoice; NOT the customer's ERP key</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Addresses, Lines, Payments, Notes, Attachments, Company, Customer, CustomFields, CreditMemos</param>
    public async Task<LockstepResponse<InvoiceModel>> RetrieveInvoice(Guid? id, string? include)
    {
        var url = $"/api/v1/Invoices/{id}";
        var options = new Dictionary<string, object?>();
        options["include"] = include;
        return await this.client.Request<InvoiceModel>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Updates an existing Invoice with the information supplied to this PATCH call.
    /// 
    /// The PATCH method allows you to change specific values on the object while leaving other values alone.  As input you should supply a list of field names and new values.  If you do not provide the name of a field, that field will remain unchanged.  This allows you to ensure that you are only updating the specific fields desired.  An Invoice represents a bill sent from one company to another.  The creator of the invoice is identified by the `CompanyId` field, and the recipient of the invoice is identified by the `CustomerId` field.  Most invoices are uniquely identified both by a Lockstep Platform ID number and a customer ERP "key" that was generated by the system that originated the invoice.  Invoices have a total amount and a due date, and when some payments have been made on the Invoice the `TotalAmount` and the `OutstandingBalanceAmount` may be different.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of the invoice to update; NOT the customer's ERP key</param>
    /// <param name="body">A list of changes to apply to this Invoice</param>
    public async Task<LockstepResponse<InvoiceModel>> UpdateInvoice(Guid? id, object? body)
    {
        var url = $"/api/v1/Invoices/{id}";
        return await this.client.Request<InvoiceModel>(Method.PATCH, url, null, body);
    }

    /// <summary>
    /// Deletes the Invoice referred to by this unique identifier. An Invoice represents a bill sent from one company to another.  The creator of the invoice is identified by the `CompanyId` field, and the recipient of the invoice is identified by the `CustomerId` field.  Most invoices are uniquely identified both by a Lockstep Platform ID number and a customer ERP "key" that was generated by the system that originated the invoice.  Invoices have a total amount and a due date, and when some payments have been made on the Invoice the `TotalAmount` and the `OutstandingBalanceAmount` may be different.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of the invoice to delete; NOT the customer's ERP key</param>
    public async Task<LockstepResponse<ActionResultModel>> DeleteInvoice(Guid? id)
    {
        var url = $"/api/v1/Invoices/{id}";
        return await this.client.Request<ActionResultModel>(Method.DELETE, url, null, null);
    }

    /// <summary>
    /// Creates one or more Invoices within this account and returns the records as created.
    /// 
    /// An Invoice represents a bill sent from one company to another.  The creator of the invoice is identified by the `CompanyId` field, and the recipient of the invoice is identified by the `CustomerId` field.  Most invoices are uniquely identified both by a Lockstep Platform ID number and a customer ERP "key" that was generated by the system that originated the invoice.  Invoices have a total amount and a due date, and when some payments have been made on the Invoice the `TotalAmount` and the `OutstandingBalanceAmount` may be different.
    /// 
    /// </summary>
    /// <param name="body">The Invoices to create</param>
    public async Task<LockstepResponse<InvoiceModel[]>> CreateInvoices(InvoiceModel[]? body)
    {
        var url = $"/api/v1/Invoices";
        return await this.client.Request<InvoiceModel[]>(Method.POST, url, null, body);
    }

    /// <summary>
    /// Queries Invoices for this account using the specified filtering, sorting, nested fetch, and pagination rules requested.
    /// 
    /// More information on querying can be found on the [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight) page on the Lockstep Developer website.  An Invoice represents a bill sent from one company to another.  The creator of the invoice is identified by the `CompanyId` field, and the recipient of the invoice is identified by the `CustomerId` field.  Most invoices are uniquely identified both by a Lockstep Platform ID number and a customer ERP "key" that was generated by the system that originated the invoice.  Invoices have a total amount and a due date, and when some payments have been made on the Invoice the `TotalAmount` and the `OutstandingBalanceAmount` may be different.
    /// 
    /// </summary>
    /// <param name="filter">The filter for this query. See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Addresses, Lines, Payments, Notes, Attachments, Company, Customer, CustomFields, CreditMemos</param>
    /// <param name="order">The sort order for this query. See See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageSize">The page size for results (default 200). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageNumber">The page number for results (default 0). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    public async Task<LockstepResponse<FetchResult<InvoiceModel>>> QueryInvoices(string? filter, string? include, string? order, int? pageSize, int? pageNumber)
    {
        var url = $"/api/v1/Invoices/query";
        var options = new Dictionary<string, object?>();
        options["filter"] = filter;
        options["include"] = include;
        options["order"] = order;
        options["pageSize"] = pageSize;
        options["pageNumber"] = pageNumber;
        return await this.client.Request<FetchResult<InvoiceModel>>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Queries Invoices for this account using the specified filtering, sorting, nested fetch, and pagination rules requested.  Display the results using the Invoice Summary View format.
    /// 
    /// More information on querying can be found on the [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight) page on the Lockstep Developer website.
    /// 
    /// The Invoice Summary View represents a slightly different view of the data and includes some extra fields that might be useful.  For more information, see the data format of the Invoice Summary Model.
    /// 
    /// </summary>
    /// <param name="filter">The filter for this query. See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. No collections are currently available but may be offered in the future</param>
    /// <param name="order">The sort order for this query. See See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageSize">The page size for results (default 200). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageNumber">The page number for results (default 0). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    public async Task<LockstepResponse<FetchResult<InvoiceSummaryModel>>> QueryInvoiceSummaryView(string? filter, string? include, string? order, int? pageSize, int? pageNumber)
    {
        var url = $"/api/v1/Invoices/views/summary";
        var options = new Dictionary<string, object?>();
        options["filter"] = filter;
        options["include"] = include;
        options["order"] = order;
        options["pageSize"] = pageSize;
        options["pageNumber"] = pageNumber;
        return await this.client.Request<FetchResult<InvoiceSummaryModel>>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Queries At Risk Invoices for this account using the specified filtering, sorting, nested fetch, and pagination rules requested.  Display the results using the At Risk Invoice Summary View format.
    /// 
    /// More information on querying can be found on the [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight) page on the Lockstep Developer website.
    /// 
    /// The At Risk Invoice Summary View represents a slightly different view of the data and includes some extra fields that might be useful.  For more information, see the data format of the At Risk Invoice Summary Model.
    /// 
    /// </summary>
    /// <param name="filter">The filter for this query. See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. No collections are currently available but may be offered in the future</param>
    /// <param name="order">The sort order for this query. See See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageSize">The page size for results (default 200). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageNumber">The page number for results (default 0). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    public async Task<LockstepResponse<FetchResult<AtRiskInvoiceSummaryModel>>> QueryAtRiskInvoiceSummaryView(string? filter, string? include, string? order, int? pageSize, int? pageNumber)
    {
        var url = $"/api/v1/Invoices/views/at-risk-summary";
        var options = new Dictionary<string, object?>();
        options["filter"] = filter;
        options["include"] = include;
        options["order"] = order;
        options["pageSize"] = pageSize;
        options["pageNumber"] = pageNumber;
        return await this.client.Request<FetchResult<AtRiskInvoiceSummaryModel>>(Method.GET, url, options, null);
    }
}
