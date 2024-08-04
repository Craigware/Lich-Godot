using Godot;

namespace Entities 
{
    [GlobalClass]
    public partial class Entity : Resource
    {
        [Export] public string Name;
        [Export] public Stats BaseStats;
        
        public Entity() : this("", null) {}
        public Entity(
            string name,
            Stats basestats
        ) {
            Name = name;
            BaseStats = basestats;
        }
    }
}