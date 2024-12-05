using UnityEngine;
using UnityEngine.AI;

public class CellularAutomataMapGenerator : MonoBehaviour
{
    public GameObject pathPrefab;
    public GameObject obstaclePrefab;
    public NavMeshSurface navMeshSurface;
    public int width = 20; 
    public int height = 20; 
    public float fillProbability = 0.4f; 
    public float prefabCheckRadius = 10f; 

    void Start()
    {
        GenerateCellularAutomataGrid(width, height, fillProbability);
        UpdateNavMesh();
    }

    void GenerateCellularAutomataGrid(int width, int height, float fillProbability)
    {
        int[,] grid = new int[width, height];

        // Rács inicializálása
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = Random.value < fillProbability ? 1 : 0; // 1 = út, 0 = akadály
            }
        }

        for (int iteration = 0; iteration < 5; iteration++)
        {
            grid = ApplyCustomCellularAutomataRules(grid, width, height);
        }

        PlacePrefabs(grid, width, height, prefabCheckRadius);
    }

    int[,] ApplyCustomCellularAutomataRules(int[,] grid, int width, int height)
    {
        int[,] newGrid = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int pathNeighbors = CountNeighbors(grid, x, y, width, height, 1);
                int obstacleNeighbors = CountNeighbors(grid, x, y, width, height, 0);

                if (grid[x, y] == 1) // Ha jelenleg "út"
                {
                    newGrid[x, y] = (obstacleNeighbors >= 5) ? 0 :
                                    (pathNeighbors >= 2 && pathNeighbors <= 3) ? 1 : 0;
                }
                else // Ha jelenleg "akadály"
                {
                    newGrid[x, y] = (pathNeighbors >= 2) ? 1 : 0;
                }
            }
        }

        return newGrid;
    }

    int CountNeighbors(int[,] grid, int x, int y, int width, int height, int type)
    {
        int count = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;

                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && ny >= 0 && nx < width && ny < height && grid[nx, ny] == type)
                {
                    count++;
                }
            }
        }
        return count;
    }

    bool IsPositionValid(Vector3 position, float checkRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, checkRadius);
        return colliders.Length == 0; // Ha nincs ütközés, érvényes a pozíció
    }

    void PlacePrefabs(int[,] grid, int width, int height, float prefabCheckRadius)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * 50, 0, y * 50);
                if (grid[x, y] == 1) // "Út" cella
                {
                    if (IsPositionValid(position, prefabCheckRadius))
                    {
                        Instantiate(pathPrefab, position, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogWarning($"Pozíció foglalt (út): {position}");
                    }
                }
                else if (grid[x, y] == 0) // "Akadály" cella
                {
                    if (IsPositionValid(position, prefabCheckRadius))
                    {
                        Instantiate(obstaclePrefab, position, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogWarning($"Pozíció foglalt (akadály): {position}");
                    }
                }
            }
        }
    }

    void UpdateNavMesh()
    {
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
        else
        {
            Debug.LogError("NavMeshSurface nem lett beállítva!");
        }
    }
}
