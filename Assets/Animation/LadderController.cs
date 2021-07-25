using UnityEngine;
using UnityEngine.Audio;

public class LadderController : MonoBehaviour
{
    [SerializeField] GameObject cameraLadder;
    private AudioSource source;

    private void Awake() 
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        source.Play();
    }
}
