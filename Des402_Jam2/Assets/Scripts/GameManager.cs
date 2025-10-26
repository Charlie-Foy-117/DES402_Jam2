using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToReset;

    [Header("Refs")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject[] endScreen = new GameObject[2];

    [HideInInspector] public static GameManager Instance { get; private set; }

    private void Awake()
    {
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

        endScreen[0].SetActive(true);
        endScreen[1].SetActive(true);
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (endScreen[0] == null || endScreen[1] == null)
            {
                uiManager = FindFirstObjectByType<UIManager>();
                endScreen[0] = uiManager.GetEndScreen(0);
                endScreen[1] = uiManager.GetEndScreen(1);
            }
        }
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator StartResetTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetGame();
    }

    private void Win()
    {
        uiManager.UpdateEndText(true);
    }
    private void Lose()
    {
        uiManager.UpdateEndText(false);
    }
}
