using Godot;

namespace Entities
{
	public enum ItemType
	{
		DROP,
		WEAPON
	}

	[Tool]
	[GlobalClass]
	public partial class Item : Resource
	{
		[Export] public string Name;
		[Export] public ItemType ItemType;

		public Item() : this("",0) {}
		public Item(
			string name,
			ItemType itemtype
		) {
			Name = name;
			ItemType = itemtype;
		}
	}
}