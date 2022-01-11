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

public class CurrenciesClient
{
    private readonly LockstepApi client;

    public CurrenciesClient(LockstepApi client) {
        this.client = client;
    }

    /// <summary>
    /// Retrieve a currency conversation rate from one currency to another as of the specified date.              Optionally, you can specify which currency data provider to use.
    /// 
    ///              The currency rate model contains all of the information used to make the API call, plus the rate to              use for the conversion.
    /// 
    /// </summary>
    /// <param name="sourceCurrency">The ISO 4217 currency code of the origin currency. For a list of currency codes, call List Currencies.</param>
    /// <param name="destinationCurrency">The ISO 4217 currency code of the target currency. For a list of currency codes, call List Currencies.</param>
    /// <param name="date">The date for which we should cto use for this currency conversion.</param>
    /// <param name="dataProvider">Optionally, you can specify a data provider.</param>
    public async Task<LockstepResponse<CurrencyRateModel>> Retrievecurrencyrate(string? sourceCurrency, string? destinationCurrency, DateTime? date, string? dataProvider)
    {
        var url = $"/api/v1/Currencies/{sourceCurrency}/{destinationCurrency}";
        var options = new Dictionary<string, object?>();
        options["date"] = date;
        options["dataProvider"] = dataProvider;
        return await this.client.Request<CurrencyRateModel>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Receives an array of dates and currencies and a destination currency and returns an array of the corresponding currency rates to the given destination currency (Limit X).
    /// 
    /// </summary>
    /// <param name="destinationCurrency">The currency to convert to.</param>
    /// <param name="body">A list of dates and source currencies.</param>
    public async Task<LockstepResponse<CurrencyRateModel[]>> Bulkcurrencydata(string? destinationCurrency, BulkCurrencyConversionModel[]? body)
    {
        var url = $"/api/v1/Currencies/bulk";
        var options = new Dictionary<string, object?>();
        options["destinationCurrency"] = destinationCurrency;
        return await this.client.Request<CurrencyRateModel[]>(Method.POST, url, options, body);
    }
}
