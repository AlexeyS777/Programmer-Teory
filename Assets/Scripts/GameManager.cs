using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private AudioSource foneMusic;
    private int sceneIndex = 1;

    public int IndexOfScene { get { return sceneIndex; } set { sceneIndex = value; } }
    /*public bool VolumeIsZero 
    { get { if (foneMusic.volume == 0)
            {
                return true;
            }
            else 
            {
                return false;
            } 
          } 
    }*/

    private void Awake()
    {
        if(gameManager != null)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        foneMusic = GetComponent<AudioSource>();
        foneMusic.volume = 0;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayFhoneMusic(AudioClip clip)
    {
        foneMusic.clip = clip;
        foneMusic.Play();
        StartCoroutine(ChangeFoneMusicVolume(true));
    }

    public void StopFoneMusic()
    {
        StartCoroutine(ChangeFoneMusicVolume(false));
    }

    private IEnumerator ChangeFoneMusicVolume(bool direction)
    {
        if (direction)
        {
            while (foneMusic.volume < 1)
            {
                foneMusic.volume += 0.1f;
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            while (foneMusic.volume > 0)
            {
                foneMusic.volume -= 0.1f;                
                yield return new WaitForSeconds(0.2f);
            }

            foneMusic.Stop();
            foneMusic.clip = null;
        }
    }
}
