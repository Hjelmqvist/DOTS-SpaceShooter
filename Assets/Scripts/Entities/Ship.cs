using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Ship : IComponentData
{
    public float MoveSpeed;
    public float3 ShootOffset;
}