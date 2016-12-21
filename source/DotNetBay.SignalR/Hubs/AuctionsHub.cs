using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetBay.Data.Entity;
using Microsoft.AspNet.SignalR;

namespace DotNetBay.SignalR.Hubs
{
    public class AuctionsHub : Hub
    {
        public static void NotifyNewAuction(Auction auction) { }

        public static void NotifyBidAccepted(Auction auction, Bid bid) { }

        public static void NotifyAuctionStarted(Auction auction) { }

        public static void NotifyAuctionEnded(Auction auction) { }
    }
}