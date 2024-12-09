using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject _loadingCanvas;
    [SerializeField] private Slider _loadingBar;
    [SerializeField] private TextMeshProUGUI _loadingText;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Starting()
    {
        _loadingCanvas.SetActive(true);

        StartCoroutine(AsyncLoadingScene("Game"));
    }

    IEnumerator AsyncLoadingScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);


        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            _loadingBar.value = progress;
            _loadingText.text = $"{(progress * 100):0}%";

            yield return null;
        }
    }
}
