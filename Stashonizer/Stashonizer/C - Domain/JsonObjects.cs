using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stashonizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Stashonizer {

    public class Requirement {
        public string name { get; set; }
        public List<List<object>> values { get; set; }
        public int displayMode { get; set; }
    }

    public class Property {
        public string name { get; set; }
        public List<object> values { get; set; }
        public int displayMode { get; set; }
    }

    public class AdditionalProperty {
        public string name { get; set; }
        public List<List<object>> values { get; set; }
        public int displayMode { get; set; }
        public double progress { get; set; }
    }

    public class Socket {
        public int group { get; set; }
        public string attr { get; set; }
    }

    public class PoeItem {
        public bool verified { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public string icon { get; set; }
        public bool support { get; set; }
        public string league { get; set; }
        public List<Socket> sockets { get; set; }
        public string name { get; set; }
        public string typeLine { get; set; }
        public bool identified { get; set; }
        public List<Requirement> requirements { get; set; }
        public List<string> implicitMods { get; set; }
        public List<string> explicitMods { get; set; }
        public int frameType { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string inventoryId { get; set; }
        public List<object> socketedItems { get; set; }
        public List<Property> properties { get; set; }
        public string descrText { get; set; }
        public List<AdditionalProperty> additionalProperties { get; set; }
        public string secDescrText { get; set; }

        public int quality { get; set; }

        [JsonIgnore]
        public ItemType itemType { get; set; }

        [JsonIgnore]
        public GemDefinition gemDefinition { get; set; }

        [JsonIgnore]
        public int maxLink { get; set; }

        [JsonIgnore]
        public ItemRarity rarity { get; set; }

        [OnDeserialized]
        public void OnSerializedMethod(StreamingContext context) {
            SetQuality();
            SetitemRarity();
            SetItemType();
            
            SetMaxLink();

            if (string.IsNullOrEmpty(name)) {
                name = typeLine;
            }

            if (itemType == ItemType.Gem) {
                if (!GemReference.Instance.GemReferenceList.ContainsKey(name)) {
                    var gemDef = new GemDefinition(this);
                    GemReference.Instance.GemReferenceList.Add(name, gemDef);
                }
                gemDefinition = GemReference.Instance.GemReferenceList[name];
            }

        }

        private void SetitemRarity() {
            ItemRarity temp = ItemRarity.Undefined;
            ItemRarity.TryParse(frameType.ToString(), true, out temp);
            rarity = temp;
        }

        private void SetMaxLink() {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            foreach (var socket in sockets) {
                if (!temp.ContainsKey(socket.group)) {
                    temp.Add(socket.group, 1);
                }
                else {
                    temp[socket.group]++;
                }
            }

            if (temp.Any()) {
                maxLink = temp.Max(t => t.Value);
            }
            else {
                maxLink = 0;
            }
        }

        private void SetQuality() {
            if (properties == null) return;

            foreach (var prop in properties) {
                if (prop.name == "Quality") {
                    var value = JArray.Parse(prop.values[0].ToString());
                    quality = int.Parse(value[0].ToString().Replace("+", "").Replace("%", ""));
                }
            }
        }

        /// <summary>
        /// Sets the item type based on given frameType property
        /// </summary>
        /// <param name="frameType">the frameType</param>
        internal void SetItemType() {
            var itemRef = new ItemReference();

            if (itemRef.ITEM_TYPE_DATA.ContainsKey(typeLine)) {
                itemType = itemRef.ITEM_TYPE_DATA[typeLine];
            }
            else {
                if (rarity == ItemRarity.Gem) {
                    itemType = ItemType.Gem;
                }
                else if (typeLine.Contains("Flask")) {
                    itemType = ItemType.Flask;
                }
                else if (typeLine.Contains("Quiver")) {
                    itemType = ItemType.Quiver;
                }
                else {
                    itemType = ItemType.Unknown;    
                }
            }
        }

        public string ToBBCode() {
            return string.Format("[linkItem location=\"{0}\" league=\"Hardcore\" x=\"{1}\" y=\"{2}\"]", inventoryId, x, y);
        }
    }

    public class Colour {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
    }

    public class Tab {
        [JsonProperty(PropertyName = "n")]
        public string Name { get; set; }
        public int i { get; set; }
        public Colour colour { get; set; }
        public string src { get; set; }

        [JsonIgnore]
        public bool IsSelected { get; set; }
    }

    public class PoeStash {
        public int numTabs { get; set; }
        public List<PoeItem> items { get; set; }
        public List<Tab> tabs { get; set; }
    }

}
