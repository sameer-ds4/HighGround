using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int baseSize;
    private float cubeHeight = 0.5f;

    
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int y = 0; y < baseSize; y++)
        {
            int layerSize = baseSize - y;
            for (float x = 0.5f; x < layerSize; x++)
            {
                for (float z = 0.5f; z < layerSize; z++)
                {
                    Vector3 position = new Vector3(x - layerSize / 2f, y * cubeHeight, z - layerSize / 2f);
                    GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                    // cube.transform.localScale = new Vector3(1, cubeHeight, 1);
                }
            }
        }
    }
}



//  Spawn on XZ plane
//  x = -2.5 to 1.5 ; z = -2.5 to 1.5
//  Define the Direction - Up, Down, Left, Right


//  y offset = 0.5

//  Left -> x = -0.2 
//  Right -> x = 0.2
//  Up -> z = 0.2
//  Down -> z = -0.2