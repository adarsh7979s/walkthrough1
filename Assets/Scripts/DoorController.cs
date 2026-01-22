using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DoorController : MonoBehaviour
{
    [Header("References")]
    public Animator doorAnimator;
    public GameObject infoText;

    [Header("Level Complete UI")]
    public GameObject levelCompleteCanvas;
    public VideoPlayer videoPlayer;

    [Header("Scene Settings")]
    public string nextSceneName = "Scene_2_Continue";

    private bool hasCompleted = false;

    private void Start()
    {
        // Safety
        if (levelCompleteCanvas != null)
            levelCompleteCanvas.SetActive(false);

        if (videoPlayer != null)
            videoPlayer.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasCompleted) return;

        if (other.CompareTag("Player"))
        {
            hasCompleted = true;

            // Open door animation
            if (doorAnimator != null)
                doorAnimator.SetBool("Open", true);

            // Hide hint text
            if (infoText != null)
                infoText.SetActive(false);

            // Show reward UI
            if (levelCompleteCanvas != null)
                levelCompleteCanvas.SetActive(true);
        }
    }

    // 🔹 Called by WATCH VIDEO button
    public void OnWatchVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    // 🔹 Called by SKIP button
    public void OnSkipVideo()
    {
        LoadNextScene();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
