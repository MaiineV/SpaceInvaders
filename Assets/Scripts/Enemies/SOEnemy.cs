using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy", fileName = "Enemy")]
public class SOEnemy : ScriptableObject
{
    public float life;
    public float speed;
    public float dmg;
    public float attackSpeed;
    public Vector3 colliderSize;
}
