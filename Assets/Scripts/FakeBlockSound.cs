using UnityEngine;

public class FakeBlockSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool canPlay = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canPlay) return;

        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            canPlay = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPlay = true;
        }
    }
}
