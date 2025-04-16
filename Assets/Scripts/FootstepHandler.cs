using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    // Setting variables for audio sources.
    [Header("Audio Settings")]
    public AudioSource audioSource;

    public AudioClip fairwayGrassClip;
    public AudioClip sandBunkerClip;
    public AudioClip defaultClip;

    // Variables for footstep timer settings. 
    [Header("Footstep Settings")]
    public float footstepInterval = 0.5f;
    private float footstepTimer;

    // Getting players position via Vector3 as opposed to rigid body (the XR Origin, i.e. player, does not have a rigid body).
    private Vector3 lastPosition;

    // Getting the position and getting audio source. 
    void Start()
    {
        lastPosition = transform.position;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (IsMoving())
        { 
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                // The player is moving, play the sound. 
                PlayFootstepSound();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            // Player is not moving, timer resets. 
            footstepTimer = 0f;
        }
    }

    bool IsMoving()
    {
        // Checks to see if the player has moved. 
        float movedDistance = Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        return movedDistance > 0.01f; // You can tweak this sensitivity
    }

    void PlayFootstepSound()
    {
        // Tracking the players surface and movement via Vector3. 
        Vector3 rayOrigin = transform.position - new Vector3(0f, 0.5f, 0f); // Raycast from a bit below the object
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 2f))
        {
            switch (hit.collider.tag)
            {
                case "Fairways":
                    audioSource.PlayOneShot(fairwayGrassClip);
                    break;
                case "Sand Bunkers":
                    audioSource.PlayOneShot(sandBunkerClip);
                    break;
                default:
                    audioSource.PlayOneShot(defaultClip);
                    break;
            }
        }
    }
}
