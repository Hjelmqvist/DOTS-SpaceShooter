using System.Diagnostics;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnEnemyLaserSystem : SystemBase
{
    //const float SpawnDistanceFromBorder = 1;
    //const float BoundsYPadding = 1f;
    //const float TimeBetweenEnemySpawn = 1f;

    //float timeSinceLastSpawn = 0;

    //private EntityQuery enemyQuery;
    //BeginSimulationEntityCommandBufferSystem commandBufferSystem;
    //Entity enemyPrefab;

    //protected override void OnCreate()
    //{
    //    base.OnCreate();

    //    enemyQuery = GetEntityQuery(ComponentType.ReadWrite<EnemyTag>());
    //    commandBufferSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    //}

    protected override void OnUpdate()
    {
    //    if (enemyPrefab == Entity.Null)
    //    {
    //        enemyPrefab = GetSingleton<GameSettings>().EnemyShip;
    //        return;
    //    }

    //    timeSinceLastSpawn += Time.DeltaTime;

    //    if (timeSinceLastSpawn < TimeBetweenEnemySpawn)
    //        return;

    //    timeSinceLastSpawn = 0;

    //    EntityCommandBuffer commandBuffer = commandBufferSystem.CreateCommandBuffer();
    //    Entity prefab = enemyPrefab;
    //    Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    //    var rand = new Unity.Mathematics.Random((uint)Stopwatch.GetTimestamp());

    //    Job.WithCode(() =>
    //    {
    //        float x = cameraBounds.x + SpawnDistanceFromBorder;
    //        float y = rand.NextFloat(-cameraBounds.y + BoundsYPadding, cameraBounds.y - BoundsYPadding);
    //        Translation pos = new Translation { Value = new float3(x, y, 0) };
    //        Entity e = commandBuffer.Instantiate(prefab);
    //        commandBuffer.SetComponent(e, pos);
    //    }).Schedule();

    //    commandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}