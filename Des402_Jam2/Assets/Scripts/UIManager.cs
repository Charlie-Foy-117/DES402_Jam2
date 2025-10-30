using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] endScreen = new GameObject[2];
    [SerializeField] private TMPro.TextMeshProUGUI[] endText = new TMPro.TextMeshProUGUI[2];
    [SerializeField] private TMPro.TextMeshProUGUI[] scoreText = new TMPro.TextMeshProUGUI[2];
    [SerializeField] private string winText;
    [SerializeField] private string lossText;

    private void Start()
    {
        endScreen[0].SetActive(false);
        endScreen[1].SetActive(false);
    }

    public GameObject GetEndScreen(int screenIndex)
    {
        if (screenIndex > endScreen.Length - 1)
        {
            Debug.Log("Screen Index is outside array length");
            return null; 
        }
        else
        {
            return endScreen[screenIndex];
        }
    }

    public void SetEndScreen(bool active)
    {
        if (active)
        {
            endScreen[0].SetActive(true);
            endScreen[1].SetActive(true);
        }
        else
        {
            endScreen[0].SetActive(false);
            endScreen[1].SetActive(false);
        }
    }

    public void UpdateEndText(bool win)
    {
        if (win)
        {
            endText[0].text = winText;
            endText[1].text = winText;
        }
        else
        {
            endText[0].text = lossText;
            endText[1].text = lossText;
        }
    }

    public void UpdateScoreText(int score)
    {
        scoreText[0].text = score.ToString();
        scoreText[1].text = score.ToString();
    }
}
