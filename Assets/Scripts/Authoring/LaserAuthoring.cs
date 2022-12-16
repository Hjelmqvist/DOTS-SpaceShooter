using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class LaserAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float maxAge = 3;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Laser { MoveSpeed = moveSpeed, MaxAge = maxAge });
    }
}