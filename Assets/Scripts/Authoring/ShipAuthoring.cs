using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class ShipAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 shootOffset;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Ship
        {
            MoveSpeed = moveSpeed,
            ShootOffset = shootOffset
        });
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + shootOffset, 0.1f); 
    }
}