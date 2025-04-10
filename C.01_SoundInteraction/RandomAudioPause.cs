using UnityEngine;
using System.Collections;

public class RandomAudioPause : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public float minResumeTime = 0f; // Minimum time before resuming
    public float maxResumeTime = 5f; // Maximum time before resuming

    private bool isPaused = false;

    void Start()
    {
        // Start the audio if it's not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Start the random pause and resume coroutine
        StartCoroutine(RandomPauseResume());
    }

    private IEnumerator RandomPauseResume()
    {
        while (true)
        {
            // Wait for a random amount of time before pausing
            yield return new WaitForSeconds(Random.Range(0, audioSource.clip.length));

            // Pause the audio
            audioSource.Pause();
            isPaused = true;

            // Wait for a random amount of time before resuming
            yield return new WaitForSeconds(Random.Range(minResumeTime, maxResumeTime));

            // Resume the audio from a random timestamp
            audioSource.time = Random.Range(0f, audioSource.clip.length);
            audioSource.Play();
            isPaused = false;
        }
    }
}