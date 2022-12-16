using Unity.Entities;
using Unity.Jobs;

public partial class DestroyDeadSystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem commandBufferSystem;

    protected override void OnCreate()
    {
        base.OnCreate();
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        EntityCommandBuffer buffer = commandBufferSystem.CreateCommandBuffer();

        Entities.ForEach((Entity entity, in Health health) => {
            if (!health.IsAlive)
            {
                buffer.DestroyEntity(entity);
            }
        }).Schedule();

        commandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}