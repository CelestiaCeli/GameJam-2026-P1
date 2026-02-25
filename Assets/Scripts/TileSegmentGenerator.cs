using UnityEngine;
using System.Collections.Generic;

public class TileSegmentGenerator : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 spawnPos { get; private set; }

    public Vector2 finalSpawnPos { get; private set; } = new Vector2();
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

                GameObject instantiatedNewTile = Instantiate(newTile);
                float spawnPosX = spawnPos.x + (avgSize * ii);
                float spawnPosY = spawnPos.y + (YSize * (i + NAN_OFFSET));
                
                newTile.transform.position = new Vector2(spawnPosX, spawnPosY);
                instantiatedLayers[i].tiles.Add(newTile);
            }
            
        }
    }

    float GetAverageLayerXSize(List<GameObject> tiles)
    {
        float totalX = 0;
        float divisionPoint = tiles.Count;
        foreach (GameObject layers in tiles)
        { 
            totalX += layers.GetComponent<SpriteRenderer>().sprite.border.x;
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
                layerY += tile.GetComponent<SpriteRenderer>().sprite.border.y;
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
