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

            Health health;
            Laser laser;

            if (HealthGroup.TryGetComponent(entityA, out health) && LaserGroup.TryGetComponent(entityB, out laser))
            {
                health.Value -= 1;
                Buffer.SetComponent(entityA, health);
                Buffer.DestroyEntity(entityB);
            }
            else if (HealthGroup.TryGetComponent(entityB, out health) && LaserGroup.TryGetComponent(entityA, out laser))
            {
                health.Value -= 1;
                Buffer.SetComponent(entityB, health);
                Buffer.DestroyEntity(entityA);
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
