using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Detección")]
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private Transform player; // se puede dejar vacío, se busca solo

    [Header("Rotación")]
    [SerializeField] private Transform turretHead; // la parte que gira (el "cañón")
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Disparo")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint; // punto desde donde sale la bala
    [SerializeField] private float fireRate = 2f; // disparos por segundo... en realidad, segundos entre disparos
    [SerializeField] private float bulletSpeed = 15f;

    private float fireCooldown = 0f;

    void Awake()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            RotateTowardsPlayer();
            HandleShooting();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.position - turretHead.position;
        direction.y = 0f; // que solo gire en el eje horizontal, no se incline hacia arriba/abajo

        if (direction.sqrMagnitude < 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        turretHead.rotation = Quaternion.Slerp(turretHead.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleShooting()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }

    // Para ver el rango de detección en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}