using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] TextUITransform textUITransform;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input Manager: Space Was Hit");
            textUITransform.StartAndStopText();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Input Manager: Up Arrow Was Hit");
            textUITransform.SpeedTextUp(true);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Input Manager: Down Arrow Was Hit");
            textUITransform.SpeedTextUp(false);
        }
    }
}
