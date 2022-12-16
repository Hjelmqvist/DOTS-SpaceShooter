using Unity.Entities;
using Unity.Jobs;

public partial class AgeLaserSystem : SystemBase
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

        float deltaTime = Time.DeltaTime;
        
        Entities.ForEach((Entity entity, ref Laser laser) => {
            laser.Age += deltaTime;
            if (laser.Age >= laser.MaxAge)
            {
                buffer.DestroyEntity(entity);
            }
        }).Schedule();

        commandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}