using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovePlayerSystem : SystemBase
{
    const float CameraBoundsPadding = 0.3f;

    protected override void OnUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float3 direction = new float3(horizontal, 0, 0);
        float deltaTime = Time.DeltaTime;

        Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log(cameraBounds);

        Entities.ForEach((ref Translation translation, in PlayerShip ship) =>
        {
            float x = translation.Value.x + horizontal * ship.MovementSpeed * deltaTime;
            x = Mathf.Clamp(x, -cameraBounds.x + CameraBoundsPadding, cameraBounds.x - CameraBoundsPadding);
            translation.Value.x = x;
        }).Run();
    }
}