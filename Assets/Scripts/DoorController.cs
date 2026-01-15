using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [Header("References")]
    public Animator doorAnimator;
    public GameObject infoText;

    [Header("Scene Settings")]
    public string nextSceneName = "Scene_2_Continue";

    private bool hasOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasOpened)
            return;

        if (other.CompareTag("Player"))
        {
            hasOpened = true;

            // Open door animation
            doorAnimator.SetBool("Open", true);

            // Hide text
            if (infoText != null)
                infoText.SetActive(false);

            // Load next scene after delay
            Invoke(nameof(LoadNextScene), 2f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
