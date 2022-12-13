using System;
using Unity.Entities;

[Serializable]
public struct Health : IComponentData
{
    public int Value;
    public int MaxHealth;
    public bool IsAlive => Value > 0;
}