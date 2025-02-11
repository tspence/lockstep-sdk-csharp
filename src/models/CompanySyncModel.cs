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



#pragma warning disable CS8618

using System;

namespace LockstepSDK
{

    /// <summary>
    /// The CompanySyncModel represents information coming into Lockstep from an external financial system or other
    /// enterprise resource planning system.  To import data from an external system, convert your original data into
    /// the CompanySyncModel format and call the [Upload Sync File API](https://developer.lockstep.io/reference/post_api-v1-sync-zip).
    /// This API retrieves all of the data you uploaded in a compressed ZIP file and imports it into the Lockstep
    /// platform.
    ///
    /// Once imported, this record will be available in the Lockstep API as a [CompanyModel](https://developer.lockstep.io/docs/companymodel).
    ///
    /// For more information on writing your own connector, see [Connector Data](https://developer.lockstep.io/docs/connector-data).
    /// </summary>
    public class CompanySyncModel
    {

        /// <summary>
        /// This is the primary key of the Company record. For this field, you should use whatever the company&#39;s unique
        /// identifying number is in the originating system. Search for a unique, non-changing number within the
        /// originating financial system for this record.
        ///
        /// Example: If you store your company records in a database, whatever the primary key for the company table is
        /// in the database should be the `ErpKey`.
        ///
        /// Example: If you use a financial system such as Quickbooks or Xero, look for the primary ID number of the
        /// company record within that financial system.
        ///
        /// For more information, see [Identity Columns](https://developer.lockstep.io/docs/identity-columns).
        /// </summary>
        public string ErpKey { get; set; }

        /// <summary>
        /// A friendly, short name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// This field indicates the type of company. It can be one of a limited number of values: `Company`,
        /// `Customer`, `Group`, `Vendor`, or `Third Party`. A company that represents both a customer and a vendor is
        /// identified as a `CustomerVendor`.
        ///
        /// When loading data into Lockstep, you should focus on the distinction between a company that is part of
        /// your own enterprise, or a company that is external to your enterprise.
        ///
        /// For a company that is within your enterprise, you should set this value to be `Company`.
        ///
        /// For a company that is external to your enterprise, you should set this value to either `Customer`,
        /// `Vendor`, `Third Party`, or `CustomerVendor`.  If you don&#39;t know what value to choose, select
        /// `CustomerVendor`.
        /// </summary>
        public string CompanyType { get; set; }

        /// <summary>
        /// An optional field including status codes.  Defined status codes are `Active` and `Inactive`.
        /// </summary>
        public string CompanyStatus { get; set; }

        /// <summary>
        /// If this company has a parent company, identify the parent company&#39;s `ErpKey` value here. This value should
        /// be the original primary key or unique ID of the parent company to this company belongs. This value should
        /// match the original ErpKey field on the parent company.
        ///
        /// If this company is not a child company, leave this field null.
        /// </summary>
        public string ParentCompanyErpKey { get; set; }

        /// <summary>
        /// This flag indicates whether the company is currently active. An inactive company will be hidden from the
        /// user interface but will still be available for querying.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// The default currency code for transactions related to this company.  For a list of currency codes, see
        /// [Query Currencies](https://developer.lockstep.io/reference/get_api-v1-definitions-currencies). This will be validated by the /api/v1/definitions/currencies data set
        /// </summary>
        public string DefaultCurrencyCode { get; set; }

        /// <summary>
        /// The URL of this company&#39;s logo, if known.
        /// </summary>
        public string CompanyLogoUrl { get; set; }

        /// <summary>
        /// The `ErpKey` of the primary contact for this company.  This value should match the `ErpKey` value of the
        /// [Importing Contacts](https://developer.lockstep.io/docs/importing-contacts) record for the contact table.
        /// </summary>
        public string PrimaryContactErpKey { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string Address3 { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string StateRegion { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The company&#39;s primary mailing address information This will be validated by the /api/v1/definitions/countries data set
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The main phone number of this company.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The main fax number of this company.
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// If known, the date when this record was created according to the originating financial system
        /// in which this record is maintained.  If the originating financial system does not maintain a
        /// created-date, leave this field null.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// If known, the date when this record was most recently modified according to the originating
        /// financial system in which this record is maintained.  If the originating financial system does
        /// not maintain a most-recently-modified-date, leave this field null.
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// The company&#39;s Tax ID number for the appropriate government for this company.
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// The Dun and Bradstreet number for this company, if known.
        /// </summary>
        public string DunsNumber { get; set; }

        /// <summary>
        /// If you know the AP (accounts payable) email address of this company, fill it in here. This is the email
        /// address where you would send questions to the company if the company owed you money.
        /// </summary>
        public string ApEmailAddress { get; set; }

        /// <summary>
        /// If you know the AR (accounts receivable) email address of this company, fill it in here. This is the email
        /// address where you would send questions to the company if you owed this company money.
        /// </summary>
        public string ArEmailAddress { get; set; }
    }
}
