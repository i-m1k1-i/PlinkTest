using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FreezeAbility : Ability
{
    [SerializeField] private Sprite _abilityIcon;

    [SerializeField] private int _cooldown;
    [SerializeField] private float _freezeDuration;

    private float _freezeTimer;
    private bool _isFrozen;

    public override float Cooldown => _cooldown;
    public override Sprite AbilityIcon => _abilityIcon;

    public static event UnityAction OnFreeze;
    public static event UnityAction OnFreezeEnd;

    public override void Use()
    {
        OnFreeze?.Invoke();
        _isFrozen = true;
    }

    private void Update()
    {
        if (PauseManager.Paused)
            return;
        if (_isFrozen == false) 
            return;

        if (_freezeTimer < _freezeDuration)
        {
            _freezeTimer += Time.deltaTime;
        }
        else
        {
            _freezeTimer = 0;
            _isFrozen = false;
            OnFreezeEnd?.Invoke();
        }
    }
}
