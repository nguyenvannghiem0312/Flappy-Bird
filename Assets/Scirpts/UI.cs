using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreText;
    public GameObject Panel1;
    public GameObject Panel;
    public void SetScoreText(string txt)
    {
        if (ScoreText)
        {
            ScoreText.text = txt;
        }
    }
    public void ShowPanel(bool panel)
    {
        if (Panel)
        {
            Panel.SetActive(panel);
        }
    }
    public void ClosePanel1(bool panel)
    {
        Panel1.SetActive(panel);
    }
}
