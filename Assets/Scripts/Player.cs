using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioManager audioManager;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x,  6 , playerRb.velocity.z);
        audioManager.Play("bounce");

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
       
       if(materialName == "Safe (Instance)")
        {
            //the player is safe
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //the player is in the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if (materialName == "Last Ring (Instance)" && !GameManager.levelCompleted )
        {
            //level completed
            GameManager.levelCompleted = true;
            audioManager.Play("win level");

        }
    }

}
