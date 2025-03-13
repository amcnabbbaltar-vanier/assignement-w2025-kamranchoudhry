using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    public float hoverSpeed = 2f;  
    public float hoverHeight = 1f;  
    public float speedIncrease = 1.5f;  
    public float duration = 30f;  
    private ParticleSystem hitParticles;
    // Start is called before the first frame update

        private Vector3 startPosition;

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
                 player.EnableDoubleJump(duration); // Enable double jump for 30 seconds
            }
             GetComponent<MeshRenderer>().enabled = false;
             GetComponent<Collider>().enabled = false;       
         }
    }
}
