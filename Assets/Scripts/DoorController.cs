using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DoorController : MonoBehaviour
{
    [Header("References")]
    public Animator doorAnimator;
    public GameObject infoText;
    public GameObject levelCompleteCanvas;
    public VideoPlayer videoPlayer;

    [Header("Scene Settings")]
    public string nextSceneName = "Scene_2_Continue";

    private bool triggered = false;

    private void Start()
    {
        // Safety: ensure video is stopped
        if (videoPlayer != null)
            videoPlayer.Stop();

        if (levelCompleteCanvas != null)
            levelCompleteCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Open door
            if (doorAnimator != null)
                doorAnimator.SetBool("Open", true);

            // Hide info text
            if (infoText != null)
                infoText.SetActive(false);

            // Show video UI
            if (levelCompleteCanvas != null)
                levelCompleteCanvas.SetActive(true);

            // Play video
            if (videoPlayer != null)
            {
                Debug.Log("Trying to play level complete video");

                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoFinished;
            }
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
