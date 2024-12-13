using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] private Transform _defaultSpawn;
    [SerializeField] private Transform[] _bulletModifiedSpawns;

    [SerializeField] private float nextFireTime = 0f;

    [Header("Player Data | Scriptable Object")]
    [SerializeField] private PlayerData _playerData;

    [Header("Sound settings")]
    [SerializeField] private SoundManager _soundManager;

    private PlayerPrefsSystem _playerPS;

    private void Start()
    {
        _playerPS = GetComponentInParent<PlayerPrefsSystem>();
    }

    private void Update()
    {
        UpdateNextFireTime();
    }
    public void Spawn(GameObject bulletPrefab, Transform[] bulletSpawners)
    {
        Bullet bulletScript = bulletPrefab.GetComponent<Bullet>();
        if (_playerData.BulletCount >= 2)
        {
            foreach (Transform bulletSpawner in bulletSpawners)
            {
                StartCoroutine(Spawner(bulletPrefab, bulletSpawner));
            }
        }
        else
        {
            StartCoroutine(Spawner(bulletPrefab, _defaultSpawn));
        }
    }
    private void UpdateNextFireTime()
    {
        if (Time.time >= nextFireTime)
        {
            Spawn(_bulletPrefab, _bulletModifiedSpawns);
            nextFireTime = Time.time + _playerData.FireRate;
        }
    }

    IEnumerator Spawner(GameObject bulletPrefab, Transform bulletSpawner)
    {
        yield return new WaitForSeconds(1);
        GameObject bullet = BulletPool.Instance.GetFromPool(bulletSpawner.transform.position);
        _soundManager.ShootingClip();
    }
}
