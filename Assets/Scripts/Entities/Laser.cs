using System;
using Unity.Entities;

[Serializable]
public struct Laser : IComponentData
{
    public float MoveSpeed;
}