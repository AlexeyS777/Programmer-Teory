using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadLobby : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image loadBar;
    public TextMeshProUGUI barText;
    public int sceneID;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneCor());
    }

    private IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            loadBar.fillAmount = progress;
            barText.text = "Loading ... " + loadBar.fillAmount + "%";
            yield return 0;
        }
    }
}
