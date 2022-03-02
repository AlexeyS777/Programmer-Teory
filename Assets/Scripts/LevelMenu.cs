using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MainMenu  //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    public override void StartLevel() // POLYMORPHISM
    {
        GameManager.gameManager.PlayFhoneMusic(mainMenuMusic);
    } 
}
