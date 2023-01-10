using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool GameOver;

    public string Winner_text;

    public TMP_Text winner_text_holder;

    public GameObject RestartMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        RestartMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            winner_text_holder.text = Winner_text;
            RestartMenu.SetActive(true);
        }
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
