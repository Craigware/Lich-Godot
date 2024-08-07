using Godot;

namespace Entities
{
	[GlobalClass]
	public partial class Item : Resource
	{
		[Export] public string Name;
        [Export] public Texture2D Sprite;
	    
        public Item() : this("",null) {}
		public Item(
			string name,
            Texture2D sprite
		) {
			Name = name;
            Sprite = sprite;
		}
	}
}