using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using DotNetBay.Data.Entity;
using System.Runtime.Serialization;

namespace DotNetBay.WebAPI.Models
{
    [DataContract]
    public class AuctionDto
    {
        public AuctionDto(Auction auction)
        {
            Id = auction.Id;
            StartPrice = auction.StartPrice;
            Title = auction.Title;
            Description = auction.Description;
            CurrentPrice = auction.CurrentPrice;
            StartDateTimeUtc = auction.StartDateTimeUtc;
            EndDateTimeUtc = auction.EndDateTimeUtc;
            CloseDateTimeUtc = auction.CloseDateTimeUtc;
            Seller = auction.Seller.Id;
            if (auction.Winner != null)
            {
                Winner = auction.Winner.Id;
            }
            Bids = auction.Bids.ToList().Select(bid => bid.Bidder.Id);
            if (auction.ActiveBid != null)
            {
                ActiveBid = auction.ActiveBid.Id;
            }
            IsRunning = auction.IsRunning;
            IsClosed = auction.IsClosed;
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public double StartPrice { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double CurrentPrice { get; set; }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        [DataMember]
        public DateTime StartDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        [DataMember]
        public DateTime EndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        [DataMember]
        public DateTime CloseDateTimeUtc { get; set; }

        [DataMember]
        public long Seller { get; set; }

        [DataMember]
        public long Winner { get; set; }

        [DataMember]
        public IEnumerable<long> Bids { get; set; }

        [DataMember]
        public long ActiveBid { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public bool IsRunning { get; set; }
    }
}