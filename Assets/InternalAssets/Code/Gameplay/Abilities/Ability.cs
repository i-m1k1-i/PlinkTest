using UnityEngine;

public abstract class Ability : MonoBehaviour, IAbility
{
    public abstract float Cooldown { get; }
    public abstract Sprite AbilityIcon { get; }

    public abstract void Use();
}
