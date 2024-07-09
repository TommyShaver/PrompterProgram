using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollTextInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float scollSpeedInputBox;
    private bool isHovering;
    private Vector2 startPostion;

    private void Start()
    {
        startPostion = transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if(isHovering)
        {
            Debug.Log("ScrollTextInput: Text Box Selected");
            if (scrollInput != 0)
            {
                // Apply movement to the game object along the Y-axis
                Vector3 newPosition = transform.position + new Vector3(0, scrollInput * scollSpeedInputBox, 0);
                transform.position = newPosition;
            }
        }
        if (transform.position.y <= startPostion.y)
        {
            transform.position = startPostion;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
