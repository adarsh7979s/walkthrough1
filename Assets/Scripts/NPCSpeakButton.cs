using UnityEngine;

public class NPCSpeakButton : MonoBehaviour
{
    public AudioSource npcVoice;

    public void Speak()
    {
        if (npcVoice != null)
        {
            npcVoice.Stop();   // prevents overlap
            npcVoice.Play();
        }
    }
}
