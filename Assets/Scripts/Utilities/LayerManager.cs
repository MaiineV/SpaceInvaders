using UnityEngine;

public static class LayerManager
{
    //Layers
    public static int EnemyLayer = 7;

    //Mask
    public static LayerMask EnemyMask = 1 << EnemyLayer;
}
