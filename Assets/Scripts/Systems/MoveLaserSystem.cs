using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public partial class MoveLaserSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in Laser laser) => {
            translation.Value.x += laser.MoveSpeed * deltaTime;
        }).Schedule();
    }
}