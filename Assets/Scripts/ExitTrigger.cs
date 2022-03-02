using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitTrigger : MonoBehaviour
{
    public TextMeshProUGUI levelTitle;
    public LevelMenu menu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelTitle.gameObject.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        menu.StartNewGame(1);
    }
}
