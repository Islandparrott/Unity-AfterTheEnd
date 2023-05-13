// Ailand Parriott
// created: 23.04.21
// This script allows for enemy functionality
//
// Resources used:
//  MELEE COMBAT in Unity
//      https://www.youtube.com/watch?v=sPiVz1k-fEs


using UnityEngine;


public class Enemy : MonoBehaviour
{
    // score init
    public int enemyScore = 10;
    // health init
    public int health = 10, healthMax = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        ScoreController scoreController = 
                FindObjectOfType<ScoreController>();

        if(health <= 0)
        {
            Die();
            scoreController.AddScore(enemyScore);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
