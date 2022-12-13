using Unity.Entities;
using Unity.Properties.UI;
using UnityEngine;

[DisallowMultipleComponent]
public class HealthAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField, MinValue(1)] int maxHealth = 3;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Health 
        { 
            Value = maxHealth, 
            MaxHealth = maxHealth,
        });
    }
}