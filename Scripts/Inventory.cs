using System.Runtime.InteropServices;
using Godot;

namespace Entities
{
	[GlobalClass]
	public partial class Inventory : Resource
	{
		[Export] InventoryItem[] inventory = new InventoryItem[25];
		public int SelectedIndex = 0;

		public InventoryItem[] Get() {
			return inventory;
		}

        public Item GetSelectedItem() {
            var invItem = inventory[SelectedIndex];
            if (invItem == null) return null;
            return invItem.Item;
        }

        public bool MoveItem(Item item, int newIndex) {
            if (newIndex > inventory.Length - 1) return false;
            int currentIndex = 0;
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i].Item == item) {
                    currentIndex = i;
                }    
            }
            (inventory[currentIndex], inventory[newIndex]) = (inventory[newIndex], inventory[currentIndex]);
            return true;
        }

        public void ResizeInventory(int amount) {
            InventoryItem[] newInventory = new InventoryItem[amount];

            // This will break if the new inventory is smaller than the old
            // If there is a backpack mechanic or something added this will need to change
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] != null) {
                    newInventory[i] = inventory[i];
                }
            }

            inventory = newInventory;
        }

        public void AddItemToInventory(Item item, int amount=1) {
            if (item == null) return;
            foreach(var inventoryItem in inventory) {
                if (inventoryItem == null) continue;
                if (inventoryItem.Item == item) {
                    inventoryItem.Count+=amount;
                    GD.Print("Item incremented in inventory");
                    return;
                }
            }

            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] == null) {
                    inventory[i] = new InventoryItem(item, amount);
                    return;
                }
            }
        }
        public void Add(Item item, int amount=1) {
            AddItemToInventory(item, amount);
        }

        public void RemoveItemFromInventory(Item item, int amount=1) {
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i].Item == item) {
                    inventory[i].Count -= amount;
                    if (inventory[i].Count <= 0) {
                        if (inventory[i].Count < 0) {
                            GD.Print("More items have been removed from the inventory than it contained");
                        }
                        inventory[i] = null;
                    }
                    return;
                }
            }
        }
        public void Remove(Item item, int amount=1) {
            RemoveItemFromInventory(item, amount);
        }

        public bool ContainsItem(Item item) {
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i].Item == item) return true;
            }
            return false;
        }
	}
}