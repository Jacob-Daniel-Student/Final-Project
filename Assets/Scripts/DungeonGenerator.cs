using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : AbstractDungeonGenerator
{

    [SerializeField] protected SimpleRandomWalkSO randomWalkParameters;
    protected override void RunProceduralGeneration() 
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tileMapVisualizer.Clear();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position) 
    {
        var curentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for(int i = 0; i < parameters.iterations; i++) 
        {
            var path = ProceduralGenerationAlgorithims.SimpleRandomWalk(curentPosition, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
                curentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
                
        }
        return floorPositions;
    }
}
