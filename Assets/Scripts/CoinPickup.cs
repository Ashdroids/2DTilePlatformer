using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
     [SerializeField] AudioClip coinSFX;

  void OnTriggerEnter2D(Collider2D other) 
  {
      if(other.tag == "Player")
      {
            AudioSource.PlayClipAtPoint(coinSFX, gameObject.transform.position);
            Destroy(gameObject);
      }
  }
}
