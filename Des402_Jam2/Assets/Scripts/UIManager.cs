using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMPro.TextMeshProUGUI endText;
    [SerializeField] private string winText;
    [SerializeField] private string lossText;

    private void Start()
    {
        endScreen.SetActive(false);
    }

    public GameObject GetEndScreen()
    {
        return endScreen;
    }

    public void SetEndScreen(bool active)
    {
        if (active)
        {
            endScreen.SetActive(true);
        }
        else
        {
            endScreen.SetActive(false);
        }
    }

    public void UpdateEndText(bool win)
    {
        if (win)
        {
            endText.text = winText;
        }
        else
        {
            endText.text = lossText;
        }
    }
}
