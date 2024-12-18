using UnityEngine;

public class PlayResult : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private UIManager _uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0;

            _soundManager.StopClip();

            _uiManager.UpdateGameOverUI();

            DataManager.Instance.SaveDataAfterDeath();
        }
    }
    public void Victory()
    {
        Time.timeScale = 0;
        DataManager.Instance.SaveDataAfterVictory();
        _soundManager.VictoryClip();
        _uiManager.UpdateVictoryGameUI();
    }
}