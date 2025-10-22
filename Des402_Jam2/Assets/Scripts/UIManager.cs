using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endScreen;

    private void Start()
    {
        endScreen.SetActive(false);
    }
}
