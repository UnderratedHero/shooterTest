using UnityEngine;

public class LoseUi : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveUi()
    {
        gameObject.SetActive(true); 
    }
}
