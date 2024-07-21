using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] TextUITransform textUITransform;
    [SerializeField] GameManager gameManager;
    public static InputManager inputManager { get; set; }

    private void Awake()
    {
        if (inputManager != null && inputManager != this)
        {
            Destroy(this);
        }
        else
        {
            inputManager = this;
        }
    }
    private bool prompterLiveMode;
    // Update is called once per frame
    void Update()
    {
        if (prompterLiveMode)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Input Manager: Space Was Hit");
                textUITransform.StartAndStopText();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Input Manager: Up Arrow Was Hit");
                textUITransform.SpeedTextUp(true);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Input Manager: Down Arrow Was Hit");
                textUITransform.SpeedTextUp(false);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Input Manager: Q Was Hit");
                gameManager.SwitchStates(false);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Input Manager: R Was Hit");
                textUITransform.ReturnTransformToStart();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Input Manager: S Was Hit");
                textUITransform.StopMovement();
            }
        }
    }
    public void IncomingData(bool switchState)
    {
        prompterLiveMode = switchState;
    }
}
