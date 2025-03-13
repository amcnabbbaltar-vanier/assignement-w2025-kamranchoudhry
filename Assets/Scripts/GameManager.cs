using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timer = 0f;
    private bool isGameRunning = true;

    public TMP_Text Timer;
    public TMP_Text Scores;

    private void Awake() 
    {     
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
            return; 
        } 
        
        Instance = this; 
        DontDestroyOnLoad(gameObject); 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        AssignUIElements(); 
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
        if (Scores != null) Scores.text = "Score: " + score;
        if (Timer != null) Timer.text = "Time: " + Mathf.FloorToInt(timer).ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void AssignUIElements()
    {
        Timer = GameObject.Find("Timer")?.GetComponent<TMP_Text>();
        Scores = GameObject.Find("Scores")?.GetComponent<TMP_Text>();
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignUIElements();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }
}
