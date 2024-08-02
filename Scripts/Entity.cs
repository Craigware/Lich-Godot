using Godot;

namespace Entities 
{
    public enum EntityArchetypes {
        PLAYER
    }

    [Tool]
    [GlobalClass]
    public partial class Entity : Resource
    {
        [Export] public EntityArchetypes Archetype;
        [Export] public Texture2D SpriteSheet;
        [Export] public Stats BaseStats;
        
        public Entity() : this(EntityArchetypes.PLAYER, null, null) {}
        public Entity(
            EntityArchetypes archetype,
            Texture2D spritesheet,
            Stats basestats
        ) {
            Archetype = archetype;
            SpriteSheet = spritesheet;
            BaseStats = basestats;
        }
    }
}