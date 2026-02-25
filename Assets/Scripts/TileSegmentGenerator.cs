using UnityEngine;
using System.Collections.Generic;

public class TileSegmentGenerator : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 spawnPos { get; private set; }

    public Vector2 finalSpawnPos { get; private set; } = new Vector2();

    [field: SerializeField]
    public Vector2 spawnPosOffset { get; private set; } = new Vector2();

    [field: SerializeField]
    private float Size;
    [field: SerializeField]
    public List<collectionOfTiles> layers = new List<collectionOfTiles>();

    public List<collectionOfTiles> instantiatedLayers { get; private set; } = new List<collectionOfTiles>();
    
    void Start()
    {
        const int NAN_OFFSET = 1;
        float YSize = GetAverageLayerYSize(layers);
        for(int i = 0; i < layers.Count; i++)
        {
            instantiatedLayers.Add(new collectionOfTiles());
            
            Debug.Log(instantiatedLayers);
            float avgSize = GetAverageLayerXSize(layers[i].tiles);
            for (int ii = 0; ii < layers[i].tiles.Count; ii++)
            {
                GameObject newTile = layers[i].tiles[ii];
                float spawnPosX = spawnPos.x + (avgSize * ii);
                float spawnPosY = spawnPos.y + (YSize * (i + NAN_OFFSET));
                
                Debug.Log(avgSize);
                Debug.Log(spawnPosY);
                newTile.transform.position = new Vector2(spawnPosX * spawnPosOffset.x, spawnPosY * spawnPosOffset.y);
                
                GameObject instantiatedNewTile = Instantiate(newTile, transform);
                instantiatedLayers[i].tiles.Add(instantiatedNewTile);
            }
            
        }
    }

    float GetAverageLayerXSize(List<GameObject> tiles)
    {
        float totalX = 0;
        float divisionPoint = tiles.Count;
        foreach (GameObject layers in tiles)
        { 
            totalX += layers.transform.localScale.x;
        }
        
        float average = totalX / divisionPoint;

        return average;
    }
    
    
    float GetAverageLayerYSize(List<collectionOfTiles> layers)
    {
        float totalY = 0;
        float  divisionPoint = layers.Count;
        float average = 0;
        foreach (collectionOfTiles layer in layers)
        {
            float layerY = 0;
            float perLayerDivisionPoint = layer.tiles.Count;
            Debug.Log(layer.tiles.Count);
            foreach (GameObject tile in layer.tiles)
            {
                layerY += tile.transform.localScale.y;
            }
            average += layerY / perLayerDivisionPoint;
        }
        
        float finalAverage = average / divisionPoint;

        return finalAverage;
    }
}

[System.Serializable]
public class collectionOfTiles
{
    public List<GameObject> tiles = new List<GameObject>();
}