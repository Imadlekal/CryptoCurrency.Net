﻿using CryptoCurrency.Net.APIClients.BlockchainClients;
using CryptoCurrency.Net.Model;
using RestClientDotNet;

namespace CryptoCurrency.Net.APIClients
{

    /// <summary>
    /// TODO: Decommissioned because we can't be sure that it is not returning null for real addresses
    /// </summary>
    public class GastrackerJSONRPCClient : JSONRPCClientBase, IBlockchainClient
    {
        #region Private Static Fields
        public static CurrencyCapabilityCollection CurrencyCapabilities { get; } = new CurrencyCapabilityCollection { CurrencySymbol.EthereumClassic };
        #endregion

        #region Public Properties
        protected override string BaseUriPath => "https://web3.gastracker.io/";
        #endregion

        #region Constructor
        public GastrackerJSONRPCClient(CurrencySymbol currency, IRestClientFactory restClientFactory) : base(currency, restClientFactory)
        {
        }
        #endregion
    }
}
