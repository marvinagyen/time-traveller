using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour {
      // NOTE:: if laser does not hit something it throws null exception. Make sure laser is always enclosed
      public bool activated; // determines if laser is on or off
      public bool left, right, up, down; // determines which sides of box are on when activated
      public int laserDamage = 1;
      public bool killEnemy = true;

       private GameHandler gameHandlerObj;
       public PlayerMove_2 playerMovement;

       // ignore these variables public so that it is easier to access them as they are on children
       public LineRenderer leftLaser, rightLaser, topLaser, botLaser;
       public Transform hitPoint;
       private Transform leftTrans, rightTrans, topTrans, botTrans;

       void Start(){
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove_2>();
              leftLaser.enabled = rightLaser.enabled = topLaser.enabled = botLaser.enabled = true;
              leftLaser.useWorldSpace = rightLaser.useWorldSpace = true;
              topLaser.useWorldSpace = botLaser.useWorldSpace = true;

              leftTrans = leftLaser.GetComponent<Transform>();
              rightTrans = rightLaser.GetComponent<Transform>();
              topTrans = topLaser.GetComponent<Transform>();
              botTrans = botLaser.GetComponent<Transform>();

              GameObject gameHandlerLocation = GameObject.FindWithTag("GameHandler");
              if (gameHandlerLocation != null){
                      gameHandlerObj = gameHandlerLocation.GetComponent<GameHandler>();
              }
        }

       void Update(){

              RaycastHit2D hit; // point where laser hits

              if (left){
                     // find what the laser hits and draw it
                     leftLaser.enabled = true;
                     hit = Physics2D.Raycast(leftTrans.position, new Vector2(-1, 0));
                     hitPoint.position = hit.point;
                     leftLaser.SetPosition(0, leftTrans.position);
                     leftLaser.SetPosition(1, hitPoint.position);
                     // laser kills enemies and does constant damage to player, by a lot
                     if (hit.transform.CompareTag("Player")){
                             playerMovement.transform.position = playerMovement.respawnPoint;
                     }
              }
              else {
                      leftLaser.enabled = false;
              }

              if (right){
                      // find what the laser hits and draw it
                      rightLaser.enabled = true;
                      hit = Physics2D.Raycast(rightTrans.position, new Vector2(1, 0));
                      Debug.DrawLine(rightTrans.position, hit.point);
                      hitPoint.position = hit.point;
                      rightLaser.SetPosition(0, rightTrans.position);
                      rightLaser.SetPosition(1, hitPoint.position);
                      // laser kills enemies and does constant damage to player, by a lot
                      if (hit.transform.CompareTag("Player")){
                               playerMovement.transform.position = playerMovement.respawnPoint;
                      }

              }
              else {
                      rightLaser.enabled = false;
              }

              if (up){
                      // find what the laser hits and draw it
                      topLaser.enabled = true;
                      hit = Physics2D.Raycast(topTrans.position, new Vector2(0,1));
                      Debug.DrawLine(topTrans.position, hit.point);
                      hitPoint.position = hit.point;
                      topLaser.SetPosition(0, topTrans.position);
                      topLaser.SetPosition(1, hitPoint.position);
                     // laser kills enemies and does constant damage to player, by a lot
                     if (hit.transform.CompareTag("Player")) {
                             playerMovement.transform.position = playerMovement.respawnPoint;
                      }

              }
              else {
                      topLaser.enabled = false;
              }

              if (down){
                      // find what the laser hits and draw it
                      botLaser.enabled = true;
                      hit = Physics2D.Raycast(botTrans.position, new Vector2(0, -1));
                      Debug.DrawLine(botTrans.position, hit.point);
                      hitPoint.position = hit.point;
                      botLaser.SetPosition(0, botTrans.position);
                      botLaser.SetPosition(1, hitPoint.position);
                      // laser kills enemies and does constant damage to player, by a lot
                      if (hit.transform.CompareTag("Player")){
                                Debug.Log("C");
                                playerMovement.transform.position = playerMovement.respawnPoint;
                      }
              }
              else {
                      botLaser.enabled = false;
              }
        }

        
}
