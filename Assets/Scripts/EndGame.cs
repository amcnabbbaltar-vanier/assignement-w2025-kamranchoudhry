using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class EndGame : MonoBehaviour
{

  public TMP_Text FinalTime;
  public TMP_Text FinalScore;

    // Start is called before the first frame update
     void Start()  
    {
        if (GameManager.Instance != null) 
        {
            FinalScore.text = "Score: " + GameManager.Instance.score;
            FinalTime.text = "Time: " + Mathf.FloorToInt(GameManager.Instance.timer).ToString();
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }
    public void RePlay(){
    SceneManager.LoadScene("SampleScene");
    GameManager.Instance.score = 0;
    GameManager.Instance.timer = 0;



  }
  public void QuitGame(){
    Application.Quit();
    Debug.Log("Player has quit the game");
  }
}
