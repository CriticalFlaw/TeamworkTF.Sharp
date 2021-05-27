using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    public class Steam
    {
        [JsonProperty("result")] public Store Store { get; set; }
    }

    public class Store
    {
        [JsonProperty("carousel_data")] public Carousel Carousel { get; set; }

        [JsonProperty("tabs")] public List<Tab> Tabs { get; set; }

        [JsonProperty("filters")] public List<Filter> Filters { get; set; }

        [JsonProperty("sorting")] public Sorting Sorting { get; set; }

        [JsonProperty("dropdown_data")] public DropdownData Dropdown { get; set; }

        [JsonProperty("player_class_data")] public List<PlayerData> PlayerData { get; set; }

        [JsonProperty("home_page_data")] public HomePage HomePage { get; set; }
    }

    public class Carousel
    {
        [JsonProperty("max_display_banners")] public int MaxBanners { get; set; }

        [JsonProperty("banners")] public List<Banner> Banners { get; set; }
    }

    public class Tab
    {
        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("parent_id")] public object ParentId { get; set; }

        [JsonProperty("use_large_cells")] public bool UseLargeCells { get; set; }

        [JsonProperty("default")] public bool Default { get; set; }

        [JsonProperty("children")] public List<Child> Children { get; set; }

        [JsonProperty("home")] public bool Home { get; set; }

        [JsonProperty("dropdown_prefab_id")] public long? DropdownId { get; set; }

        [JsonProperty("parent_name")] public string ParentName { get; set; }
    }

    public class Filter
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistory { get; set; }

        [JsonProperty("all_element")] public AllElement AllElement { get; set; }

        [JsonProperty("elements")] public List<Element> Elements { get; set; }

        [JsonProperty("count")] public int Count { get; set; }
    }

    public class Sorting
    {
        [JsonProperty("sorters")] public List<Sorter> Sorters { get; set; }

        [JsonProperty("sorting_prefabs")] public List<SortingPrefab> SortingPrefabs { get; set; }
    }

    public class DropdownData
    {
        [JsonProperty("dropdowns")] public List<Dropdown> Dropdowns { get; set; }

        [JsonProperty("prefabs")] public List<Prefab> Prefabs { get; set; }
    }

    public class PlayerData
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("base_name")] public string BaseName { get; set; }

        [JsonProperty("localized_text")] public string LocalizedText { get; set; }
    }

    public class HomePage
    {
        [JsonProperty("home_category_id")] public int HomeCategoryId { get; set; }

        [JsonProperty("popular_items")] public List<PopularItem> PopularItems { get; set; }
    }

    public class Banner
    {
        [JsonProperty("basefilename")] public string BaseFileName { get; set; }

        [JsonProperty("action")] public string Action { get; set; }

        [JsonProperty("placement")] public string Placement { get; set; }

        [JsonProperty("action_param")] public string ActionParam { get; set; }
    }

    public class Child
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }

    public class AllElement
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("localized_text")] public string LocalizedText { get; set; }
    }

    public class Element
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("localized_text")] public string LocalizedText { get; set; }

        [JsonProperty("id")] public int Id { get; set; }
    }

    public class Sorter
    {
        [JsonProperty("id")] public object Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("data_type")] public string DataType { get; set; }

        [JsonProperty("sort_field")] public string SortField { get; set; }

        [JsonProperty("sort_reversed")] public bool SortReversed { get; set; }

        [JsonProperty("localized_text")] public string LocalizedText { get; set; }
    }

    public class SortingPrefab
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistory { get; set; }

        [JsonProperty("sorter_ids")] public List<SorterId> SorterIds { get; set; }
    }

    public class SorterId
    {
        [JsonProperty("id")] public object Id { get; set; }
    }

    public class PopularItem
    {
        [JsonProperty("def_index")] public int DefIndex { get; set; }

        [JsonProperty("order")] public int Order { get; set; }
    }

    public class Dropdown
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("label_text")] public string LabelText { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistory { get; set; }
    }

    public class Config
    {
        [JsonProperty("dropdown_id")] public object DropdownId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("enabled")] public bool Enabled { get; set; }

        [JsonProperty("default_selection_id")] public object DefaultSelectionId { get; set; }
    }

    public class Prefab
    {
        [JsonProperty("id")] public object Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("config")] public List<Config> Config { get; set; }
    }

    public class Price
    {
        [JsonProperty("success")] public bool Success { get; set; }

        [JsonProperty("lowest_price")] public string LowestPrice { get; set; }

        [JsonProperty("volume")] public string Volume { get; set; }

        [JsonProperty("median_price")] public string MedianPrice { get; set; }
    }
}