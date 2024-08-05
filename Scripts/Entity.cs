using Godot;

namespace Entities 
{
    public enum EntityType {
        NIL,
        PLAYER,
        SKELETON
    }

    [GlobalClass]
    public partial class Entity : Resource
    {
        [Export] public string Name;
        [Export] public EntityType EntityType;
        [Export] public Stats BaseStats;
        
        public Entity() : this("", EntityType.NIL, null) {}
        public Entity(
            string name,
            EntityType entitytype,
            Stats basestats
        ) {
            Name = name;
            EntityType = entitytype;
            BaseStats = basestats;
        }
    }
}