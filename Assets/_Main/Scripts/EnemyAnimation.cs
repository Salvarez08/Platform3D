using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{

    public NavMeshAgent agent;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        bool walking = agent.velocity.magnitude > 0.1f;
        animator.SetBool("WalkCat", walking);
    }
}