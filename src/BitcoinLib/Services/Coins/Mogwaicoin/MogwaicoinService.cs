using BitcoinLib.CoinParameters.Mogwaicoin;
using BitcoinLib.RPC.Specifications;

namespace BitcoinLib.Services.Coins.Mogwaicoin
{
    public class MogwaicoinService : CoinService, IMogwaicoinService
    {
        public MogwaicoinService(bool useTestnet = false) : base(useTestnet)
        {
        }

        public MogwaicoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword)
        {
        }

        public MogwaicoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword,
            short rpcRequestTimeoutInSeconds)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds)
        {
        }

        /// <inheritdoc />
        public string SendToAddress(string mogwaiAddress, decimal amount, string comment = null, string commentTo = null,
            bool subtractFeeFromAmount = false, bool useInstantSend = false, bool usePrivateSend = false)
        {
            return _rpcConnector.MakeRequest<string>(RpcMethods.sendtoaddress, mogwaiAddress, amount, comment, commentTo,
                subtractFeeFromAmount, useInstantSend, usePrivateSend);
        }

        public MirrorAddressResponse MirrorAddress(string mogwaiAddress)
        {
            return _rpcConnector.MakeRequest<MirrorAddressResponse>(RpcMethods.mirroraddress, mogwaiAddress);
        }

        public MogwaicoinConstants.Constants Constants => MogwaicoinConstants.Constants.Instance;
    }

    public class MirrorAddressResponse
    {
        public bool IsValid { get; set; }
        public string Address { get; set; }
        public bool IsMine { get; set; }
        public bool IsScript { get; set; }
        public string PubKey { get; set; }
        public bool IsCompressed { get; set; }
        public string MirKey { get; set; }
        public bool MirKeyValid { get; set; }
        public bool IsMirAddrValid { get; set; }
        public string MirAddress { get; set; }
    }
}