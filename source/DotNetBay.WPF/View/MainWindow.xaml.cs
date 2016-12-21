using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.EF;
using DotNetBay.Data.Entity;
using DotNetBay.Interfaces;
using DotNetBay.WPF.ViewModel;
using Microsoft.Practices.Unity;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var container = new UnityContainer();
            container.RegisterType<IMemberService, SimpleMemberService>();
            container.RegisterType<IAuctioneer, Auctioneer>();
            container.RegisterType<IAuctionService, AuctionService>();
            container.RegisterType<IMainRepository, EFMainRepository>();

            DataContext = container.Resolve<MainViewModel>();
        }
    }
}
