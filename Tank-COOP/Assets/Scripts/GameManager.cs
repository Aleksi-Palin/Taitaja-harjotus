using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool GameOver;

    public string Winner_text;

    public TMP_Text winner_text_holder;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            winner_text_holder.text = Winner_text;
        }
    }
}
