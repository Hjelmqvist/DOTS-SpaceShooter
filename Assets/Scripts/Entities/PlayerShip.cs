using System;
using Unity.Entities;

[Serializable]
public struct PlayerShip : IComponentData
{
    public float MovementSpeed;
}