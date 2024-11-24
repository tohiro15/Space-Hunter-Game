using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Movement(float speed, GameObject player)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float screenHalf = Screen.width / 2;
            float touchX = touch.position.x;

            if (touchX < screenHalf)
            {
                player.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                player.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        limitCharacterMovement(player);
    }

    private void limitCharacterMovement(GameObject player)
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            float playerHalfWidth = spriteRenderer.bounds.extents.x;

            Vector3 newPosition = player.transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, -screenWidth + playerHalfWidth, screenWidth - playerHalfWidth);

            player.transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Player does not have a SpriteRenderer component!");
        }
    }
}
