
namespace TheCoreBattle
{
    public class CharacterActionsHandler
    {
        public DoNothing DoNothingAction { get; } = new DoNothing();
        public UsePotion UsePotionAction { get; } = new UsePotion();
        public BasicAttackAction UseBasicAction => new BasicAttackAction();
        public GearAttack UseGearAction => new GearAttack();
        public ItemInteractions EquipItems { get; } = new ItemInteractions();

    }
}
