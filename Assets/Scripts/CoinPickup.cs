using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
[SerializeField] AudioClip pickupSoundEffect;

    [SerializeField] int coinPoints = 100;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            var sessionManager = FindObjectOfType<GameSession>();
            FindObjectOfType<AudioController>().PlayClip(pickupSoundEffect);
            sessionManager.ProcessCoinPickup(coinPoints);
            Destroy(gameObject);
        }

    }
}
