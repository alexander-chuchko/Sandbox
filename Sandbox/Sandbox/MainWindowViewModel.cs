using Microsoft.VisualBasic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Sandbox.Models.Menu;
using Sandbox.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sandbox
{
    public class MainWindowViewModel : BindableBase, IRegionMemberLifetime
    {
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager; 
        }

        private UserMenuViewModel? _selectedParagraph;
        public UserMenuViewModel? SelectedParagraph
        {
            get { return _selectedParagraph; }
            set { SetProperty(ref _selectedParagraph, value); }
        }

        private IEnumerable<UserMenuViewModel>? _menuList;
        public IEnumerable<UserMenuViewModel>? MenuList
        {
            get { return _menuList; }
            set { SetProperty(ref _menuList, value); }
        }

        public bool KeepAlive => true;

        private ICommand _NavigateMainToPageCommand;
        public ICommand NavigateMainPageToCommand => _NavigateMainToPageCommand ?? (_NavigateMainToPageCommand = new DelegateCommand(OnNavigateToMainPage));


        public void OnNavigateToMainPage()
        {
            CreatingMenuItems();

            _regionManager.RequestNavigate("ContentRegion", (nameof(MainPage)));
        }
        private void CreatingMenuItems()
        {
            var menu = new List<UserMenuViewModel>()
            {
              new UserMenuViewModel()
              {
                  Name = Constants.MAIN_ITEM,
                  TextBackground = "#f8f5f5",
                  TextForeground = "#ff4064",
                  ImageSource = "/Images/home_light.png"
              },
              new UserMenuViewModel()
              {
                  Name = Constants.DETAILS_ITEM,
                  TextBackground =  Color.Transparent.ToString(),
                  TextForeground = "#596EFB",
                  ImageSource = "/Images/info_light.png"
              },
              new UserMenuViewModel()
              {
                  Name = Constants.SETTINGS_ITEM,
                  TextBackground =  Color.Transparent.ToString(),
                  TextForeground = "#596EFB",
                  ImageSource = "/Images/settings_light.png"
              },
              new UserMenuViewModel()
              {
                  Name= Constants.LANGUAGE_ITEM,
                  TextBackground= Color.Transparent.ToString(),
                  TextForeground="#596EFB",
              }
            };

            MenuList = menu;
        }
    }
}
