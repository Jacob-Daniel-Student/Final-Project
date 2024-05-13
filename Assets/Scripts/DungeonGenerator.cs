using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField] private int iterations = 10;
    [SerializeField] public int walkLength = 10;
    [SerializeField] public bool startRandomlyEachIteration = true;

    protected override void RunProceduralGeneration() 
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tileMapVisualizer.Clear();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk() 
    {
        var curentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for(int i = 0; i < iterations; i++) 
        {
            var path = RandomWalkAlgorithim.ProceduralGenerationAlgorithims.SimpleRandomWalk(curentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
                curentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
                
        }
        return floorPositions;
    }
}
