using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stashonizer.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Stashonizer {

    public class Requirement {
        public string name { get; set; }
        [JsonProperty(PropertyName = "values")]
        public List<List<object>> rawValues { get; set; }
        public int displayMode { get; set; }

        [JsonIgnore]
        public bool IsValueModifiedByAffix { get; set; }

        [JsonIgnore]
        public string Value { get; set; }

        [JsonIgnore]
        public string DisplayText { get; set; }

        [JsonIgnore]
        public string DisplayValue { get; set; }

        [OnDeserialized]
        public void OnSerializedMethod(StreamingContext context) {
            if (rawValues != null && rawValues.Any()) {
                Value = rawValues[0][0].ToString();
                IsValueModifiedByAffix = rawValues[0][1].ToString() == "1";
            }
        }
    }

    public class Property {
        public string name { get; set; }

        [JsonProperty(PropertyName = "values")]
        public List<object> rawValues { get; set; }

        public int displayMode { get; set; }

        [JsonIgnore]
        public List<PropertyValue> Values { get; set; }

        [JsonIgnore]
        public string DisplayText { get; set; }

        [JsonIgnore]
        public string DisplayValue { get; set; }

        [JsonIgnore]
        public bool IsValueModifiedByAffix { get; set; }

        [OnDeserialized]
        public void OnSerializedMethod(StreamingContext context) {
            if (rawValues != null && rawValues.Any()) {
                Values = new List<PropertyValue>();
                foreach (var rawValue in rawValues) {
                    var str = rawValue.ToString();
                    var jarray = JArray.Parse(str);
                    Values.Add(new PropertyValue { Value = jarray[0].ToString(), IsValueModifiedByAffix = jarray[1].ToString() == "1" });
                }
            }
            if (name.Contains("%")) {
                DisplayText = name;
                for (var i = 0; i < Values.Count; i++) {
                    DisplayText = DisplayText.Replace("%" + (i).ToString(), Values[i].Value);
                }
            }
            else {
                DisplayText = name;
                if (Values != null && Values.Any()) {
                    DisplayText += ": ";
                    DisplayValue = Values[0].Value;
                    IsValueModifiedByAffix = Values[0].IsValueModifiedByAffix;
                }
            }
        }
    }

    public class PropertyValue {
        public string Value { get; set; }
        public bool IsValueModifiedByAffix { get; set; }
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
            SetItemRarity();
            SetItemType();

            SetMaxLink();
            SetDisplayTextOfRequirements();
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

        private void SetDisplayTextOfRequirements() {
            if (requirements != null && requirements.Any()) {
                requirements.ForEach(r => r.DisplayText = ", " + r.name + " ");
                var frist = requirements.First().DisplayText;
                frist = frist.Substring(2);
                requirements.First().DisplayText = frist;
            }
        }

        private void SetItemRarity() {
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
                    var value = JArray.Parse(prop.rawValues[0].ToString());
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
                else if (rarity == ItemRarity.Currency) {
                    itemType = ItemType.Currency;
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

    public class PoeStash : BaseQueryResult {
        public int numTabs { get; set; }
        public List<PoeItem> items { get; set; }
        public List<Tab> tabs { get; set; }
    }

    public class CharacterInventory : BaseQueryResult {
        public List<PoeItem> items { get; set; }
        public CharacterInfo character { get; set; }
    }

    public class CharacterInfo : BaseQueryResult {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        public string league { get; set; }
        [JsonProperty(PropertyName = "class")]
        public string charClass { get; set; }
        public int classId { get; set; }
        public int level { get; set; }
        [JsonIgnore]
        public bool IsSelected { get; set; }
    }
}
