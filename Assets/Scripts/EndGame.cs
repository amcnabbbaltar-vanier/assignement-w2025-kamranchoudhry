using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
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
