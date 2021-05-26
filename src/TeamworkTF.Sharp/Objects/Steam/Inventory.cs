using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamworkTF.Sharp
{
    public class Inventory
    {
        [JsonProperty("result")]
        public UserItems Result { get; set; }
    }

    public class UserItems
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("num_backpack_slots")]
        public int NumBackpackSlots { get; set; }

        [JsonProperty("items")]
        public List<UserItem> Items { get; set; }
    }

    public class UserItem
    {
        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("original_id")]
        public object OriginalId { get; set; }

        [JsonProperty("defindex")]
        public int Defindex { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("inventory")]
        public object Inventory { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("origin")]
        public int Origin { get; set; }

        [JsonProperty("equipped")]
        public List<ItemEquipped> Equipped { get; set; }

        [JsonProperty("flag_cannot_trade")]
        public bool FlagCannotTrade { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("style")]
        public int? Style { get; set; }

        [JsonProperty("flag_cannot_craft")]
        public bool? FlagCannotCraft { get; set; }
    }

    public class ItemEquipped
    {
        [JsonProperty("class")]
        public int Class { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public class ItemAttribute
    {
        [JsonProperty("defindex")]
        public int Defindex { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("float_value")]
        public double FloatValue { get; set; }
    }
}