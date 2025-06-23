using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform PlayerToFollow;
    [SerializeField] Vector3 Offset = new(0, 5, -10);
    [SerializeField] float FollowSpeed = 5f;
    [SerializeField] float RotationSpeed = 5f;
    [SerializeField] float TouchSensitivity = 0.2f;

    private bool isFollowing = true;

    private float xRot = 0f;
    private float yRot = 20f;

    private Vector2 lastTouchPos;
    private bool isDragging = false;

    private void LateUpdate()
    {
        if (PlayerToFollow == null || !isFollowing)
            return;

        HandleTouchInput();

        Quaternion rotation = Quaternion.Euler(yRot, xRot, 0);
        Vector3 rotatedOffset = rotation * Offset;

        Vector3 desiredPosition = PlayerToFollow.position + rotatedOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, FollowSpeed * Time.deltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(PlayerToFollow.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, RotationSpeed * Time.deltaTime);
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 delta = touch.deltaPosition;

                xRot += delta.x * TouchSensitivity;
                yRot -= delta.y * TouchSensitivity;
                yRot = Mathf.Clamp(yRot, 10f, 80f);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }

    public void SetFollowing(bool enable)
    {
        isFollowing = enable;
    }
}