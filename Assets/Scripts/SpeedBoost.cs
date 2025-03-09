using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation
    public float hoverSpeed = 2f;   // Speed of hover movement
    public float hoverHeight = 1f;  // Hover height
    public float speedIncrease = 1.5f;  // Amount to increase speed
    public float duration = 5f;       // How long the speed boost lasts
    private ParticleSystem hitParticles;


    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        hitParticles = GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            CharacterMovement player = other.GetComponent<CharacterMovement>();
            if (player != null)
            {
                hitParticles.Play();

                player.ApplySpeedBoost(speedIncrease, duration);
            }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;       
         }
    }
}
