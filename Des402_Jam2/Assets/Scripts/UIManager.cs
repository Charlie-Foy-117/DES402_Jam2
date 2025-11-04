using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] endScreen = new GameObject[4];
    [SerializeField] private TMPro.TextMeshProUGUI[] scoreText = new TMPro.TextMeshProUGUI[2];

    private void Start()
    {
        endScreen[0].SetActive(false);
        endScreen[1].SetActive(false);
        endScreen[2].SetActive(false);
        endScreen[3].SetActive(false);
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

    public void UpdateEndText(bool win)
    {
        if (win)
        {
            endScreen[0].SetActive(true);
            endScreen[1].SetActive(true);
            endScreen[2].SetActive(false);
            endScreen[3].SetActive(false);
        }
        else
        {
            endScreen[0].SetActive(false);
            endScreen[1].SetActive(false);
            endScreen[2].SetActive(true);
            endScreen[3].SetActive(true);
        }
    }

    public void UpdateScoreText(int score)
    {
        scoreText[0].text = score.ToString();
        scoreText[1].text = score.ToString();
    }
}
