using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovePlayerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float3 direction = new float3(horizontal, 0, 0) * Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in PlayerShip ship) =>
        {
            translation.Value += direction * ship.MovementSpeed;
        }).Run();
    }
}