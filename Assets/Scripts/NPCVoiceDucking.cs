using UnityEngine;

public class NPCVoiceDucking : MonoBehaviour
{
    public AudioSource npcVoice;        // NPC voice AudioSource
    public AudioSource backgroundMusic; // Background music AudioSource

    public float normalMusicVolume = 0.3f;
    public float duckedMusicVolume = 0.1f;

    void Update()
    {
        if (npcVoice != null && backgroundMusic != null)
        {
            if (npcVoice.isPlaying)
            {
                backgroundMusic.volume = duckedMusicVolume;
            }
            else
            {
                backgroundMusic.volume = normalMusicVolume;
            }
        }
    }
}

