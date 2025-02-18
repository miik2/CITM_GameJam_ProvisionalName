﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (gameObject.tag == "Map_Boundary" || other.tag == "Map_Boundary" || (gameObject.tag == "Enemy" && other.gameObject.tag == "Enemy") || (gameObject.tag == "Player" && other.gameObject.tag == "Player") || (gameObject.tag == "Player" && other.gameObject.tag == "Torpede") || (gameObject.tag == "Torpede" && other.gameObject.tag == "Player"))
        {
            return;
        }
        else
        {
            if (other.tag == "Boundary")
            {
                return;
            }

            Instantiate(explosion, transform.position, transform.rotation);

            if (gameObject.tag == "Player")
            {
				SceneManager.LoadScene("GameOver");
            }

			if ((gameObject.tag == "Torpede" && other.gameObject.tag == "Enemy") || (gameObject.tag == "Enemy" && other.gameObject.tag == "Torpede"))
            {
                Score_Script.AddScore(10);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
            
        
    }
		
}