using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class Schema
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("items_game_url")]
        public string ItemsGameUrl { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("next")]
        public int Next { get; set; }
    }

    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("defindex")]
        public int Defindex { get; set; }

        [JsonProperty("item_class")]
        public string ItemClass { get; set; }

        [JsonProperty("item_type_name")]
        public string ItemTypeName { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("proper_name")]
        public bool ProperName { get; set; }

        [JsonProperty("item_slot")]
        public string ItemSlot { get; set; }

        [JsonProperty("model_player")]
        public string ModelPlayer { get; set; }

        [JsonProperty("item_quality")]
        public int ItemQuality { get; set; }

        [JsonProperty("image_inventory")]
        public string ImageInventory { get; set; }

        [JsonProperty("min_ilevel")]
        public int MinIlevel { get; set; }

        [JsonProperty("max_ilevel")]
        public int MaxIlevel { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("image_url_large")]
        public string ImageUrlLarge { get; set; }

        [JsonProperty("craft_class")]
        public string CraftClass { get; set; }

        [JsonProperty("craft_material_type")]
        public string CraftMaterialType { get; set; }

        [JsonProperty("capabilities")]
        public Capabilities Capabilities { get; set; }

        [JsonProperty("used_by_classes")]
        public List<string> UsedByClasses { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("styles")]
        public List<Style> Styles { get; set; }

        [JsonProperty("attributes")]
        public List<System.Attribute> Attributes { get; set; }

        [JsonProperty("drop_type")]
        public string DropType { get; set; }
    }

    public class Capabilities
    {
        [JsonProperty("nameable")]
        public bool Nameable { get; set; }

        [JsonProperty("can_gift_wrap")]
        public bool CanGiftWrap { get; set; }

        [JsonProperty("can_craft_mark")]
        public bool CanCraftMark { get; set; }

        [JsonProperty("can_be_restored")]
        public bool CanBeRestored { get; set; }

        [JsonProperty("strange_parts")]
        public bool StrangeParts { get; set; }

        [JsonProperty("can_card_upgrade")]
        public bool CanCardUpgrade { get; set; }

        [JsonProperty("can_strangify")]
        public bool CanStrangify { get; set; }

        [JsonProperty("can_killstreakify")]
        public bool CanKillstreakify { get; set; }

        [JsonProperty("can_consume")]
        public bool CanConsume { get; set; }

        [JsonProperty("can_collect")]
        public bool? CanCollect { get; set; }

        [JsonProperty("paintable")]
        public bool? Paintable { get; set; }

        [JsonProperty("can_craft_if_purchased")]
        public bool? CanCraftIfPurchased { get; set; }
    }

    public class AdditionalHiddenBodygroups
    {
        [JsonProperty("hat")]
        public int Hat { get; set; }

        [JsonProperty("headphones")]
        public int Headphones { get; set; }
    }

    public class Style
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("additional_hidden_bodygroups")]
        public AdditionalHiddenBodygroups AdditionalHiddenBodygroups { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}