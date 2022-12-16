using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnPlayerLaserSystem : SystemBase
{
    const float TimeBetweenShots = 0.4f;

    float timeSinceLastShot = 0;

    BeginSimulationEntityCommandBufferSystem commandBufferSystem;
    Entity laserPrefab;

    protected override void OnCreate()
    {
        base.OnCreate();
        commandBufferSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        if (laserPrefab == Entity.Null)
        {
            laserPrefab = GetSingleton<GameSettings>().PlayerLaser;
            return;
        }

        timeSinceLastShot += Time.DeltaTime;

        if (Input.GetButton("Shoot") && timeSinceLastShot >= TimeBetweenShots)
        {
            timeSinceLastShot = 0;

            EntityCommandBuffer commandBuffer = commandBufferSystem.CreateCommandBuffer();
            Entity prefab = laserPrefab;

            Entities
               .WithAll<PlayerTag>()
               .ForEach((in Translation translation, in Ship ship) =>
           {
               Translation pos = new Translation { Value = translation.Value + ship.ShootOffset };
               Entity e = commandBuffer.Instantiate(prefab);
               commandBuffer.SetComponent(e, pos);

           }).Schedule();

            commandBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}