//using System.Collections.Generic;
//using System.Collections;
//using UnityEngine;

//public class WatchPickUp : MonoBehaviour
//{

//    //public GameHandler gameHandler;
//    //public playerVFX playerPowerupVFX;

//    public bool canTimeTravel = true;

//    //public bool isSpeedBoostPickUp = false;

//    //public int healthBoost = 50;
//    //public float speedBoost = 2f;
//    //public float speedTime = 2f;

//    void Start()
//    {
//        //gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
//        //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
//    }

//    public void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            Debug.Log("collide");
//            Destroy(gameObject);
//            GetComponent<Collider2D>().enabled = false;
//            //GetComponent< AudioSource>().Play();
//            //StartCoroutine(DestroyThis());

//            //if (isHealthPickUp == true)
//            //{
//            //    //gameHandler.playerGetHit(healthBoost * -1);
//            //    //playerPowerupVFX.powerup();
//            //}

//            //if (isSpeedBoostPickUp == true)
//            //{
//            //    other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
//            //    //playerPowerupVFX.powerup();
//            //}
//        }
//    }

//    IEnumerator DestroyThis()
//    {
//        yield return new WaitForSeconds(0.3f);
//        Destroy(gameObject);
//    }

//}