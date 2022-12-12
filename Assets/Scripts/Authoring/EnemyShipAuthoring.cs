using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyShipAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] float moveRange = 1;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new EnemyShip { StartX = transform.position.x, MoveRange = moveRange });
    }
}