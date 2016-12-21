using System;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        public BidView(Auction selectedAuction, IMemberService memberService, IAuctionService auctionService)
        {
            this.InitializeComponent();

            var app = Application.Current as App;

            this.DataContext = new BidViewModel(selectedAuction, memberService, auctionService);

        }
    }
}
