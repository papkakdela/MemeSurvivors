using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // ÷ель, за которой следует камера (ваш персонаж)

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f; // —корость плавного перемещени€
    public Vector3 offset; // —мещение камеры относительно цели

    [Header("Bounds Settings")]
    public bool useBounds = false; // ќграничивать ли движение камеры
    public Vector2 minBounds; // ћинимальные координаты (левый нижний угол)
    public Vector2 maxBounds; // ћаксимальные координаты (правый верхний угол)

    private void Start()
    {
        if (target == null)
            target = G.playerTransform;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        // ¬ычисл€ем желаемую позицию камеры
        Vector3 desiredPosition = target.position + offset;

        // ѕлавно перемещаем камеру к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 60);
        transform.position = smoothedPosition;

        // ≈сли включены границы, ограничиваем позицию камеры
        if (useBounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
                transform.position.z
            );
        }
    }
}
