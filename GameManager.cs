using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject editModeGameObject;
    public GameObject playModeGameObejct;
    public GameObject playButtonGameObject;

    private void Start()
    {
        playModeGameObejct.SetActive(false);
        editModeGameObject.SetActive(true);
        playButtonGameObject.SetActive(true);
        InputManager.inputManager.IncomingData(false);
        
    }

    public void SwitchStates(bool isPlaying)
    {
        if(!isPlaying)
        {
            editModeGameObject.SetActive(true);
            playModeGameObejct.SetActive(false);
            playButtonGameObject.SetActive(true);
            InputManager.inputManager.IncomingData(false);
        }
        else
        {
           
            playModeGameObejct.SetActive(true);
            editModeGameObject.SetActive(false);
            playButtonGameObject.SetActive(false);
            InputManager.inputManager.IncomingData(true);
        }
    }
}
