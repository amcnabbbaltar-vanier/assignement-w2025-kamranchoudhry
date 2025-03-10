using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation
    public float hoverSpeed = 2f;   // Speed of hover movement
    public float hoverHeight = 1f; 
    public int scoreValue = 50;

    // Start is called before the first frame update
    private Vector3 startPosition;
    private ParticleSystem hitParticles;


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
                GameManager.Instance.AddScore(scoreValue);

            }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;       
         }
    }
}
