using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Transform m_Transform;
    NavMeshAgent m_Agent;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Animator animator;
    [SerializeField] Transform cameraTransform;

    private bool canMove = true;

    private void Start()
    {
        m_Transform = transform;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.updateRotation = false; 
    }

    private void Update()
    {
        if (!canMove) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 direction = cameraForward * vertical + cameraRight * horizontal;
        direction.Normalize();

        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("Walk", true);

            m_Agent.Move(direction * moveSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            m_Transform.rotation = Quaternion.Slerp(m_Transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    public void SetMovement(bool enable)
    {
        canMove = enable;
        m_Agent.isStopped = !enable;
    }
}