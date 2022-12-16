using Unity.Entities;

[GenerateAuthoringComponent]
public struct GameSettings : IComponentData
{
    public Entity PlayerLaser;

    public Entity EnemyShip;
    public Entity EnemyLaser;
}