using Godot;
namespace Entities
{
    [GlobalClass]
    public partial class InventoryItem : Resource {
        [Export] public Item Item;
        [Export] public int Count;

        public InventoryItem() : this(null, 0) {}
        public InventoryItem(
            Item item,
            int count
        ) {
            Item = item;
            Count = count;
        }
    }
}