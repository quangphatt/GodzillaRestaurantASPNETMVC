namespace GodzillaRestaurant.Models
{
    public class ManageItem
    {
        public string Name { get; set; }
        public int ItemCount { get; set; }
        public string Icon { get; set; }

        public ManageItem(string name, int itemCount,string icon)
        {
            Name = name;
            ItemCount = itemCount;
            Icon = icon;
        }
    }
}
