using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class MobileTouchLook : MonoBehaviour
{
    [Header("Look Settings")]
    [Range(0.05f, 0.3f)]
    public float lookSensitivity = 0.12f;

    [Header("Invert")]
    public bool invertY = false;

    private Vector2 lastTouchPos;
    private bool isLooking;

    private StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        inputs.look = Vector2.zero;

        if (Input.touchCount == 0)
        {
            isLooking = false;
            return;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // ❌ Ignore UI touches (buttons, joystick)
            if (EventSystem.current != null &&
                EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                continue;

            // ❌ Ignore LEFT side of screen (movement area)
            if (touch.position.x < Screen.width * 0.5f)
                continue;

            // ✅ RIGHT side = LOOK
            HandleLook(touch);
            break;
        }
    }

    private void HandleLook(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                lastTouchPos = touch.position;
                isLooking = true;
                break;

            case TouchPhase.Moved:
                if (!isLooking) return;

                Vector2 delta = touch.position - lastTouchPos;
                lastTouchPos = touch.position;

                float lookX = delta.x * lookSensitivity;
                float lookY = delta.y * lookSensitivity;

                if (invertY)
                    lookY = -lookY;

                // IMPORTANT:
                // X = horizontal camera
                // Y = vertical camera (NO random invert)
                inputs.look = new Vector2(lookX, lookY);
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                isLooking = false;
                inputs.look = Vector2.zero;
                break;
        }
    }
}
