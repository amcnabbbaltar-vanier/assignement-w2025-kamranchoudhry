using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timer = 0f;
    private bool isGameRunning = true;

    public TMP_Text Timer;
    public TMP_Text Score;

  private void Awake() 
{     
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}

    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (Score != null) Score.text = "Score: " + score;
        if (Timer != null) Timer.text = "Time: " + Mathf.FloorToInt(timer).ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }
}
