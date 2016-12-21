using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.View;
using Microsoft.Practices.Unity;

namespace DotNetBay.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuctioneer auctioneer;

        private readonly IAuctionService auctionService;

        private ObservableCollection<AuctionViewModel> auctions = new ObservableCollection<AuctionViewModel>();

        private readonly IUnityContainer _container;

        public MainViewModel(IUnityContainer container, IAuctioneer auctioneer, IAuctionService auctionService)
        {
            _container = container;

            this.auctioneer = auctioneer;
            this.auctionService = auctionService;

            this.AddNewAuctionCommand = new RelayCommand(this.AddNewAuctionAction);

            // Register for Events
            this.auctioneer.AuctionEnded += (sender, args) => { this.ApplyChanges(args.Auction); };
            this.auctioneer.AuctionStarted += (sender, args) => { this.ApplyChanges(args.Auction); };
            this.auctioneer.BidAccepted += (sender, args) => { this.ApplyChanges(args.Auction); };
            this.auctioneer.BidDeclined += (sender, args) => { this.ApplyChanges(args.Auction); };

            // Setup UI
            var allAuctions = this.auctionService.GetAll();
            foreach (var auction in allAuctions)
            {
                var auctionVm = _container.Resolve<AuctionViewModel>(new ParameterOverride("auction", auction));
                this.auctions.Add(auctionVm);
            }
        }

        public ObservableCollection<AuctionViewModel> Auctions
        {
            get
            {
                return this.auctions;
            }
        }

        public ICommand AddNewAuctionCommand { get; private set; }

        private void AddNewAuctionAction()
        {
            var sellView = _container.Resolve<SellView>();
            sellView.ShowDialog(); // Blocking

            // Find & add new auction
            var allAuctions = this.auctionService.GetAll().ToList();
            var newAuctions = allAuctions.Where(a => this.auctions.All(vm => vm.Auction != a));

            foreach (var auction in newAuctions)
            {
                var auctionVm = _container.Resolve<AuctionViewModel>(new ParameterOverride("auction", auction));
                this.auctions.Add(auctionVm);
            }
        }

        private void ApplyChanges(Auction auction)
        {
            var auctionVm = this.auctions.FirstOrDefault(vm => vm.Auction == auction);

            if (auctionVm != null)
            {
                auctionVm.Update(auction);
            }
        }
    }
}
