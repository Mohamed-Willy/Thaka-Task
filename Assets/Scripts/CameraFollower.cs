using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform PlayerToFollow;
    [SerializeField] Vector3 Offset = new(0, 5, -10);
    [SerializeField] float FollowSpeed = 5f;
    [SerializeField] float RotationSpeed = 5f;

    private bool isFollowing = true;

    private float xRot = 0f;
    private float yRot = 20f;

    private void LateUpdate()
    {
        if (PlayerToFollow == null || !isFollowing)
            return;

        Quaternion rotation = Quaternion.Euler(yRot, xRot, 0);
        Vector3 rotatedOffset = rotation * Offset;

        Vector3 desiredPosition = PlayerToFollow.position + rotatedOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, FollowSpeed * Time.deltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(PlayerToFollow.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, RotationSpeed * Time.deltaTime);
    }

    public void SetFollowing(bool enable)
    {
        isFollowing = enable;
    }
}