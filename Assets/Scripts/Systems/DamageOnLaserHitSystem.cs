using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

public partial class DamageOnLaserHitSystem : SystemBase
{
    private StepPhysicsWorld stepPhysicsWorld;
    EndSimulationEntityCommandBufferSystem commandBufferSystem;

    protected override void OnCreate()
    {
        base.OnCreate();
        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    struct DamageOnLaserHitJob : ITriggerEventsJob
    {
        [ReadOnly] public ComponentDataFromEntity<Health> HealthGroup;
        [ReadOnly] public ComponentDataFromEntity<Laser> LaserGroup;
        public EntityCommandBuffer Buffer;

        public void Execute(TriggerEvent triggerEvent)
        {
            Entity entityA = triggerEvent.EntityA;
            Entity entityB = triggerEvent.EntityB;

            bool aHealth = HealthGroup.HasComponent(entityA);
            bool bHealth = HealthGroup.HasComponent(entityB);

            bool aLaser = LaserGroup.HasComponent(entityA);
            bool bLaser = LaserGroup.HasComponent(entityB);


            // Should actually get Health and decrease Value by 1 but it wont work and I'm sick
            if (aHealth && bLaser)
            {
                Buffer.DestroyEntity(entityA);
                Buffer.DestroyEntity(entityB);
            }
            else if (bHealth && aLaser)
            {
                Buffer.DestroyEntity(entityA);
                Buffer.DestroyEntity(entityB);
            }
        }
    }

    protected override void OnUpdate()
    {
        var job = new DamageOnLaserHitJob
        {
            HealthGroup = GetComponentDataFromEntity<Health>(true),
            LaserGroup = GetComponentDataFromEntity<Laser>(true),
            Buffer = commandBufferSystem.CreateCommandBuffer()
    };

        JobHandle jobHandle = job.Schedule(stepPhysicsWorld.Simulation, this.Dependency);
        jobHandle.Complete();
    }
}
