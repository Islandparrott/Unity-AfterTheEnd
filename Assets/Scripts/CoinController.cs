// Ailand Parriott
// created: 23.04.21
//
// This script adds functionality to the coins for testing.

using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinScore = 1;
    
    // function to run when player touches coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if colliding with tag Player using CompareTag
        if (collision != null && collision.tag == "Player")
        {   
            // includes ScoreController script
            ScoreController scoreController = 
                    collision.GetComponent<ScoreController>();
            // add score then destroy the coin
            if (scoreController != null)
            {
                scoreController.AddScore(coinScore);
                Destroy(gameObject);
            }
        }
    }
}
