using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 spawnPosition = new Vector3();
    //component
    public PlayerCharacterController playerCharacterController = null;
    public CameraFollowPlayer cameraFollowPosition = null;
    //UI Death Screen
    public GameObject deathScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        this.spawnPosition = this.playerCharacterController.transform.position;
        
        //hide death screen
        this.deathScreen.SetActive(false);
    }

    public void Die()
    {
        //show death screen
        this.deathScreen.SetActive(true);

        //player controller stop reveiving input
        this.playerCharacterController.enabled = false;

        //camera stop following player
        this.cameraFollowPosition.enabled = false;
    }

    public void Respawn()
    {
        //hide death screen
        this.deathScreen.SetActive(false);

        //Retour au spawn
        this.playerCharacterController.transform.position = this.spawnPosition;

        //RigidBody2D
        this.playerCharacterController.Rigidbody2D.velocity = Vector3.zero;

        //player controller active reveiving input
        this.playerCharacterController.enabled = true;

        //camera active following player
        this.cameraFollowPosition.enabled = true;
    }
}
