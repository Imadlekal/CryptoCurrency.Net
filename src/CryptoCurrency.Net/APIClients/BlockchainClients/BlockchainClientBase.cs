﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCurrency.Net.APIClients.BlockchainClients.CallArguments;
using CryptoCurrency.Net.Model;
using RestClientDotNet;

namespace CryptoCurrency.Net.APIClients.BlockchainClients
{
    public abstract class BlockchainClientBase : APIClientBase
    {
        #region Protected Fields
        public const string LogSection = "Blockchain Clients";
        protected CurrencySymbol Currency;
        #endregion

        #region Protected Virtual Fields
        protected virtual Func<GetAddressesArgs, Task<IEnumerable<BlockChainAddressInformation>>> GetAddressesFunc { get; } = async getAddressesArgs =>
        {
            var retVal = new List<BlockChainAddressInformation>();

            foreach (var address in getAddressesArgs.Addresses)
            {
                var blockChainAddressInformation = await getAddressesArgs.Client.GetAddress(address);
                retVal.Add(blockChainAddressInformation);
            }

            return retVal;
        };
        #endregion

        #region Constructor
        protected BlockchainClientBase(CurrencySymbol currency, IRestClientFactory restClientFactory) : base(restClientFactory)
        {
            Currency = currency;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This is a bit iffy that it's virtual. If we can get multiple addresses we should use the multiple address method, but this could also be an issue for new clients if we forget to fill in either method
        /// </summary>
        public virtual Task<BlockChainAddressInformation> GetAddress(string address)
        {
            return null;
        }

        public async Task<IEnumerable<BlockChainAddressInformation>> GetAddresses(IEnumerable<string> addresses)
        {
            var startTime = DateTime.Now;

            var addressList = addresses.ToList();
            var retVal = await Call<IEnumerable<BlockChainAddressInformation>>(GetAddressesFunc, new GetAddressesArgs(RESTClient, addressList, Currency, this));

            Logger.Log($"Got {addressList.ToList().Count} {Currency.Name} addresses. Client {GetType().Name}. Milliseconds: {(DateTime.Now - startTime).TotalMilliseconds}", null, nameof(BlockchainClientBase));

            return retVal;
        }
        #endregion
    }
}
