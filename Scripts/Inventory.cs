using Godot;

namespace Entities
{
	[GlobalClass]
	public partial class Inventory : Node
	{
		Godot.Collections.Dictionary<Item, int> inventory;
		public Godot.Collections.Array<Item> Hotbar;
		public Item Selected;

		public Inventory() {
			inventory = new();
			Hotbar = new();
			Selected = null;
		}
		
		public Godot.Collections.Dictionary<Item, int> Get() {
			return inventory;
		}

		public void AddItem(Item item) {
			if (inventory.ContainsKey(item)) {
				inventory[item]++;
			} else {
				inventory.Add(item, 1);
			}
		}

		public bool RemoveItem(Item item) {
			if (inventory.ContainsKey(item)) {
				inventory[item]--;
				if (inventory[item] <= 0) {
					inventory.Remove(item);
				}
				return true;
			}
			return false;
		}
	}
}