using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilitySystem : MonoBehaviour
{
    [SerializeField] private AbilityCooldownView _cooldownView;
    [SerializeField] private Image _abilityIconImage;

    private IAbility _ability;
    private float _cooldown = 0;
    private bool _canUse = true;

    private void Start()
    {
        _cooldownView.Disable();
    }

    public void SetAbility(Ability ability)
    {
        _ability = ability;
        _abilityIconImage.sprite = ability.AbilityIcon;
    }

    public void UseAbility()
    {
        if (_canUse == false)
        {
            return;
        }

        _ability.Use();
        _cooldown = _ability.Cooldown;
    }

    private void Update()
    {
        if (PauseManager.Paused) 
            return;

        if (_cooldown > 0)
        {
            if (_canUse == true) 
            {
                _canUse = false;
                _cooldownView.Enable();
            }

            _cooldown -= Time.deltaTime;

            _cooldownView.UpdateText((int)_cooldown);
        }
        else if (_canUse == false)
        {
            _canUse = true;
            _cooldownView.Disable();
        }
    }
}
