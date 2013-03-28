using System.Windows.Threading;

namespace Stashonizer.Application.ViewModels {
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Input;

    using Caliburn.Micro;

    using Stashonizer.Properties;

    using System.Net;
    using System.Collections.ObjectModel;
    using Stashonizer.Domain;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    /// <summary>
    /// The shell view model.
    /// </summary>
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase {

        private ObservableCollection<PoeItem> _stashItems = new ObservableCollection<PoeItem>();
        private ObservableCollection<Tab> _stashTabs = new ObservableCollection<Tab>();
        private PoeWebQuery _queryEngine;
        private List<PoeItem> _tempItemList = new List<PoeItem>();

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public ObservableCollection<PoeItem> StashItems {
            get {
                return _stashItems;
            }
            set { _stashItems = value; }
        }

        public ObservableCollection<Tab> StashTabs {
            get {
                return _stashTabs;
            }
        }

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager) {
            UserEmail = "User mail here";
            UserPassword = "User PW here";
            NotifyOfPropertyChange(() => UserEmail);
            NotifyOfPropertyChange(() => UserPassword);
        }

        public void LoadItems() {

            if (_queryEngine == null) {
                _queryEngine = new PoeWebQuery(UserEmail, UserPassword);
                _queryEngine.NewStashData += queryEngine_NewStashData;
            }

            if (_stashTabs.Count == 0) {
                FullReload();
            }
            else {
                StashItems.Clear();
                _stashTabs.Where(tab => tab.IsSelected).ToList().ForEach(tab => _queryEngine.EnqueGetStashItems(tab.i));
                _queryEngine.Execute();
            }
        }

        private void queryEngine_NewStashData(RequestObject data) {
            if (data.Response is PoeStash) {
                var stash = (PoeStash)data.Response;

                if (stash.items.Any()) {
                    foreach (var item in stash.items) {
                        if (!StashItems.Contains(item)) {
                            Execute.OnUIThread(() => StashItems.Add(item));
                        }
                    }

                    GemReference.Instance.SaveXml();
                    StashItems = new ObservableCollection<PoeItem>(StashItems.ToList().OrderBy(i => i.name));
                    NotifyOfPropertyChange(() => StashItems);
                }

                if (stash.tabs != null && stash.tabs.Any()) {
                    Execute.OnUIThread(() => StashTabs.Clear());

                    if (stash.tabs != null) {
                        foreach (var tab in stash.tabs) {
                            Execute.OnUIThread(() => _stashTabs.Add(tab));
                        }
                    }


                    NotifyOfPropertyChange(() => StashTabs);
                }
            }
        }

        private void FullReload() {
            _stashTabs.Clear();
            _stashItems.Clear();

            _queryEngine.EnqueGetStashItems(0, true);
            _queryEngine.Execute();

            NotifyOfPropertyChange(() => StashItems);
            NotifyOfPropertyChange(() => StashTabs);
        }

        public void CopyBBCodeToClipboard() {
            var sb = new StringBuilder();
            ItemType lastType = ItemType.Unknown;

            var noUniqueItems = StashItems.Where(item => item.rarity != ItemRarity.Unique).ToList();
            var allUniques = StashItems.Where(item => item.rarity == ItemRarity.Unique).OrderBy(item => item.name);
            #region gems
            var qgems = noUniqueItems.Where(item => item.itemType == ItemType.Gem && item.quality > 0)
                .OrderBy(item => item.gemDefinition.Type)
                .ThenBy(item => item.gemDefinition.Color)
                .ThenBy(item => item.name);

            var gems = noUniqueItems.Where(item => item.itemType == ItemType.Gem && item.quality == 0)
                .OrderBy(item => item.gemDefinition.Type)
                .ThenBy(item => item.gemDefinition.Color)
                .ThenBy(item => item.name);
            #endregion

            #region weapon
            var weapon1h = noUniqueItems.Where(item => item.itemType == ItemType.Weapon1h && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var weapon2h = noUniqueItems.Where(item => item.itemType == ItemType.Weapon2h && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var shields = noUniqueItems.Where(item => item.itemType == ItemType.Shield)
                .OrderBy(item => item.name);

            var bows = noUniqueItems.Where(item => item.itemType == ItemType.Bow && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var quiver = noUniqueItems.Where(item => item.itemType == ItemType.Quiver)
                .OrderBy(item => item.name);

            #endregion

            #region Armor
            var helmets = noUniqueItems.Where(item => item.itemType == ItemType.Helmet && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var boots = noUniqueItems.Where(item => item.itemType == ItemType.Boots && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var chests = noUniqueItems.Where(item => item.itemType == ItemType.Chest && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var gloves = noUniqueItems.Where(item => item.itemType == ItemType.Gloves && item.rarity == ItemRarity.Rare)
                .OrderBy(item => item.name);

            var belts = noUniqueItems.Where(item => item.itemType == ItemType.Belt)
                .OrderBy(item => item.name);

            var jewellery = noUniqueItems.Where(item => item.itemType == ItemType.Ring || item.itemType == ItemType.Amulet)
                .OrderBy(item => item.name);
            #endregion

            #region Armor 4L
            var helmets4L = noUniqueItems.Where(item => item.itemType == ItemType.Helmet && item.maxLink == 4)
                .OrderBy(item => item.name);

            var boots4L = noUniqueItems.Where(item => item.itemType == ItemType.Boots && item.maxLink == 4)
                .OrderBy(item => item.name);

            var chests4L = noUniqueItems.Where(item => item.itemType == ItemType.Chest && item.maxLink == 4)
                .OrderBy(item => item.name);

            var gloves4L = noUniqueItems.Where(item => item.itemType == ItemType.Gloves && item.maxLink == 4)
                .OrderBy(item => item.name);

            #endregion

            sb.Append(GetSpoiler("Uniques", allUniques));
            sb.Append(GetSpoiler("Quality Gems", qgems));
            sb.Append(GetSpoiler("Gems", gems));
            sb.Append("Weapons / Shields / Quiver[spoiler]");
            sb.Append(GetSpoiler("1H Weapon", weapon1h));
            sb.Append(GetSpoiler("2H Weapon", weapon2h));
            sb.Append(GetSpoiler("Shields", shields));
            sb.Append(GetSpoiler("Bows", bows));
            sb.Append(GetSpoiler("Quiver", quiver));
            sb.Append("[/spoiler]");
            sb.Append("Armor [spoiler]");
            sb.Append(GetSpoiler("Helmets", helmets));
            sb.Append(GetSpoiler("Boots", boots));
            sb.Append(GetSpoiler("Chest", chests));
            sb.Append(GetSpoiler("Gloves", gloves));
            sb.Append(GetSpoiler("Belts", belts));
            sb.Append("[/spoiler]");
            sb.Append(GetSpoiler("Jewellery", jewellery));
            sb.Append("4Link Items [spoiler]");
            sb.Append(GetSpoiler("Helmets", helmets4L));
            sb.Append(GetSpoiler("Boots", boots4L));
            sb.Append(GetSpoiler("Chest", chests4L));
            sb.Append(GetSpoiler("Gloves", gloves4L));
            sb.Append("[/spoiler]");


            Clipboard.SetText(sb.ToString());
        }

        private string GetSpoiler(string description, IOrderedEnumerable<PoeItem> items) {

            if (items.Any()) {
                var sb = new StringBuilder();
                sb.Append(description + "[spoiler]");

                foreach (var item in items) {
                    sb.Append(item.ToBBCode());
                }

                sb.Append("[/spoiler]" + System.Environment.NewLine);

                return sb.ToString();
            }

            return string.Empty;
        }

        #endregion
    }
}