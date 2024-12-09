using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        BulletMovement();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // �������� �� ������������ � ������
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                // ��������� ��� ���������
                enemy.HandleHit();  // ��������� ���������
            }
            Destroy(gameObject); // ���������� ����
        }
    }
    private void BulletMovement()
    {
        float newPosition = 5 * Time.deltaTime;
        gameObject.transform.position += new Vector3(0, newPosition, 0);

        if (gameObject.transform.position.y > 5.5f) Destroy(gameObject);
    }
}
