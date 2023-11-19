using Microsoft.VisualBasic;
using Prism.Mvvm;
using Prism.Regions;
using Sandbox.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class MainWindowViewModel : BindableBase, IRegionMemberLifetime
    {
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager; 
        }

        private IEnumerable<UserMenuViewModel>? _menuList;
        public IEnumerable<UserMenuViewModel>? MenuList
        {
            get { return _menuList; }
            set { SetProperty(ref _menuList, value); }
        }

        public bool KeepAlive => throw new NotImplementedException();

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
            };

            MenuList = menu;
        }
    }
}
