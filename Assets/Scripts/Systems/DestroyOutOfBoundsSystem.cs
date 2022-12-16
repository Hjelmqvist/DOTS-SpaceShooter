using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public partial class DestroyOutOfBoundsSystem : SystemBase
{
    const float OutOfBoundsPadding = 3;

    EndSimulationEntityCommandBufferSystem commandBufferSystem;

    protected override void OnCreate()
    {
        base.OnCreate();
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        EntityCommandBuffer buffer = commandBufferSystem.CreateCommandBuffer();
        Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        Entities.ForEach((Entity entity, in Translation translation) => 
        {
            if (translation.Value.x < -cameraBounds.x - OutOfBoundsPadding)
            {
                buffer.DestroyEntity(entity);
            }
        }).Schedule();

        commandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}