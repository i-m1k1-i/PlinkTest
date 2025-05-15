using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FreezeAbilityView : MonoBehaviour
{
    [SerializeField] private Canvas _frozenCanvasPrefab;

    private Image _frozenSpriteImage;

    private void Start()
    {
        Canvas frozenCanvas = Instantiate(_frozenCanvasPrefab, transform);
        _frozenSpriteImage = frozenCanvas.GetComponentInChildren<Image>();
        _frozenSpriteImage.color = new Color(1, 1, 1, 0);
    }

    private void OnEnable()
    {
        FreezeAbility.OnFreeze += ShowFroze;
        FreezeAbility.OnFreezeEnd += HideFroze;
    }

    private void OnDisable()
    {
        FreezeAbility.OnFreeze -= ShowFroze;
        FreezeAbility.OnFreezeEnd -= HideFroze;
    }

    private void ShowFroze()
    {
        _frozenSpriteImage.enabled = true;
        _frozenSpriteImage.DOFade(1, 0.5f);
    }

    private void HideFroze()
    {
        _frozenSpriteImage.DOFade(0, 0.5f)
            .OnComplete(() => _frozenSpriteImage.enabled = false);
    }
}
