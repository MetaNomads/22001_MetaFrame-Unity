using UnityEngine;
using System.Collections;

public class RandomWaitLoop : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public float minWaitTime = 1.0f; // Minimum wait time in seconds
    public float maxWaitTime = 5.0f; // Maximum wait time in seconds

    private float randomWaitTime;
    private float randomStartTime;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        // Start the coroutine
        StartCoroutine(WaitForRandomTimeAndLoop());
    }

    private IEnumerator WaitForRandomTimeAndLoop()
    {
        while (true)
        {
            // Check if audio is playing
            if (audioSource.isPlaying)
            {
                // Calculate a random wait time
                randomWaitTime = Random.Range(minWaitTime, maxWaitTime);

                // Wait for the random time
                yield return new WaitForSeconds(randomWaitTime);

                // Check again if audio is still playing
                if (audioSource.isPlaying)
                {
                    // Set a random start time within the audio clip length
                    randomStartTime = Random.Range(0f, audioSource.clip.length);

                    // Set the audio clip's time to the random start time
                    audioSource.time = randomStartTime;
                }
            }
            else
            {
                // Wait a bit before checking again if the audio is not playing
                yield return new WaitForSeconds(3f);
            }
        }
    }
}
