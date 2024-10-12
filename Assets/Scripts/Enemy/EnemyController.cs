using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyStats enemy;
    private Transform player;
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    private Vector3 lastPosition;  // To track the last position and determine movement direction

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;  // Initialize the last position
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);

        // Flip the sprite based on movement direction
        FlipSprite();

        // Update the last position for the next frame
        lastPosition = transform.position;
    }

    void FlipSprite()
    {
        // Check if the bat is moving left or right by comparing the current position to the last position
        Vector3 movementDirection = transform.position - lastPosition;

        // If the enemy is moving left (x < 0), flip the sprite by setting the x scale to -1
        // If moving right (x > 0), reset the x scale to 1
        if (movementDirection.x < 0)
        {
            spriteRenderer.flipX = true;  // Flip the sprite to face left
        }
        else if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = false;  // Face right (default)
        }
    }
}
