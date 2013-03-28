using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stashonizer
{
    public enum ItemType
    {
        Bow,
        Quiver,
        Weapon2h,
        Weapon1h,
        Shield,
        Belt,
        Ring,
        Amulet,
        Chest,
        Helmet,
        Boots,
        Gloves,
        Map,
        Currency,
        Gem,
        Flask,
        Unknown
    }

    public enum ItemRarity {
        Normal,
        Blue,
        Rare,
        Unique,
        Gem,
        Currency,
        Quest,
        Undefined
    }

    public class ItemReference
    {
        public Dictionary<string, ItemType> ITEM_TYPE_DATA;
        public ItemReference()
        {
            ITEM_TYPE_DATA = new Dictionary<string, ItemType>();
            ITEM_TYPE_DATA.Add("Crude Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Short Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Long Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Composite Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Recurve Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Bone Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Royal Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Death Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Grove Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Decurve Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Compound Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Sniper Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Ivory Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Highborn Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Decimation Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Thicket Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Citadel Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Ranger Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Maraketh Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Spine Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Imperial Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Harbinger Bow", ItemType.Bow);
            ITEM_TYPE_DATA.Add("Nailed Fist", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Sharktooth Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Awl", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Cat's Paw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Blinder", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Timeworn Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Sparkling Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Fright Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Thresher Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gouger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tiger's Paw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gut Ripper", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Prehistoric Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Noble Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Eagle Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Great White Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Throat Stabber", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Hellion's Paw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Eye Gouger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Vaal Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Imperial Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Terror Claw", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Glass Shank", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Skinning Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Carving Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Stiletto", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Boot Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Copper Kris", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Skean", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Imp Dagger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Flaying Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Butcher Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Poignard", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Boot Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Golden Kris", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Royal Skean", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Fiend Dagger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gutting Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Slaughter Knife", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ambusher", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ezomyte Dagger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Platinum Kris", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Imperial Skean", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Demon Dagger", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Rusted Hatchet", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Jade Hatchet", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Boarding Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Cleaver", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Broad Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Arming Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Decorative Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Spectral Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Jasper Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tomahawk", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Wrist Chopper", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("War Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Chest Splitter", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ceremonial Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Wraith Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Karui Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Siege Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Reaver Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Vaal Hatchet", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Royal Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Infernal Axe", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Driftwood Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tribal Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Spiked Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Stone Hammer", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("War Hammer", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Bladed Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ceremonial Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Dream Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Petrified Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Barbed Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Rock Breaker", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Battle Hammer", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Flanged Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ornate Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Phantom Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ancestral Club", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tenderizer", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gavel", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Legion Hammer", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Pernarch", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Auric Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Nightmare Mace", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Rusted Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Copper Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Sabre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Broad Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("War Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ancient Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Elegant Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Dusk Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Variscite Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Cutlass", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Baselard", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Battle Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Elder Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Graceful Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Twilight Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gemstone Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Corsair Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gladius", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Legion Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Vaal Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Eternal Sword", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Midnight Blade", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Driftwood Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Darkwood Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Bronze Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Quartz Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Iron Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ochre Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Ritual Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Shadow Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Grinning Fetish", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Sekhem", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Crystal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Lead Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Blood Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Royal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Abyssal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Karui Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tyrant's Sekhem", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Opal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Platinum Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Carnal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Vaal Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Void Sceptre", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Gnarled Branch", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Primitive Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Long Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Iron Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Coiled Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Royal Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Vile Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Woodful Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Quarterstaff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Military Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Serpentine Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Highborn Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Foul Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Primordial Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Lathi", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Ezoymte Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Maelstr\u00F6m Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Imperial Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Damnation Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Ezomyte Staff", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Rusted Spike", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Whalebone Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Battered Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Basket Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Jagged Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Antique Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Elegant Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Thorn Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Wyrmbone Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Burnished Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Estoc", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Serrated Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Primeval Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Fancy Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Apex Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Dragonbone Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tempered Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Pecoraro", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Spiraled Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Vaal Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Jeweled Foil", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Harpy Rapier", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Stone Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Jade Chopper", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Woodsplitter", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Poleaxe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Double Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Gilded Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Shadow Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Jasper Chopper", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Timber Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Headsman Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Labrys", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Noble Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Abyssal Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Karui Chopper", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Sundering Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Ezomyte Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Vaal Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Despot Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Void Axe", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Driftwood Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Tribal Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Mallet", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Sledgehammer", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Spiked Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Brass Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Fright Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Totemic Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Great Mallet", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Steelhead", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Spiny Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Plated Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Dread Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Karui Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Colossus Mallet", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Piledriver", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Meatgrinder", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Imperial Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Terror Maul", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Corroded Blade", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Longsword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Bastard Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Two-Handed Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Etched Greatsword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Ornate Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Spectral Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Butcher Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Footman Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Highland Blade", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Engraved Greatsword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Tiger Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Wraith Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Headman's Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Reaver Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Ezomyte Blade", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Vaal Greatsword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Lion Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Infernal Sword", ItemType.Weapon2h);
            ITEM_TYPE_DATA.Add("Driftwood Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Goat's Horn", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Carved Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Quartz Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Spiraled Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Sage Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Faun's Horn", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Engraved Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Crystal Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Serpent Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Omen Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Demon's Horn", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Imbued Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Opal Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Tornado Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Prophecy Wand", ItemType.Weapon1h);
            ITEM_TYPE_DATA.Add("Plate Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Shabby Jerkin", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Simple Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Scale Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Padded Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Chainmail Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Chestplate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Light Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Desert Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Legion Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Chainmail Tunic", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Strapped Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Oiled Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Silken Vest", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Buckskin Tunic", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Copper Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Ringmail Coat", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Scale Doublet", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Scholar's Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Diplomatic Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Duelist Cuirass", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Padded Jacket", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Infantry Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("War Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Chainmail Doublet", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Oiled Coat", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Silken Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Wild Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Scarlet Raiment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Scale Armor", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Scale Armour", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Mage's Vestment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Arena Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sun Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Silk Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Soldier's Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Soldier Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Waxed Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Thief's Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Bone Armor", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Bone Armour", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Lordly Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Field Lamellar", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Cabalist Regalia", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Holy Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Eelskin Tunic", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sage's Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Bronze Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Wyrmscale Doublet", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Latticed Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Quilted Jacket", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Battle Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Silken Wrap", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Frontier Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Hussar Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Crusader Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sleek Coat", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Conjurer's Vestment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Glorious Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sun Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Wyrmscale", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Ornate Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Crimson Raiment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Coronal Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Colosseum Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Spidersilk Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Commander's Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Chain Hauberk", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Lacquered Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Cutthroat's Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Destroyer Regalia", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Majestic Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Battle Lamellar", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Devout Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Golden Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Leather Tunic", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Salvation Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Strapped Leathers", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sharkskin Tunic", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Savant's Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Crypt Armor", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Crypt Armour", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Dragonscale Doublet", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Loricated Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sentinel Jacket", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Destiny Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Crusader Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Necromancer Silks", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Cavalry Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Conquest Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Astral Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Varnished Coat", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Occultist's Vestment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Exquisite Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Full Dragonscale", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Elegant Ringmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Gladiator Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Blood Raiment", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Widowsilk Robe", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Zodiac Leather", ItemType.Chest);
            ITEM_TYPE_DATA.Add("General's Brigandine", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Saint's Hauberk", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Glorious Plate", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Assassin's Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Sadist Garb", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Vaal Regalia", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Triumphant Lamellar", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Saintly Chainmail", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Carnal Armor", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Carnal Armour", ItemType.Chest);
            ITEM_TYPE_DATA.Add("Iron Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Rawhide Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Wool Shoes", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Chain Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Wrapped Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Leatherscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Velvet Slippers", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Steel Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Goathide Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Ringmail Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Strapped Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Ironscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Deerskin Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Silk Slippers", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Plated Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Clasped Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Mesh Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Bronzescale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Scholar Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Reinforced Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Nubuck Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Shackled Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Steelscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Riveted Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Antique Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Satin Slippers", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Eelskin Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Zealot Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Trapper Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Serpentscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Samite Slippers", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Sharkskin Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Ancient Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Ambush Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Horseman's Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Soldier's Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Soldier Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Legion Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Wyrmscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Conjurer Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Goliath Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Shagreen Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Carnal Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Desert Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Hydrascale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Arcanist Slippers", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Vaal Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Stealth Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Assassin's Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Crusader Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Dragonscale Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Sorcerer Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Titan Greaves", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Murder Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Slink Boots", ItemType.Boots);
            ITEM_TYPE_DATA.Add("Iron Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Wool Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Rawhide Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Fishscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Wrapped Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Chain Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Goathide Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Plated Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Velvet Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Ironscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Strapped Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Ringmail Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Deerskin Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Bronze Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Silk Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Bronzescale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Clasped Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Mesh Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Nubuck Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Steel Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Steelscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Embroidered Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Trapper Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Riveted Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Eelskin Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Antique Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Satin Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Zealot Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Serpentscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Sharkskin Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Ambush Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Samite Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Ancient Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Wyrmscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Carnal Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Horseman's Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Soldier's Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Soldier Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Legion Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Goliath Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Shagreen Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Conjurer Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Cavalry Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Assassin's Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Hydrascale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Arcanist Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Stealth Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Vaal Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Crusader Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Dragonscale Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Murder Mitts", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Titan Gauntlets", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Sorcerer Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Slink Gloves", ItemType.Gloves);
            ITEM_TYPE_DATA.Add("Rusted Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Vine Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Battered Cap", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Tarnished Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Rusted Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Corroded Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Footman's Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Copper Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Wooden Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Leather Cap", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Chainmail Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Flanged Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Tribal Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Copper Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Gladiator Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Leather Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Ringmail Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Ribbed Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Executioner Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Gemmed Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Ceremonial Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Studded Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Inlaid Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Gilded Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Gilded Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Bandit Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Imperial Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Coolus Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Woven Ring Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Iron Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Carved Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Reaver Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Hunter Cap", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Finned Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Mesh Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Heathen Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Forest Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Encrusted Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Mercenary Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Ornate Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Assassin Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Zealot's Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Gleaming Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Grove Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Vaal Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Steel Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Commander's Ring Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Polished Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Petrified Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Destroyer Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Huntress Cap", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Pagan Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Crusader's Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Bladed Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Thicket Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Annihilator Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Royal Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Crested Helmet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Murder Mask", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Imperial Chain Coif", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Ezomyte Circlet", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Armageddon Casque", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Jungle Hood", ItemType.Helmet);
            ITEM_TYPE_DATA.Add("Splintered Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Goathide Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Twig Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Rotted Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Corroded Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Spiked Bundle", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Plank Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Pine Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Yew Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Rawhide Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Driftwood Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Fir Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Linden Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Bone Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Painted Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Cedar Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Alloyed Spike Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Studded Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Reinforced Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Hammered Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Tarnished Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Copper Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Burnished Spike Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Layered Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Scarlet Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Jingling Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("War Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Reinforced Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ornate Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Brass Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Splendid Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Gilded Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ceremonial Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Painted Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Walnut Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Oak Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Redwood Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Maple Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Buckskin Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Etched Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ivory Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Enameled Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Mahogany Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ancient Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Compound Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Spiked Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Corrugated Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Steel Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Bronze Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Chiming Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Polished Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Crimson Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Laminated Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Battle Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Salvaged Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Girded Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Thorium Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Sovereign Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Baroque Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Golden Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Angel Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Angelic Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Crested Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Lacewood Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ironwood Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Shagreen Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Teak Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Alder Spike Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Fossilized Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Branded Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Lacquered Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Hunting Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ebony Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ezomyte Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Vaal Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Spiny Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Champion Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Vaal Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Ezomyte Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Harmonic Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Mosaic Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Mirrored Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Crusader Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Cardinal Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Colossal Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Archon Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Titanium Spirit Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Wood Focus", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Tribal Kite Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Salvaged Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Bone Focus", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Driftwood Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Imperial Buckler", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Elegant Round Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Supreme Spiked Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Pinnacle Tower Shield", ItemType.Shield);
            ITEM_TYPE_DATA.Add("Paua Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Coral Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Jade Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Amber Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Lapis Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Gold Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Onyx Amulet", ItemType.Amulet);
            ITEM_TYPE_DATA.Add("Chain Belt", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Rustic Sash", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Leather Belt", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Heavy Belt", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Studded Belt", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Cloth Belt", ItemType.Belt);
            ITEM_TYPE_DATA.Add("Coral Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Prismatic Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Paua Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Iron Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Sapphire Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Gold Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Ruby Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Topaz Ring", ItemType.Ring);
            ITEM_TYPE_DATA.Add("Conductive Quiver", ItemType.Quiver);
            ITEM_TYPE_DATA.Add("Light Quiver", ItemType.Quiver);
            ITEM_TYPE_DATA.Add("Arachnid Nest Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Bog Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Canyon Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Catacomb Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Cells Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Cemetery Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Coves Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Crematorium Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Crypt Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dark Forest Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dried Lake Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dry Peninsula Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dry Woods Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dunes Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Dungeon Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Gorge Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Graveyard Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Grotto Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Jungle Valley Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Marsh Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Maze Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Mine Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Mountain Ledge Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Mud Geyser Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Necropolis Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Overgrown Ruin Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Overgrown Shrine Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Plateau Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Reef Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Sewer Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Shore Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Spider Forest Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Spider Lair Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Springs Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Strand Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Subterranean Stream Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Thicket Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Tomb Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Torture Chamber Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Tropical Island Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Tunnel Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Underground River Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Underground Sea Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Vaal Pyramid Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Vaults of Atziri Map", ItemType.Map);
            ITEM_TYPE_DATA.Add("Waste Pool Map", ItemType.Map);
        }
    }
}
/* #region Items
 {"Crude Bow", ItemType.Bow},
 {"Short Bow", ItemType.Bow},
 {"Long Bow", ItemType.Bow},
 {"Composite Bow", ItemType.Bow},
 {"Recurve Bow", ItemType.Bow},
 {"Bone Bow", ItemType.Bow},
 {"Royal Bow", ItemType.Bow},
 {"Death Bow", ItemType.Bow},
 {"Grove Bow", ItemType.Bow},
 {"Decurve Bow", ItemType.Bow},
 {"Compound Bow", ItemType.Bow},
 {"Sniper Bow", ItemType.Bow},
 {"Ivory Bow", ItemType.Bow},
 {"Highborn Bow", ItemType.Bow},
 {"Decimation Bow", ItemType.Bow},
 {"Thicket Bow", ItemType.Bow},
 {"Citadel Bow", ItemType.Bow},
 {"Ranger Bow", ItemType.Bow},
 {"Maraketh Bow", ItemType.Bow},
 {"Spine Bow", ItemType.Bow},
 {"Imperial Bow", ItemType.Bow},
 {"Harbinger Bow", ItemType.Bow},
 {"Nailed Fist", ItemType.Weapon1h},
 {"Sharktooth Claw", ItemType.Weapon1h},
 {"Awl", ItemType.Weapon1h},
 {"Cat's Paw", ItemType.Weapon1h},
 {"Blinder", ItemType.Weapon1h},
 {"Timeworn Claw", ItemType.Weapon1h},
 {"Sparkling Claw", ItemType.Weapon1h},
 {"Fright Claw", ItemType.Weapon1h},
 {"Thresher Claw", ItemType.Weapon1h},
 {"Gouger", ItemType.Weapon1h},
 {"Tiger's Paw", ItemType.Weapon1h},
 {"Gut Ripper", ItemType.Weapon1h},
 {"Prehistoric Claw", ItemType.Weapon1h},
 {"Noble Claw", ItemType.Weapon1h},
 {"Eagle Claw", ItemType.Weapon1h},
 {"Great White Claw", ItemType.Weapon1h},
 {"Throat Stabber", ItemType.Weapon1h},
 {"Hellion's Paw", ItemType.Weapon1h},
 {"Eye Gouger", ItemType.Weapon1h},
 {"Vaal Claw", ItemType.Weapon1h},
 {"Imperial Claw", ItemType.Weapon1h},
 {"Terror Claw", ItemType.Weapon1h},
 {"Glass Shank", ItemType.Weapon1h},
 {"Skinning Knife", ItemType.Weapon1h},
 {"Carving Knife", ItemType.Weapon1h},
 {"Stiletto", ItemType.Weapon1h},
 {"Boot Knife", ItemType.Weapon1h},
 {"Copper Kris", ItemType.Weapon1h},
 {"Skean", ItemType.Weapon1h},
 {"Imp Dagger", ItemType.Weapon1h},
 {"Flaying Knife", ItemType.Weapon1h},
 {"Butcher Knife", ItemType.Weapon1h},
 {"Poignard", ItemType.Weapon1h},
 {"Boot Blade", ItemType.Weapon1h},
 {"Golden Kris", ItemType.Weapon1h},
 {"Royal Skean", ItemType.Weapon1h},
 {"Fiend Dagger", ItemType.Weapon1h},
 {"Gutting Knife", ItemType.Weapon1h},
 {"Slaughter Knife", ItemType.Weapon1h},
 {"Ambusher", ItemType.Weapon1h},
 {"Ezomyte Dagger", ItemType.Weapon1h},
 {"Platinum Kris", ItemType.Weapon1h},
 {"Imperial Skean", ItemType.Weapon1h},
 {"Demon Dagger", ItemType.Weapon1h},
 {"Rusted Hatchet", ItemType.Weapon1h},
 {"Jade Hatchet", ItemType.Weapon1h},
 {"Boarding Axe", ItemType.Weapon1h},
 {"Cleaver", ItemType.Weapon1h},
 {"Broad Axe", ItemType.Weapon1h},
 {"Arming Axe", ItemType.Weapon1h},
 {"Decorative Axe", ItemType.Weapon1h},
 {"Spectral Axe", ItemType.Weapon1h},
 {"Jasper Axe", ItemType.Weapon1h},
 {"Tomahawk", ItemType.Weapon1h},
 {"Wrist Chopper", ItemType.Weapon1h},
 {"War Axe", ItemType.Weapon1h},
 {"Chest Splitter", ItemType.Weapon1h},
 {"Ceremonial Axe", ItemType.Weapon1h},
 {"Wraith Axe", ItemType.Weapon1h},
 {"Karui Axe", ItemType.Weapon1h},
 {"Siege Axe", ItemType.Weapon1h},
 {"Reaver Axe", ItemType.Weapon1h},
 {"Ezomyte Axe", ItemType.Weapon1h},
 {"Vaal Hatchet", ItemType.Weapon1h},
 {"Royal Axe", ItemType.Weapon1h},
 {"Infernal Axe", ItemType.Weapon1h},
 {"Driftwood Club", ItemType.Weapon1h},
 {"Tribal Club", ItemType.Weapon1h},
 {"Spiked Club", ItemType.Weapon1h},
 {"Stone Hammer", ItemType.Weapon1h},
 {"War Hammer", ItemType.Weapon1h},
 {"Bladed Mace", ItemType.Weapon1h},
 {"Ceremonial Mace", ItemType.Weapon1h},
 {"Dream Mace", ItemType.Weapon1h},
 {"Petrified Club", ItemType.Weapon1h},
 {"Barbed Club", ItemType.Weapon1h},
 {"Rock Breaker", ItemType.Weapon1h},
 {"Battle Hammer", ItemType.Weapon1h},
 {"Flanged Mace", ItemType.Weapon1h},
 {"Ornate Mace", ItemType.Weapon1h},
 {"Phantom Mace", ItemType.Weapon1h},
 {"Ancestral Club", ItemType.Weapon1h},
 {"Tenderizer", ItemType.Weapon1h},
 {"Gavel", ItemType.Weapon1h},
 {"Legion Hammer", ItemType.Weapon1h},
 {"Pernarch", ItemType.Weapon1h},
 {"Auric Mace", ItemType.Weapon1h},
 {"Nightmare Mace", ItemType.Weapon1h},
 {"Rusted Sword", ItemType.Weapon1h},
 {"Copper Sword", ItemType.Weapon1h},
 {"Sabre", ItemType.Weapon1h},
 {"Broad Sword", ItemType.Weapon1h},
 {"War Sword", ItemType.Weapon1h},
 {"Ancient Sword", ItemType.Weapon1h},
 {"Elegant Sword", ItemType.Weapon1h},
 {"Dusk Blade", ItemType.Weapon1h},
 {"Variscite Blade", ItemType.Weapon1h},
 {"Cutlass", ItemType.Weapon1h},
 {"Baselard", ItemType.Weapon1h},
 {"Battle Sword", ItemType.Weapon1h},
 {"Elder Sword", ItemType.Weapon1h},
 {"Graceful Sword", ItemType.Weapon1h},
 {"Twilight Blade", ItemType.Weapon1h},
 {"Gemstone Sword", ItemType.Weapon1h},
 {"Corsair Sword", ItemType.Weapon1h},
 {"Gladius", ItemType.Weapon1h},
 {"Legion Sword", ItemType.Weapon1h},
 {"Vaal Blade", ItemType.Weapon1h},
 {"Eternal Sword", ItemType.Weapon1h},
 {"Midnight Blade", ItemType.Weapon1h},
 {"Driftwood Sceptre", ItemType.Weapon1h},
 {"Darkwood Sceptre", ItemType.Weapon1h},
 {"Bronze Sceptre", ItemType.Weapon1h},
 {"Quartz Sceptre", ItemType.Weapon1h},
 {"Iron Sceptre", ItemType.Weapon1h},
 {"Ochre Sceptre", ItemType.Weapon1h},
 {"Ritual Sceptre", ItemType.Weapon1h},
 {"Shadow Sceptre", ItemType.Weapon1h},
 {"Grinning Fetish", ItemType.Weapon1h},
 {"Sekhem", ItemType.Weapon1h},
 {"Crystal Sceptre", ItemType.Weapon1h},
 {"Lead Sceptre", ItemType.Weapon1h},
 {"Blood Sceptre", ItemType.Weapon1h},
 {"Royal Sceptre", ItemType.Weapon1h},
 {"Abyssal Sceptre", ItemType.Weapon1h},
 {"Karui Sceptre", ItemType.Weapon1h},
 {"Tyrant's Sekhem", ItemType.Weapon1h},
 {"Opal Sceptre", ItemType.Weapon1h},
 {"Platinum Sceptre", ItemType.Weapon1h},
 {"Carnal Sceptre", ItemType.Weapon1h},
 {"Vaal Sceptre", ItemType.Weapon1h},
 {"Void Sceptre", ItemType.Weapon1h},
 {"Gnarled Branch", ItemType.Weapon2h},
 {"Primitive Staff", ItemType.Weapon2h},
 {"Long Staff", ItemType.Weapon2h},
 {"Iron Staff", ItemType.Weapon2h},
 {"Coiled Staff", ItemType.Weapon2h},
 {"Royal Staff", ItemType.Weapon2h},
 {"Vile Staff", ItemType.Weapon2h},
 {"Woodful Staff", ItemType.Weapon2h},
 {"Quarterstaff", ItemType.Weapon2h},
 {"Military Staff", ItemType.Weapon2h},
 {"Serpentine Staff", ItemType.Weapon2h},
 {"Highborn Staff", ItemType.Weapon2h},
 {"Foul Staff", ItemType.Weapon2h},
 {"Primordial Staff", ItemType.Weapon2h},
 {"Lathi", ItemType.Weapon2h},
 {"Ezoymte Staff", ItemType.Weapon2h},
 {"Maelstr\u00F6m Staff", ItemType.Weapon2h},
 {"Imperial Staff", ItemType.Weapon2h},
 {"Damnation Staff", ItemType.Weapon2h},
 {"Ezomyte Staff", ItemType.Weapon2h},
 {"Rusted Spike", ItemType.Weapon1h},
 {"Whalebone Rapier", ItemType.Weapon1h},
 {"Battered Foil", ItemType.Weapon1h},
 {"Basket Rapier", ItemType.Weapon1h},
 {"Jagged Foil", ItemType.Weapon1h},
 {"Antique Rapier", ItemType.Weapon1h},
 {"Elegant Foil", ItemType.Weapon1h},
 {"Thorn Rapier", ItemType.Weapon1h},
 {"Wyrmbone Rapier", ItemType.Weapon1h},
 {"Burnished Foil", ItemType.Weapon1h},
 {"Estoc", ItemType.Weapon1h},
 {"Serrated Foil", ItemType.Weapon1h},
 {"Primeval Rapier", ItemType.Weapon1h},
 {"Fancy Foil", ItemType.Weapon1h},
 {"Apex Rapier", ItemType.Weapon1h},
 {"Dragonbone Rapier", ItemType.Weapon1h},
 {"Tempered Foil", ItemType.Weapon1h},
 {"Pecoraro", ItemType.Weapon1h},
 {"Spiraled Foil", ItemType.Weapon1h},
 {"Vaal Rapier", ItemType.Weapon1h},
 {"Jeweled Foil", ItemType.Weapon1h},
 {"Harpy Rapier", ItemType.Weapon1h},
 {"Stone Axe", ItemType.Weapon2h},
 {"Jade Chopper", ItemType.Weapon2h},
 {"Woodsplitter", ItemType.Weapon2h},
 {"Poleaxe", ItemType.Weapon2h},
 {"Double Axe", ItemType.Weapon2h},
 {"Gilded Axe", ItemType.Weapon2h},
 {"Shadow Axe", ItemType.Weapon2h},
 {"Jasper Chopper", ItemType.Weapon2h},
 {"Timber Axe", ItemType.Weapon2h},
 {"Headsman Axe", ItemType.Weapon2h},
 {"Labrys", ItemType.Weapon2h},
 {"Noble Axe", ItemType.Weapon2h},
 {"Abyssal Axe", ItemType.Weapon2h},
 {"Karui Chopper", ItemType.Weapon2h},
 {"Sundering Axe", ItemType.Weapon2h},
 {"Ezomyte Axe", ItemType.Weapon2h},
 {"Vaal Axe", ItemType.Weapon2h},
 {"Despot Axe", ItemType.Weapon2h},
 {"Void Axe", ItemType.Weapon2h},
 {"Driftwood Maul", ItemType.Weapon2h},
 {"Tribal Maul", ItemType.Weapon2h},
 {"Mallet", ItemType.Weapon2h},
 {"Sledgehammer", ItemType.Weapon2h},
 {"Spiked Maul", ItemType.Weapon2h},
 {"Brass Maul", ItemType.Weapon2h},
 {"Fright Maul", ItemType.Weapon2h},
 {"Totemic Maul", ItemType.Weapon2h},
 {"Great Mallet", ItemType.Weapon2h},
 {"Steelhead", ItemType.Weapon2h},
 {"Spiny Maul", ItemType.Weapon2h},
 {"Plated Maul", ItemType.Weapon2h},
 {"Dread Maul", ItemType.Weapon2h},
 {"Karui Maul", ItemType.Weapon2h},
 {"Colossus Mallet", ItemType.Weapon2h},
 {"Piledriver", ItemType.Weapon2h},
 {"Meatgrinder", ItemType.Weapon2h},
 {"Imperial Maul", ItemType.Weapon2h},
 {"Terror Maul", ItemType.Weapon2h},
 {"Corroded Blade", ItemType.Weapon2h},
 {"Longsword", ItemType.Weapon2h},
 {"Bastard Sword", ItemType.Weapon2h},
 {"Two-Handed Sword", ItemType.Weapon2h},
 {"Etched Greatsword", ItemType.Weapon2h},
 {"Ornate Sword", ItemType.Weapon2h},
 {"Spectral Sword", ItemType.Weapon2h},
 {"Butcher Sword", ItemType.Weapon2h},
 {"Footman Sword", ItemType.Weapon2h},
 {"Highland Blade", ItemType.Weapon2h},
 {"Engraved Greatsword", ItemType.Weapon2h},
 {"Tiger Sword", ItemType.Weapon2h},
 {"Wraith Sword", ItemType.Weapon2h},
 {"Headman's Sword", ItemType.Weapon2h},
 {"Reaver Sword", ItemType.Weapon2h},
 {"Ezomyte Blade", ItemType.Weapon2h},
 {"Vaal Greatsword", ItemType.Weapon2h},
 {"Lion Sword", ItemType.Weapon2h},
 {"Infernal Sword", ItemType.Weapon2h},
 {"Driftwood Wand", ItemType.Weapon1h},
 {"Goat's Horn", ItemType.Weapon1h},
 {"Carved Wand", ItemType.Weapon1h},
 {"Quartz Wand", ItemType.Weapon1h},
 {"Spiraled Wand", ItemType.Weapon1h},
 {"Sage Wand", ItemType.Weapon1h},
 {"Faun's Horn", ItemType.Weapon1h},
 {"Engraved Wand", ItemType.Weapon1h},
 {"Crystal Wand", ItemType.Weapon1h},
 {"Serpent Wand", ItemType.Weapon1h},
 {"Omen Wand", ItemType.Weapon1h},
 {"Demon's Horn", ItemType.Weapon1h},
 {"Imbued Wand", ItemType.Weapon1h},
 {"Opal Wand", ItemType.Weapon1h},
 {"Tornado Wand", ItemType.Weapon1h},
 {"Prophecy Wand", ItemType.Weapon1h},
 {"Plate Vest", ItemType.Chest},
 {"Shabby Jerkin", ItemType.Chest},
 {"Simple Robe", ItemType.Chest},
 {"Scale Vest", ItemType.Chest},
 {"Padded Vest", ItemType.Chest},
 {"Chainmail Vest", ItemType.Chest},
 {"Chestplate", ItemType.Chest},
 {"Light Brigandine", ItemType.Chest},
 {"Desert Brigandine", ItemType.Chest},
 {"Legion Brigandine", ItemType.Chest},
 {"Chainmail Tunic", ItemType.Chest},
 {"Strapped Leather", ItemType.Chest},
 {"Oiled Vest", ItemType.Chest},
 {"Silken Vest", ItemType.Chest},
 {"Buckskin Tunic", ItemType.Chest},
 {"Copper Plate", ItemType.Chest},
 {"Ringmail Coat", ItemType.Chest},
 {"Scale Doublet", ItemType.Chest},
 {"Scholar's Robe", ItemType.Chest},
 {"Diplomatic Robe", ItemType.Chest},
 {"Robe", ItemType.Chest},
 {"Duelist Cuirass", ItemType.Chest},
 {"Ringmail", ItemType.Chest},
 {"Padded Jacket", ItemType.Chest},
 {"Infantry Brigandine", ItemType.Chest},
 {"War Plate", ItemType.Chest},
 {"Chainmail Doublet", ItemType.Chest},
 {"Oiled Coat", ItemType.Chest},
 {"Silken Garb", ItemType.Chest},
 {"Wild Leather", ItemType.Chest},
 {"Scarlet Raiment", ItemType.Chest},
 {"Full Ringmail", ItemType.Chest},
 {"Full Scale Armor", ItemType.Chest},
 {"Full Scale Armour", ItemType.Chest},
 {"Mage's Vestment", ItemType.Chest},
 {"Full Leather", ItemType.Chest},
 {"Full Plate", ItemType.Chest},
 {"Arena Plate", ItemType.Chest},
 {"Sun Leather", ItemType.Chest},
 {"Silk Robe", ItemType.Chest},
 {"Soldier's Brigandine", ItemType.Chest},
 {"Soldier Brigandine", ItemType.Chest},
 {"Full Chainmail", ItemType.Chest},
 {"Waxed Garb", ItemType.Chest},
 {"Thief's Garb", ItemType.Chest},
 {"Bone Armor", ItemType.Chest},
 {"Bone Armour", ItemType.Chest},
 {"Lordly Plate", ItemType.Chest},
 {"Field Lamellar", ItemType.Chest},
 {"Cabalist Regalia", ItemType.Chest},
 {"Holy Chainmail", ItemType.Chest},
 {"Eelskin Tunic", ItemType.Chest},
 {"Sage's Robe", ItemType.Chest},
 {"Bronze Plate", ItemType.Chest},
 {"Wyrmscale Doublet", ItemType.Chest},
 {"Latticed Ringmail", ItemType.Chest},
 {"Quilted Jacket", ItemType.Chest},
 {"Battle Plate", ItemType.Chest},
 {"Silken Wrap", ItemType.Chest},
 {"Frontier Leather", ItemType.Chest},
 {"Hussar Brigandine", ItemType.Chest},
 {"Crusader Chainmail", ItemType.Chest},
 {"Sleek Coat", ItemType.Chest},
 {"Conjurer's Vestment", ItemType.Chest},
 {"Glorious Leather", ItemType.Chest},
 {"Sun Plate", ItemType.Chest},
 {"Full Wyrmscale", ItemType.Chest},
 {"Ornate Ringmail", ItemType.Chest},
 {"Crimson Raiment", ItemType.Chest},
 {"Coronal Leather", ItemType.Chest},
 {"Colosseum Plate", ItemType.Chest},
 {"Spidersilk Robe", ItemType.Chest},
 {"Commander's Brigandine", ItemType.Chest},
 {"Chain Hauberk", ItemType.Chest},
 {"Lacquered Garb", ItemType.Chest},
 {"Cutthroat's Garb", ItemType.Chest},
 {"Destroyer Regalia", ItemType.Chest},
 {"Majestic Plate", ItemType.Chest},
 {"Battle Lamellar", ItemType.Chest},
 {"Devout Chainmail", ItemType.Chest},
 {"Golden Plate", ItemType.Chest},
 {"Leather Tunic", ItemType.Chest},
 {"Salvation Robe", ItemType.Chest},
 {"Strapped Leathers", ItemType.Chest},
 {"Sharkskin Tunic", ItemType.Chest},
 {"Savant's Robe", ItemType.Chest},
 {"Crypt Armor", ItemType.Chest},
 {"Crypt Armour", ItemType.Chest},
 {"Dragonscale Doublet", ItemType.Chest},
 {"Loricated Ringmail", ItemType.Chest},
 {"Sentinel Jacket", ItemType.Chest},
 {"Destiny Leather", ItemType.Chest},
 {"Crusader Plate", ItemType.Chest},
 {"Necromancer Silks", ItemType.Chest},
 {"Cavalry Brigandine", ItemType.Chest},
 {"Conquest Chainmail", ItemType.Chest},
 {"Astral Plate", ItemType.Chest},
 {"Varnished Coat", ItemType.Chest},
 {"Occultist's Vestment", ItemType.Chest},
 {"Exquisite Leather", ItemType.Chest},
 {"Full Dragonscale", ItemType.Chest},
 {"Elegant Ringmail", ItemType.Chest},
 {"Gladiator Plate", ItemType.Chest},
 {"Blood Raiment", ItemType.Chest},
 {"Widowsilk Robe", ItemType.Chest},
 {"Zodiac Leather", ItemType.Chest},
 {"General's Brigandine", ItemType.Chest},
 {"Saint's Hauberk", ItemType.Chest},
 {"Glorious Plate", ItemType.Chest},
 {"Assassin's Garb", ItemType.Chest},
 {"Sadist Garb", ItemType.Chest},
 {"Vaal Regalia", ItemType.Chest},
 {"Triumphant Lamellar", ItemType.Chest},
 {"Saintly Chainmail", ItemType.Chest},
 {"Carnal Armor", ItemType.Chest},
 {"Carnal Armour", ItemType.Chest},
 {"Iron Greaves", ItemType.Boots},
 {"Rawhide Boots", ItemType.Boots},
 {"Wool Shoes", ItemType.Boots},
 {"Chain Boots", ItemType.Boots},
 {"Wrapped Boots", ItemType.Boots},
 {"Leatherscale Boots", ItemType.Boots},
 {"Velvet Slippers", ItemType.Boots},
 {"Steel Greaves", ItemType.Boots},
 {"Goathide Boots", ItemType.Boots},
 {"Ringmail Boots", ItemType.Boots},
 {"Strapped Boots", ItemType.Boots},
 {"Ironscale Boots", ItemType.Boots},
 {"Deerskin Boots", ItemType.Boots},
 {"Silk Slippers", ItemType.Boots},
 {"Plated Greaves", ItemType.Boots},
 {"Clasped Boots", ItemType.Boots},
 {"Mesh Boots", ItemType.Boots},
 {"Bronzescale Boots", ItemType.Boots},
 {"Scholar Boots", ItemType.Boots},
 {"Reinforced Greaves", ItemType.Boots},
 {"Nubuck Boots", ItemType.Boots},
 {"Shackled Boots", ItemType.Boots},
 {"Steelscale Boots", ItemType.Boots},
 {"Riveted Boots", ItemType.Boots},
 {"Antique Greaves", ItemType.Boots},
 {"Satin Slippers", ItemType.Boots},
 {"Eelskin Boots", ItemType.Boots},
 {"Zealot Boots", ItemType.Boots},
 {"Trapper Boots", ItemType.Boots},
 {"Serpentscale Boots", ItemType.Boots},
 {"Samite Slippers", ItemType.Boots},
 {"Sharkskin Boots", ItemType.Boots},
 {"Ancient Greaves", ItemType.Boots},
 {"Ambush Boots", ItemType.Boots},
 {"Horseman's Boots", ItemType.Boots},
 {"Soldier's Boots", ItemType.Boots},
 {"Soldier Boots", ItemType.Boots},
 {"Legion Boots", ItemType.Boots},
 {"Wyrmscale Boots", ItemType.Boots},
 {"Conjurer Boots", ItemType.Boots},
 {"Goliath Greaves", ItemType.Boots},
 {"Shagreen Boots", ItemType.Boots},
 {"Carnal Boots", ItemType.Boots},
 {"Desert Boots", ItemType.Boots},
 {"Legion Boots", ItemType.Boots},
 {"Hydrascale Boots", ItemType.Boots},
 {"Arcanist Slippers", ItemType.Boots},
 {"Vaal Greaves", ItemType.Boots},
 {"Stealth Boots", ItemType.Boots},
 {"Assassin's Boots", ItemType.Boots},
 {"Crusader Boots", ItemType.Boots},
 {"Dragonscale Boots", ItemType.Boots},
 {"Sorcerer Boots", ItemType.Boots},
 {"Titan Greaves", ItemType.Boots},
 {"Murder Boots", ItemType.Boots},
 {"Slink Boots", ItemType.Boots},
 {"Iron Gauntlets", ItemType.Gloves},
 {"Wool Gloves", ItemType.Gloves},
 {"Rawhide Gloves", ItemType.Gloves},
 {"Fishscale Gauntlets", ItemType.Gloves},
 {"Wrapped Mitts", ItemType.Gloves},
 {"Chain Gloves", ItemType.Gloves},
 {"Goathide Gloves", ItemType.Gloves},
 {"Plated Gauntlets", ItemType.Gloves},
 {"Velvet Gloves", ItemType.Gloves},
 {"Ironscale Gauntlets", ItemType.Gloves},
 {"Strapped Mitts", ItemType.Gloves},
 {"Ringmail Gloves", ItemType.Gloves},
 {"Deerskin Gloves", ItemType.Gloves},
 {"Bronze Gauntlets", ItemType.Gloves},
 {"Silk Gloves", ItemType.Gloves},
 {"Bronzescale Gauntlets", ItemType.Gloves},
 {"Clasped Mitts", ItemType.Gloves},
 {"Mesh Gloves", ItemType.Gloves},
 {"Nubuck Gloves", ItemType.Gloves},
 {"Steel Gauntlets", ItemType.Gloves},
 {"Steelscale Gauntlets", ItemType.Gloves},
 {"Embroidered Gloves", ItemType.Gloves},
 {"Trapper Mitts", ItemType.Gloves},
 {"Riveted Gloves", ItemType.Gloves},
 {"Eelskin Gloves", ItemType.Gloves},
 {"Antique Gauntlets", ItemType.Gloves},
 {"Satin Gloves", ItemType.Gloves},
 {"Zealot Gloves", ItemType.Gloves},
 {"Serpentscale Gauntlets", ItemType.Gloves},
 {"Sharkskin Gloves", ItemType.Gloves},
 {"Ambush Mitts", ItemType.Gloves},
 {"Samite Gloves", ItemType.Gloves},
 {"Ancient Gauntlets", ItemType.Gloves},
 {"Wyrmscale Gauntlets", ItemType.Gloves},
 {"Carnal Mitts", ItemType.Gloves},
 {"Horseman's Gloves", ItemType.Gloves},
 {"Soldier's Gloves", ItemType.Gloves},
 {"Soldier Gloves", ItemType.Gloves},
 {"Legion Gloves", ItemType.Gloves},
 {"Goliath Gauntlets", ItemType.Gloves},
 {"Shagreen Gloves", ItemType.Gloves},
 {"Conjurer Gloves", ItemType.Gloves},
 {"Cavalry Gloves", ItemType.Gloves},
 {"Assassin's Mitts", ItemType.Gloves},
 {"Hydrascale Gauntlets", ItemType.Gloves},
 {"Arcanist Gloves", ItemType.Gloves},
 {"Stealth Gloves", ItemType.Gloves},
 {"Vaal Gauntlets", ItemType.Gloves},
 {"Crusader Gloves", ItemType.Gloves},
 {"Dragonscale Gauntlets", ItemType.Gloves},
 {"Murder Mitts", ItemType.Gloves},
 {"Titan Gauntlets", ItemType.Gloves},
 {"Sorcerer Gloves", ItemType.Gloves},
 {"Slink Gloves", ItemType.Gloves},
 {"Rusted Casque", ItemType.Helmet},
 {"Vine Circlet", ItemType.Helmet},
 {"Battered Cap", ItemType.Helmet},
 {"Tarnished Mask", ItemType.Helmet},
 {"Rusted Helmet", ItemType.Helmet},
 {"Corroded Chain Coif", ItemType.Helmet},
 {"Footman's Casque", ItemType.Helmet},
 {"Copper Circlet", ItemType.Helmet},
 {"Wooden Mask", ItemType.Helmet},
 {"Leather Cap", ItemType.Helmet},
 {"Chainmail Coif", ItemType.Helmet},
 {"Flanged Helmet", ItemType.Helmet},
 {"Tribal Circlet", ItemType.Helmet},
 {"Copper Mask", ItemType.Helmet},
 {"Gladiator Casque", ItemType.Helmet},
 {"Leather Hood", ItemType.Helmet},
 {"Ringmail Coif", ItemType.Helmet},
 {"Ribbed Helmet", ItemType.Helmet},
 {"Executioner Casque", ItemType.Helmet},
 {"Gemmed Circlet", ItemType.Helmet},
 {"Ceremonial Mask", ItemType.Helmet},
 {"Studded Hood", ItemType.Helmet},
 {"Inlaid Chain Coif", ItemType.Helmet},
 {"Gilded Helmet", ItemType.Helmet},
 {"Gilded Circlet", ItemType.Helmet},
 {"Bandit Mask", ItemType.Helmet},
 {"Imperial Casque", ItemType.Helmet},
 {"Coolus Helmet", ItemType.Helmet},
 {"Woven Ring Coif", ItemType.Helmet},
 {"Iron Mask", ItemType.Helmet},
 {"Carved Circlet", ItemType.Helmet},
 {"Reaver Casque", ItemType.Helmet},
 {"Hunter Cap", ItemType.Helmet},
 {"Finned Helmet", ItemType.Helmet},
 {"Mesh Chain Coif", ItemType.Helmet},
 {"Heathen Mask", ItemType.Helmet},
 {"Forest Hood", ItemType.Helmet},
 {"Encrusted Circlet", ItemType.Helmet},
 {"Mercenary Casque", ItemType.Helmet},
 {"Ornate Helmet", ItemType.Helmet},
 {"Assassin Mask", ItemType.Helmet},
 {"Zealot's Chain Coif", ItemType.Helmet},
 {"Gleaming Circlet", ItemType.Helmet},
 {"Grove Hood", ItemType.Helmet},
 {"Vaal Casque", ItemType.Helmet},
 {"Steel Mask", ItemType.Helmet},
 {"Commander's Ring Coif", ItemType.Helmet},
 {"Polished Helmet", ItemType.Helmet},
 {"Petrified Circlet", ItemType.Helmet},
 {"Destroyer Casque", ItemType.Helmet},
 {"Huntress Cap", ItemType.Helmet},
 {"Pagan Mask", ItemType.Helmet},
 {"Crusader's Chain Coif", ItemType.Helmet},
 {"Bladed Helmet", ItemType.Helmet},
 {"Thicket Hood", ItemType.Helmet},
 {"Annihilator Casque", ItemType.Helmet},
 {"Royal Circlet", ItemType.Helmet},
 {"Crested Helmet", ItemType.Helmet},
 {"Murder Mask", ItemType.Helmet},
 {"Imperial Chain Coif", ItemType.Helmet},
 {"Ezomyte Circlet", ItemType.Helmet},
 {"Armageddon Casque", ItemType.Helmet},
 {"Jungle Hood", ItemType.Helmet},
 {"Splintered Tower Shield", ItemType.Shield},
 {"Goathide Buckler", ItemType.Shield},
 {"Twig Spirit Shield", ItemType.Shield},
 {"Rotted Round Shield", ItemType.Shield},
 {"Corroded Tower Shield", ItemType.Shield},
 {"Spiked Bundle", ItemType.Shield},
 {"Plank Kite Shield", ItemType.Shield},
 {"Pine Buckler", ItemType.Shield},
 {"Yew Spirit Shield", ItemType.Shield},
 {"Rawhide Tower Shield", ItemType.Shield},
 {"Driftwood Spiked Shield", ItemType.Shield},
 {"Fir Round Shield", ItemType.Shield},
 {"Linden Kite Shield", ItemType.Shield},
 {"Bone Spirit Shield", ItemType.Shield},
 {"Painted Buckler", ItemType.Shield},
 {"Cedar Tower Shield", ItemType.Shield},
 {"Alloyed Spike Shield", ItemType.Shield},
 {"Studded Round Shield", ItemType.Shield},
 {"Reinforced Kite Shield", ItemType.Shield},
 {"Hammered Buckler", ItemType.Shield},
 {"Tarnished Spirit Shield", ItemType.Shield},
 {"Copper Tower Shield", ItemType.Shield},
 {"Burnished Spike Shield", ItemType.Shield},
 {"Layered Kite Shield", ItemType.Shield},
 {"Scarlet Round Shield", ItemType.Shield},
 {"Jingling Spirit Shield", ItemType.Shield},
 {"War Buckler", ItemType.Shield},
 {"Reinforced Tower Shield", ItemType.Shield},
 {"Ornate Spiked Shield", ItemType.Shield},
 {"Brass Spirit Shield", ItemType.Shield},
 {"Splendid Round Shield", ItemType.Shield},
 {"Gilded Buckler", ItemType.Shield},
 {"Ceremonial Kite Shield", ItemType.Shield},
 {"Painted Tower Shield", ItemType.Shield},
 {"Walnut Spirit Shield", ItemType.Shield},
 {"Oak Buckler", ItemType.Shield},
 {"Redwood Spiked Shield", ItemType.Shield},
 {"Maple Round Shield", ItemType.Shield},
 {"Buckskin Tower Shield", ItemType.Shield},
 {"Etched Shield", ItemType.Shield},
 {"Ivory Spirit Shield", ItemType.Shield},
 {"Enameled Buckler", ItemType.Shield},
 {"Mahogany Tower Shield", ItemType.Shield},
 {"Ancient Spirit Shield", ItemType.Shield},
 {"Compound Spiked Shield", ItemType.Shield},
 {"Spiked Round Shield", ItemType.Shield},
 {"Corrugated Buckler", ItemType.Shield},
 {"Steel Kite Shield", ItemType.Shield},
 {"Bronze Tower Shield", ItemType.Shield},
 {"Chiming Spirit Shield", ItemType.Shield},
 {"Polished Spiked Shield", ItemType.Shield},
 {"Crimson Round Shield", ItemType.Shield},
 {"Laminated Kite Shield", ItemType.Shield},
 {"Battle Buckler", ItemType.Shield},
 {"Salvaged Buckler", ItemType.Shield},
 {"Girded Tower Shield", ItemType.Shield},
 {"Thorium Spirit Shield", ItemType.Shield},
 {"Sovereign Spiked Shield", ItemType.Shield},
 {"Baroque Round Shield", ItemType.Shield},
 {"Golden Buckler", ItemType.Shield},
 {"Angel Kite Shield", ItemType.Shield},
 {"Angelic Kite Shield", ItemType.Shield},
 {"Crested Tower Shield", ItemType.Shield},
 {"Lacewood Spirit Shield", ItemType.Shield},
 {"Ironwood Buckler", ItemType.Shield},
 {"Shagreen Tower Shield", ItemType.Shield},
 {"Teak Round Shield", ItemType.Shield},
 {"Alder Spike Shield", ItemType.Shield},
 {"Fossilized Spirit Shield", ItemType.Shield},
 {"Branded Kite Shield", ItemType.Shield},
 {"Lacquered Buckler", ItemType.Shield},
 {"Hunting Shield", ItemType.Shield},
 {"Ebony Tower Shield", ItemType.Shield},
 {"Ezomyte Spiked Shield", ItemType.Shield},
 {"Vaal Spirit Shield", ItemType.Shield},
 {"Spiny Round Shield", ItemType.Shield},
 {"Champion Kite Shield", ItemType.Shield},
 {"Vaal Buckler", ItemType.Shield},
 {"Ezomyte Tower Shield", ItemType.Shield},
 {"Harmonic Spirit Shield", ItemType.Shield},
 {"Mosaic Kite Shield", ItemType.Shield},
 {"Mirrored Spiked Shield", ItemType.Shield},
 {"Crusader Buckler", ItemType.Shield},
 {"Cardinal Round Shield", ItemType.Shield},
 {"Colossal Tower Shield", ItemType.Shield},
 {"Archon Kite Shield", ItemType.Shield},
 {"Titanium Spirit Shield", ItemType.Shield},
 {"Wood Focus", ItemType.Shield},
 {"Tribal Kite Shield", ItemType.Shield},
 {"Salvaged Shield", ItemType.Shield},
 {"Bone Focus", ItemType.Shield},
 {"Driftwood Shield", ItemType.Shield},
 {"Imperial Buckler", ItemType.Shield},
 {"Elegant Round Shield", ItemType.Shield},
 {"Supreme Spiked Shield", ItemType.Shield},
 {"Pinnacle Tower Shield", ItemType.Shield},
 {"Paua Amulet", ItemType.Amulet},
 {"Coral Amulet", ItemType.Amulet},
 {"Jade Amulet", ItemType.Amulet},
 {"Amber Amulet", ItemType.Amulet},
 {"Lapis Amulet", ItemType.Amulet},
 {"Gold Amulet", ItemType.Amulet},
 {"Onyx Amulet", ItemType.Amulet},
 {"Chain Belt", ItemType.Belt},
 {"Rustic Sash", ItemType.Belt},
 {"Leather Belt", ItemType.Belt},
 {"Heavy Belt", ItemType.Belt},
 {"Studded Belt", ItemType.Belt},
 {"Cloth Belt", ItemType.Belt},
 {"Coral Ring", ItemType.Ring},
 {"Prismatic Ring", ItemType.Ring},
 {"Paua Ring", ItemType.Ring},
 {"Iron Ring", ItemType.Ring},
 {"Sapphire Ring", ItemType.Ring},
 {"Gold Ring", ItemType.Ring},
 {"Ruby Ring", ItemType.Ring},
 {"Topaz Ring", ItemType.Ring},
 {"Conductive Quiver", ItemType.Quiver},
 {"Arachnid Nest Map", ItemType.Map},
 {"Bog Map", ItemType.Map},
 {"Canyon Map", ItemType.Map},
 {"Catacomb Map", ItemType.Map},
 {"Cells Map", ItemType.Map},
 {"Cemetery Map", ItemType.Map},
 {"Coves Map", ItemType.Map},
 {"Crematorium Map", ItemType.Map},
 {"Crypt Map", ItemType.Map},
 {"Dark Forest Map", ItemType.Map},
 {"Dried Lake Map", ItemType.Map},
 {"Dry Peninsula Map", ItemType.Map},
 {"Dry Woods Map", ItemType.Map},
 {"Dunes Map", ItemType.Map},
 {"Dungeon Map", ItemType.Map},
 {"Gorge Map", ItemType.Map},
 {"Graveyard Map", ItemType.Map},
 {"Grotto Map", ItemType.Map},
 {"Jungle Valley Map", ItemType.Map},
 {"Marsh Map", ItemType.Map},
 {"Maze Map", ItemType.Map},
 {"Mine Map", ItemType.Map},
 {"Mountain Ledge Map", ItemType.Map},
 {"Mud Geyser Map", ItemType.Map},
 {"Necropolis Map", ItemType.Map},
 {"Overgrown Ruin Map", ItemType.Map},
 {"Overgrown Shrine Map", ItemType.Map},
 {"Plateau Map", ItemType.Map},
 {"Reef Map", ItemType.Map},
 {"Sewer Map", ItemType.Map},
 {"Shore Map", ItemType.Map},
 {"Spider Forest Map", ItemType.Map},
 {"Spider Lair Map", ItemType.Map},
 {"Springs Map", ItemType.Map},
 {"Strand Map", ItemType.Map},
 {"Subterranean Stream Map", ItemType.Map},
 {"Thicket Map", ItemType.Map},
 {"Tomb Map", ItemType.Map},
 {"Torture Chamber Map", ItemType.Map},
 {"Tropical Island Map", ItemType.Map},
 {"Tunnel Map", ItemType.Map},
 {"Underground River Map", ItemType.Map},
 {"Underground Sea Map", ItemType.Map},
 {"Vaal Pyramid Map", ItemType.Map},
 {"Vaults of Atziri Map", ItemType.Map},
 {"Waste Pool Map", ItemType.Map}
 #endregion
};*/
