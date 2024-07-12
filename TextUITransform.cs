using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class TextUITransform: MonoBehaviour
{
    [SerializeField] TextSpeedWarning textSpeedWarning;
    [SerializeField] private int textSpeed;
    [SerializeField] private float scrollSpeed = 0.1f;
    private bool textStartMoving;
    

    public TMP_InputField textInput;
    public TextMeshProUGUI textOutput;
    private Vector3 startingPostion;


    //Unity funtion =================================================================================
    private void Start()
    {
        startingPostion = transform.position;
        //transform.position = new Vector3(0, startPostion, 0);
        Debug.Log(transform.position);
        Debug.Log(startingPostion);
    }

    private void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            // Apply movement to the game object along the Y-axis
            Vector3 newPosition = transform.position + new Vector3(0, scrollInput * scrollSpeed, 0);
            transform.position = newPosition;
        }
        TextMovement();
    }

    //Text Setup =====================================================================================
    public void SetTextToOutput()
    {
        textOutput.text = textInput.text;
    }

    

    //Text Logic =====================================================================================
    //Input Manager controls these scripts -----------------------------------------------------------
    private void TextMovement()
    {
        //Logic behind text moving.
        if (textStartMoving)
        {
            transform.Translate(textSpeed * Time.deltaTime * Vector2.up);
        }
    }

    public void StartAndStopText()
    {
        //Check to see if true
        if (!textStartMoving)
        {
            textStartMoving = true;
        }
        else
        {
            textStartMoving = false;
        }
        Debug.Log("TextUITrasform StartAndStopText: " + textStartMoving);
    }

    public void SpeedTextUp(bool up)
    {
        if(up) 
        {
            textSpeed++;
        }
        else
        {
            textSpeed--;
            if(textSpeed <= 0)
            {
                textSpeed = 0;
                //This send a message to TextSpeedWarning.
                textSpeedWarning.StartShowingMessage();
            }
        }
    }

    public void ReturnTransformToStart()
    {
        transform.position = startingPostion;
    }

    IEnumerator TypeLine(string s)
    {
        foreach (char c in s.ToCharArray())
        {
            //_textComponent.text += c;
            yield return new WaitForSeconds(1);
        }
    }

}
