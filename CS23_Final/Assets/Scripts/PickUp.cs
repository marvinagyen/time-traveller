using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool hasKey = false;

      public AudioSource pickUpSound;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  pickUpSound.Play(0);
                  hasKey = true;
                  Debug.Log(hasKey);
                  Debug.Log("Key has been acquired!");
                  GetComponent<Collider2D>().enabled = false;
                  //GetComponent< AudioSource>().Play();
                  StartCoroutine(DestroyThis());
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.15f);
            Destroy(gameObject);
      }

}