using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MoveEnemySystem : SystemBase
{
    protected override void OnUpdate()
    {
        float time = UnityEngine.Time.time;

        Entities
            .ForEach((ref Translation translation, in EnemyShip ship) =>
        {
            float3 pos = translation.Value;
            pos.x = ship.StartX + Mathf.PingPong(time, ship.MoveRange);
            translation.Value = pos;
        }).ScheduleParallel();
    }
}