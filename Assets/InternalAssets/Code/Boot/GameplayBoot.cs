using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayBoot : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicClips;

    [Space(15f)]

    public Image BGImage;
    public Sprite[] BGSprites;

    [Space(15f)]

    public GameObject[] BossPrefabs;
    public Transform bossRoot;

    [Space(15f)]

    [SerializeField] private Ability[] _abilityPrefabs;
    [SerializeField] private PlayerAbilitySystem _abilitySystem;

    public static int BGToLoad = 0;
    public static int BossToLoad = 0;
    public static int LevelID = 1;
    public static int MusicToLoad = 0;
    public static int AbilityToLoad = 0;

    private void Start()
    {
        BGImage.sprite = BGSprites[BGToLoad];
        Instantiate(BossPrefabs[BossToLoad], bossRoot.transform.position, Quaternion.identity);
        musicSource.clip = musicClips[MusicToLoad];
        musicSource.Play();

        Ability ability = Instantiate(_abilityPrefabs[AbilityToLoad], Vector3.zero, Quaternion.identity);
        _abilitySystem.SetAbility(ability);
    }

    public void OpenLevel()
    {
        Debug.Log("Unlock new level");
        if (LevelID >= SaveDataManager.CompletedLevels)
        SaveDataManager.UnlockNewLevel();
    }

    public void LoadNext()
    {
        LevelID++;
        BossToLoad++;

        if (LevelID > 4) { SceneHelper.LoadScene(ProjectScene.Menu); return; }
        if (BossToLoad > 2) BossToLoad = 0;

        SceneHelper.LoadScene(ProjectScene.Gameplay); return;
    }
}
