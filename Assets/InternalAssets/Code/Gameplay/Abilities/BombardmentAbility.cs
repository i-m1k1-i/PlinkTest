using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombardmentAbility : Ability
{
    [SerializeField] private Sprite _abilityIcon;
    [SerializeField] private int _cooldown;

    [SerializeField] private GameObject _spawnPointsParentPrefab;

    private PlayerAttackSystem _playerAttackSystem;
    private List<Vector3> _spawnPoints = new List<Vector3>();

    public override float Cooldown => _cooldown;
    public override Sprite AbilityIcon => _abilityIcon;

    private Vector3 SpawnPoint => Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height + 1.5f, 10));

    public static event UnityAction OnBombardment;

    private void Start()
    {
        _playerAttackSystem = FindAnyObjectByType<PlayerAttackSystem>();

        GameObject spawnPointsParent = Instantiate(_spawnPointsParentPrefab, SpawnPoint, Quaternion.identity);
        Transform[] spawnPointTransforms = spawnPointsParent.GetComponentsInChildren<Transform>();
        foreach (Transform t in spawnPointTransforms)
        {
            _spawnPoints.Add(t.position);
        }
    }

    public override void Use()
    {
        SpawnProjectiles();
        OnBombardment?.Invoke();
    }

    private void SpawnProjectiles()
    {
        foreach (Vector3 position in _spawnPoints)
        {
            Projectile projectile = _playerAttackSystem.GetProjectile();
            projectile.transform.position = position;
        }
    }
}
