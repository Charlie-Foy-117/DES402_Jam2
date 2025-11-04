using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToReset;
    [SerializeField] private float maxGameTime;
    private bool gamePaused = false;

    [Header("Refs")]
    [SerializeField] private UIManager uiManager;

    [HideInInspector] public static GameManager Instance { get; private set; }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        // Check if an instance already exists.
        if (Instance != null && Instance != this)
        {
            Instance.InitialiseGame();
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EndGame(bool win)
    {
        //Time.timeScale = 0; need to disable player controller
        if (win == true) { Win(); }
        else { Lose(); }
        StartCoroutine(StartResetTimer(timeToReset));
    }

    public void ResetGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //InitialiseGame();
    }

    private void InitialiseGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        { 
            uiManager = FindFirstObjectByType<UIManager>();
        }
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public float GetMaxGameTime()
    {
        return maxGameTime;
    }

    public bool GetGamePaused()
    {
        return gamePaused;
    }

    IEnumerator StartResetTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetGame();
    }

    private void Win()
    {
        gamePaused = true;
        uiManager.UpdateEndText(true);
    }
    private void Lose()
    {
        gamePaused = true;
        uiManager.UpdateScoreText(0);
        uiManager.UpdateEndText(false);
    }
}
