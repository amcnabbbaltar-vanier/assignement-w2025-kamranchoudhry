using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Trap : MonoBehaviour
{
   public int damageAmount = 1; 

   private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}

}
