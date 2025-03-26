using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // ����, �� ������� ������� ������ (��� ��������)

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f; // �������� �������� �����������
    public Vector3 offset; // �������� ������ ������������ ����

    [Header("Bounds Settings")]
    public bool useBounds = false; // ������������ �� �������� ������
    public Vector2 minBounds; // ����������� ���������� (����� ������ ����)
    public Vector2 maxBounds; // ������������ ���������� (������ ������� ����)

    private void Start()
    {
        if (target == null)
            target = G.playerTransform;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        // ��������� �������� ������� ������
        Vector3 desiredPosition = target.position + offset;

        // ������ ���������� ������ � �������� �������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 60);
        transform.position = smoothedPosition;

        // ���� �������� �������, ������������ ������� ������
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
