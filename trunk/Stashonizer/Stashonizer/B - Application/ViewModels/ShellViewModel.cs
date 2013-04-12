using System;
using System.ComponentModel;
using System.Dynamic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace Stashonizer.Application.ViewModels {
    using System.ComponentModel.Composition;
    using System.Windows;
    using Caliburn.Micro;
    using System.Collections.ObjectModel;
    using Domain;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    /// <summary>
    /// The shell view model.
    /// </summary>
    [Export(typeof(IShellModel))]
    public class ShellViewModel : Screen {

        private ObservableCollection<PoeItem> _stashItems = new ObservableCollection<PoeItem>();
        private ObservableCollection<Tab> _stashTabs = new ObservableCollection<Tab>();
        private ObservableCollection<CharacterInfo> _characters = new ObservableCollection<CharacterInfo>();
        private string _selectedLeague;
        private PoeWebQuery _queryEngine;

        private IWindowManager _windowManager;
        private ItemPopupViewModel _itemPopup;

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public string StatusText { get; set; }
        public SolidColorBrush StatusTextColor { get; set; }

        public List<string> LeagueNames {
            get { return new List<string> { "Hardcore", "Default" }; }
        }

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

        public ObservableCollection<CharacterInfo> Characters {
            get {
                return _characters;
            }
        }

        public bool IsLoginRequired { get; set; }

        public bool IsLoggedIn { get; set; }

        public string SelectedLeague {
            get {
                return _selectedLeague;
            }
            set {
                _selectedLeague = value;
                if (_queryEngine != null) {
                    _queryEngine.SetLeague(value);
                    IsLoginRequired = !_queryEngine.IsCacheEmpty();
                }
                SetBasicLayoutFromCache();
                NotifyOfPropertyChange(() => SelectedLeague);
            }
        }

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager) {
            _windowManager = windowManager;

            DisplayName = "Stashonizer";
            _selectedLeague = "Hardcore";

            _queryEngine = new PoeWebQuery();
            _queryEngine.NewData += QueryEngineNewData;
            _queryEngine.WorkFinished += QueryEngineWorkFinished;
            _queryEngine.ParsingError += QueryEngineOnParsingError;

            IsLoginRequired = !_queryEngine.IsCacheEmpty();
            SetBasicLayoutFromCache();
        }

        #endregion

        private void QueryEngineOnParsingError() {
            SetStatus("Internal Parsing Error", true);
        }

        public void LoadItems() {
            if (_stashTabs.Count == 0) {
                SetStatus("Loading Stash-Layout...");
                _stashItems.Clear();
                _queryEngine.EnqueGetStashItems(0, true);
                _queryEngine.EnqueGetCharacters();
            }
            else {
                StashItems.Clear();
                _stashTabs.Where(tab => tab.IsSelected).ToList().ForEach(tab => _queryEngine.EnqueGetStashItems(tab.i));
                _characters.Where(c => c.IsSelected).ToList().ForEach(c => _queryEngine.EnqueGetCharacterItems(c));
            }

            PerformRequests();
        }

        public void PerformRequests() {
            if (!IsLoggedIn && _queryEngine.IsLoginRequiredForCurrentQueue()) {
                IsLoggedIn = Login();
                if (!IsLoggedIn) {
                    SetStatus("Login failed", true);
                    _queryEngine.EmptyQueue();
                    return;
                }
            }
            _queryEngine.Execute();
        }

        public void SetBasicLayoutFromCache() {
            var stash = _queryEngine.GetStashFromCache();
            IEnumerable<Tab> tabs = null;
            tabs = stash == null ? new List<Tab>() : stash.tabs;
            SetBasicTabLayout(tabs);
            var chars = _queryEngine.GetCharactersFromCache();
            SetBasicCharLayout(chars);
        }

        private void SetBasicTabLayout(IEnumerable<Tab> tabs) {
            _stashTabs.Clear();

            if (tabs != null && tabs.Any()) {
                _stashTabs = new ObservableCollection<Tab>(tabs);
            }

            NotifyOfPropertyChange(() => StashTabs);
        }

        private void SetBasicCharLayout(IEnumerable<CharacterInfo> chars) {
            _characters.Clear();

            if (chars != null && chars.Any()) {
                _characters = new ObservableCollection<CharacterInfo>(chars.Where(c => c.league.ToUpper() == SelectedLeague.ToUpper()).OrderBy(c => c.Name));
            }

            NotifyOfPropertyChange(() => Characters);
        }

        public void SearchItems(object sender, RoutedEventArgs e) {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(StashItems);
            var searchPhrase = sender.ToString().ToUpper();

            if (String.IsNullOrEmpty(searchPhrase))
                collectionView.Filter = null;

            else {
                collectionView.Filter = o => {
                    var item = (PoeItem)o;

                    bool result =
                        item.name.ToUpper().Contains(searchPhrase) ||
                        item.itemType.ToString().ToUpper().Contains(searchPhrase);

                    return result;
                };
            }

        }

        private bool Login() {
            var login = new LoginViewModel();
            var result = _windowManager.ShowDialog(login);
            var loginResult = false;
            if (result.HasValue && result.Value) {
                loginResult = _queryEngine.Login(login.View.UserAccount, login.View.UserPassword);
                login.View.UserPassword = string.Empty;
                login.View.UserPassword = string.Empty;
            }

            return loginResult;
        }

        private void SetStatus(string text, bool isError = false) {
            StatusText = text;
            StatusTextColor = isError ? Brushes.Red : Brushes.Black;

            NotifyOfPropertyChange(() => StatusText);
            NotifyOfPropertyChange(() => StatusTextColor);
        }

        private void QueryEngineNewData(RequestObject data) {
            if (data.Response is PoeStash) {
                HandleNewStashData(data);
            }
            else if (data.Response is IEnumerable<CharacterInfo>) {
                HandleCharacterInfo(data);
            }
            else if (data.Response is CharacterInventory) {
                HandleCharacterInventory(data);
            }
        }

        private void HandleCharacterInventory(RequestObject data) {
            var inventory = (CharacterInventory)data.Response;

            // Select only items that are in the inventory of the character, do not add equipped items
            var mainInventoryItems = inventory.items.Where(item => item.inventoryId == "MainInventory").ToList();

            if (mainInventoryItems.Any()) {
                foreach (var item in mainInventoryItems) {
                    AddItemToStash(item);
                }
                NotifyOfPropertyChange(() => StashItems);
            }
        }

        /// <summary>
        /// Thread Save add item to stashlist if not already exists
        /// </summary>
        /// <param name="item">the item</param>
        private void AddItemToStash(PoeItem item) {
            if (!StashItems.Contains(item)) {
                Execute.OnUIThread(() => StashItems.Add(item));
            }
        }

        private void HandleCharacterInfo(RequestObject data) {
            var chars = data.Response as IEnumerable<CharacterInfo>;
            Execute.OnUIThread(() => SetBasicCharLayout(chars));
            NotifyOfPropertyChange(() => Characters);
        }

        public void ClearCache() {
            _queryEngine.ClearCache();
            StashItems.Clear();
            Characters.Clear();
            StashTabs.Clear();
            IsLoggedIn = false;
            IsLoginRequired = true;

            NotifyOfPropertyChange(() => StashItems);
            NotifyOfPropertyChange(() => Characters);
            NotifyOfPropertyChange(() => StashTabs);
        }

        private void HandleNewStashData(RequestObject data) {
            var stash = (PoeStash)data.Response;

            if (stash.tabs != null && stash.tabs.Any()) {
                Execute.OnUIThread(() => SetBasicTabLayout(stash.tabs));
            }
            else if (stash.items.Any()) {
                foreach (var item in stash.items) {
                    AddItemToStash(item);
                }

                GemReference.Instance.SaveXml();
                StashItems = new ObservableCollection<PoeItem>(StashItems.ToList().OrderBy(i => i.name));
                NotifyOfPropertyChange(() => StashItems);
            }
        }

        private void QueryEngineWorkFinished() {
            SetStatus("Done");
        }


        public void ShowItemPopup(PoeItem item, object sender) {
            if (_itemPopup == null) {
                _itemPopup = new ItemPopupViewModel();
            }
            
            dynamic settings = new ExpandoObject();
            settings.Placement = PlacementMode.Top;
            settings.PlacementTarget = sender;
            settings.VerticalOffset = ((FrameworkElement) sender).ActualHeight * -1;
            
            var stash = _queryEngine.GetStashFromCache();
            _itemPopup.SetItem(item);

            CopyItemRaw(item);
            _windowManager.ShowPopup(_itemPopup, null, settings);
        }

        public void HideItemPopup() {
           if (_itemPopup.IsActive)
                _itemPopup.TryClose();
        }

        public void CopyItemRaw(PoeItem item) {
            var data = JsonConvert.SerializeObject(item);
            Clipboard.SetText(data);
        }

        public void CopyBBCodeToClipboard() {
            var sb = new StringBuilder();

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
            SetStatus("Item BBCode has been copied to your clipboard");
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

        protected override void OnDeactivate(bool close) {
            if (close) {
                _queryEngine.Dispose();
            }
            base.OnDeactivate(close);
        }


        public void BuyGrrbrrBeer() {
            var url = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E9LSRCHJBU7GW";
            Process.Start(new ProcessStartInfo(url));
        }
    }
}