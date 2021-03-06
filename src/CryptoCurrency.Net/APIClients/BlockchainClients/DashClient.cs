﻿using CryptoCurrency.Net.APIClients.BlockchainClients;
using CryptoCurrency.Net.Model;
using RestClientDotNet;
// ReSharper disable UnusedMember.Global

namespace CryptoCurrency.Net.APIClients
{
    public class DashClient : InsightClientBase, IBlockchainClient
    {
        #region Constructor
        public DashClient(CurrencySymbol currency, IRestClientFactory restClientFactory) : base(currency, restClientFactory)
        {
        }
        #endregion

        #region Private Static Fields
        public static CurrencyCapabilityCollection CurrencyCapabilities { get; } = new CurrencyCapabilityCollection { CurrencySymbol.Dash };
        #endregion

        #region Protected Overrides
        /// <summary>
        /// Example: https://api.dash.org/insight-api/addr/[Address]
        /// </summary>
        protected override string BaseUriPath => "https://api.dash.org";
        #endregion
    }
}
