using UnityEngine;
using TMPro;
using System.Collections;

public class TextSpeedWarning : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textSetToLow;
    private bool messageShowing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textSetToLow.text = " ";
    }

    public void StartShowingMessage()
    {
        textSetToLow.text = "Text speed set to 0";
        if(!messageShowing)
        {
            StartCoroutine(TextTimer());
            messageShowing = true;
        }
    }

    private IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(2);
        textSetToLow.text = " ";
        messageShowing = false;
    }
}
