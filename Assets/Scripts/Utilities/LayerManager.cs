using UnityEngine;

public static class LayerManager
{
    //Layers
    private static int ObstacleLayer = 6; 
    private static int EnemyLayer = 7;

    //Mask
    public static LayerMask EnemyMask = 1 << EnemyLayer;
    public static LayerMask ObstacleMask = 1 << ObstacleLayer;
}
