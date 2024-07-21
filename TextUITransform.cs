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
    private Vector3 startingPostion;
    private Rigidbody2D rb;

    public TMP_InputField textInput;
    public TextMeshProUGUI textOutput;
   
    private void Awake()
    {
        textOutput.GetComponent<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Unity funtion =================================================================================
    private void Start()
    {
        startingPostion = transform.position;
    }

    private void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            MoveText();
            /*
            // Apply movement to the game object along the Y-axis
            Vector3 newPosition = transform.position + new Vector3(0, scrollInput * scrollSpeed, 0);
            transform.position = newPosition;
            */
        }
        TextMovement();
    }

    private void MoveText()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector2 inputVector = new (0f, scrollInput);
        rb.AddForce(new Vector2(0, inputVector.y) * scrollSpeed, ForceMode2D.Force);
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

    public void StopMovement()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
