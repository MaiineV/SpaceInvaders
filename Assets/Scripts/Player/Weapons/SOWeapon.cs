using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons", fileName = "Weapon SO")]
public class SOWeapon : ScriptableObject
{
    public string bulletPrefabName;
    public float dmg;
    public float shootTime;
    public int magazineSize;
}
