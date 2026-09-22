using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MonsterRango : MonoBehaviour
{
    public NavMeshAgent Monster;
    public float Velocity;
    public bool Pursuing;
    public float Rank;
    float Distancia;

    public Transform Objective;


    private void Update()
    {
        Distancia = Vector3.Distance(Monster.transform.position, Objective.position);

        if (Distancia < Rank)
        {
            Pursuing = true;
            
        }
        else if (Distancia > Rank + 3)
        {
            Pursuing = false;
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Monster.transform.position, Rank);
    }
}
