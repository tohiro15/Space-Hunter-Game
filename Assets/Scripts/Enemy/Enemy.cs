using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private bool _isHit = false;

    private EnemyController _controller;
    private PlayerPrefsSystem _playerPS;
    private SoundManager _soundManager;
    private EnemyPool _enemyPool;

    private void Start()
    {
        _controller = GetComponentInChildren<EnemyController>();
    }

    private void Update()
    {
        _controller.Movement(_speed, gameObject, _enemyPool);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !_isHit) // �������� ���������
        {
            _isHit = true; // ��������, ��� ���� ��� �������
            HandleHit(); // ��������� ���������

            // ����� ���������� ����:
            Destroy(collision.gameObject);
        }
    }

    public void HandleHit()
    {
        // ������ ��� ��������� ��������� (��������, ����������� � ���)
        _enemyPool.ReturnEnemy(gameObject);
    }

    // ����� ����� ���������
    public void ResetHit()
    {
        _isHit = false;
    }

    public void Initialize(float speed, PlayerPrefsSystem playerPS, SoundManager soundManager, GameObject enemyPool)
    {
        _playerPS = playerPS;
        _soundManager = soundManager;
        _enemyPool = enemyPool.GetComponent<EnemyPool>();

        _speed = speed;
        _isHit = false;
    }
}
