using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FallOfMap : MonoBehaviour
{
    private Vector3 startPosition; 

    private void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Reduce health by 1
                
                // Respawn at the initial position
                other.transform.position = startPosition;
                other.transform.rotation = Quaternion.identity; // Reset rotation if needed
            }
        }
    }
}