using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectParticles;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin Triggered by " + other.name);

        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            if (collectParticles != null)
                Instantiate(collectParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
