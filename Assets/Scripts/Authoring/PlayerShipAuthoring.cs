using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerShipAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] float movementSpeed = 1;    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PlayerShip { MovementSpeed = movementSpeed });
    }
} 