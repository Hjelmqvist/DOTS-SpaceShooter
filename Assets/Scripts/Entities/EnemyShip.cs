using System;
using Unity.Entities;

[Serializable]
public struct EnemyShip : IComponentData
{
    public float StartX;
    public float MoveRange;
}