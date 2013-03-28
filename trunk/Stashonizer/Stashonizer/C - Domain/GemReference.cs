using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Stashonizer.Domain {
    public enum GemType {
        Unknown,
        Skill,
        Support,
        Other
    }

    public enum GemColor {
        Unknown,
        Red,
        Green,
        Blue
    }

    public class GemDefinition {
        public string Name { get; set; }
        public GemType Type { get; set; }
        public GemColor Color { get; set; }

        public GemDefinition() { }

        public GemDefinition(PoeItem gem) {
            if (gem.itemType != ItemType.Gem) {
                throw new ArgumentException("Invalid item type, only games allowed");
            }

            Name = gem.name;
            var highestAttribute = GetHighestRequirement(gem);
            switch (highestAttribute.ToUpper()) {
                case "STR":
                    Color = GemColor.Red;
                    break;
                case "INT":
                    Color = GemColor.Blue;
                    break;
                case "DEX":
                    Color = GemColor.Green;
                    break;
                default:
                    Color = GemColor.Unknown;
                    break;
            }

            if (gem.properties[0].name.Contains("Support")) {
                Type = GemType.Support;
            }
            else if (Name == "Portal") {
                Type = GemType.Other;
            }
            else {
                Type = GemType.Skill;
            }
        }

        private string GetHighestRequirement(PoeItem item) {
            var attributeName = string.Empty;
            var maximumRequirement = 0;
            foreach (var requirement in item.requirements) {
                if (requirement.name == "Str" || requirement.name == "Dex" || requirement.name == "Int") {
                    var requirementValue = int.Parse(requirement.values[0][0].ToString());
                    if (requirementValue > maximumRequirement) {
                        maximumRequirement = requirementValue;
                        attributeName = requirement.name;
                    }
                }
            }

            return attributeName;
        }

    }

    public class GemReference {
        private static GemReference _instance;
        private int _originalGemCount;
        private Dictionary<string, GemDefinition> _gemReferenceList;

        public static GemReference Instance {
            get {
                if (_instance == null) {
                    _instance = new GemReference();
                }
                return _instance;
            }
        }

        public Dictionary<string, GemDefinition> GemReferenceList { get { return _gemReferenceList; } }

        private GemReference() {
            _gemReferenceList = new Dictionary<string, GemDefinition>();
            LoadXmlDefinition();
            _originalGemCount = GemReferenceList.Count;
        }

        private void LoadXmlDefinition() {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"\gems.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            foreach (var node in xmlDoc.DocumentElement.ChildNodes) {
                var nodeElement = (XmlElement)node;
                //<gem name="Arc" type="Skill" Color="Blue" />
                var gemName = nodeElement.Attributes["name"].Value;
                var gemType = (GemType)Enum.Parse(typeof(GemType), nodeElement.Attributes["type"].Value);
                var gemColor = (GemColor)Enum.Parse(typeof(GemColor), nodeElement.Attributes["color"].Value);

                if (!GemReferenceList.ContainsKey(gemName)) {
                    GemReferenceList.Add(gemName, new GemDefinition { Name = gemName, Color = gemColor, Type = gemType });
                }
            }
        }

        public void SaveXml() {
            if (GemReferenceList.Count > _originalGemCount) {
                // Saving is required, new gems found
                var xmlDoc = new XmlDocument();
                var rootNode = xmlDoc.CreateNode("element", "gems", "");
                
                foreach (var gem in GemReferenceList) {
                    var gemNode = xmlDoc.CreateNode("element", "gem", "");
                    var nameAttr = xmlDoc.CreateAttribute("name");
                    var typeAttr = xmlDoc.CreateAttribute("type");
                    var colorAttr = xmlDoc.CreateAttribute("color");

                    nameAttr.Value = gem.Value.Name;
                    typeAttr.Value = gem.Value.Type.ToString();
                    colorAttr.Value = gem.Value.Color.ToString();

                    gemNode.Attributes.Append(nameAttr);
                    gemNode.Attributes.Append(typeAttr);
                    gemNode.Attributes.Append(colorAttr);

                    rootNode.AppendChild(gemNode);

                }
                
                xmlDoc.AppendChild(rootNode);
                var filePath = AppDomain.CurrentDomain.BaseDirectory + @"\gems.xml";
                xmlDoc.Save(filePath);
            }
        }

    }
}
