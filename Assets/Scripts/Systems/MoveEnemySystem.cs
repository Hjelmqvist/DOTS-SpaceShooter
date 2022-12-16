using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public partial class MoveEnemySystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .WithAll<EnemyTag>()
            .ForEach((ref Translation translation, in Ship ship) =>
        {
            translation.Value.x -= ship.MoveSpeed * deltaTime;
        }).ScheduleParallel();
    }
}