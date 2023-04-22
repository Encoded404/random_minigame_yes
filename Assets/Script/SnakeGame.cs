using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class SnakeGame : MonoBehaviour
{
    public Tilemap tilemap; 
    public TileBase snakeTile;
    public TileBase foodTile;
    public int initialLength = 3;
    public float moveDelay = 0.5f;
    
    private List<Vector3Int> snakePositions = new List<Vector3Int>();
    private Vector3Int foodPosition;
    private Vector3Int currentDirection;
    private Vector3Int nextDirection;
    private float lastMoveTime;
    
    void Start()
    {
        // Set up snake starting position
        Vector3Int center = Vector3Int.RoundToInt(tilemap.cellBounds.center);
        for (int i = 0; i < initialLength; i++)
        {
            Vector3Int pos = center + Vector3Int.left * i;
            snakePositions.Add(pos);
            tilemap.SetTile(pos, snakeTile);
        }
        
        // Set up food position
        foodPosition = GetRandomCell();
        tilemap.SetTile(foodPosition, foodTile);
        
        // Set initial direction
        currentDirection = Vector3Int.right;
    }
    
    void Update()
    {
        // Check for input
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentDirection != Vector3Int.down)
        {
            nextDirection = Vector3Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentDirection != Vector3Int.up)
        {
            nextDirection = Vector3Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentDirection != Vector3Int.right)
        {
            nextDirection = Vector3Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentDirection != Vector3Int.left)
        {
            nextDirection = Vector3Int.right;
        }
        
        // Move snake
        if (Time.time - lastMoveTime > moveDelay)
        {
            currentDirection = nextDirection;
            Vector3Int nextPos = snakePositions[0] + currentDirection;
            
            // Check for collision with walls or self
            if (!tilemap.cellBounds.Contains(nextPos) || snakePositions.Contains(nextPos))
            {
                Debug.Log("Game over!");
                return;
            }
            
            snakePositions.Insert(0, nextPos);
            tilemap.SetTile(nextPos, snakeTile);
            
            // Check for collision with food
            if (nextPos == foodPosition)
            {
                foodPosition = GetRandomCell();
                tilemap.SetTile(foodPosition, foodTile);
            }
            else
            {
                Vector3Int tailPos = snakePositions[snakePositions.Count - 1];
                snakePositions.RemoveAt(snakePositions.Count - 1);
                tilemap.SetTile(tailPos, null);
            }
            
            lastMoveTime = Time.time;
        }
    }
    
    Vector3Int GetRandomCell()
    {
        Vector3Int cell;
        do
        {
            cell = new Vector3Int(Random.Range(tilemap.cellBounds.min.x, tilemap.cellBounds.max.x),
                                  Random.Range(tilemap.cellBounds.min.y, tilemap.cellBounds.max.y),
                                  0);
        } while (snakePositions.Contains(cell));
        
        return cell;
    }
}