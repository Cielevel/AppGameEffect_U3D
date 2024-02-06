// log
// -2024/2/6-
// TODO 可能需要考虑分离出多个种类的Type？
// ==> 但统一枚举变量更灵活，每种角色使用同一个枚举来判断行为种类
// ==> 它们使用的范围不同（范围则需要限制）
///// * 目前使用统一的BehaviorType，并给定扩展方法（扩展后续可能影响到加入的角色的type enum上）
///// * ==> 如：public static CharacterType BehaviorBelongToCharacter(this BehaviorType type)

namespace TopDownGunShoot
{
    public static class BehaviorTypeExtension
    {
        // const--区间信息
        const int sharedBegin = 1, sharedEnd = 3;

        public static bool IsSharedBehavior(this BehaviorType type)
        {
            return sharedBegin <= (int)type && (int)type <= sharedEnd;
        }
    }

    public enum BehaviorType
    {
        none,

        #region Shared behavior type
        move,
        attack,
        interact,
        #endregion

        #region Own-Human behavior type

        #endregion

        #region Own-Vampires behavior type

        #endregion
    }
}