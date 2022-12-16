using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovePlayerSystem : SystemBase
{
    const float BoundsXPadding = 0.3f;
    const float BoundsYPadding = 0.5f;

    protected override void OnUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
            return;

        float3 direction = new float3(horizontal, vertical, 0);
        direction = math.normalize(direction);

        float deltaTime = Time.DeltaTime;

        Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log(cameraBounds);

        Entities
            .WithAll<PlayerTag>()
            .ForEach((ref Translation translation, in Ship ship) =>
        {
            direction *= ship.MoveSpeed * deltaTime;
            float3 newPosition = translation.Value + direction;
            newPosition.x = Mathf.Clamp(newPosition.x, -cameraBounds.x + BoundsXPadding, cameraBounds.x - BoundsXPadding);
            newPosition.y = Mathf.Clamp(newPosition.y, -cameraBounds.y + BoundsYPadding, cameraBounds.y - BoundsYPadding);
            translation.Value = newPosition;
        }).Run();
    }
}