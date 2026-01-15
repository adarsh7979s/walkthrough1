using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Enable cursor for UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
