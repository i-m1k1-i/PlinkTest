using TMPro;
using UnityEngine;

public class AbilityCooldownView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _cooldownBackground;
    [SerializeField] private TextMeshProUGUI _cooldown;

    public void Enable()
    {
        _cooldownBackground.enabled = true;
        _cooldown.enabled = true;
    }

    public void Disable()
    {
        _cooldownBackground.enabled = false;
        _cooldown.enabled = false;
    }

    public void UpdateText(int cooldown)
    {
        _cooldown.text = cooldown.ToString();
    }
}
