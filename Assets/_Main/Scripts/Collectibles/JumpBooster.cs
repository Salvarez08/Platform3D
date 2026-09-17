using System.Collections;
using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 5f;

    private Collider _collider;
    private Renderer _renderer;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisableAndRespawnRoutine());
        }
    }

    private IEnumerator DisableAndRespawnRoutine()
    {
        yield return new WaitForFixedUpdate();

        SetBoosterState(false);

        yield return new WaitForSeconds(respawnDelay);

        SetBoosterState(true);
    }

    private void SetBoosterState(bool isActive)
    {
        if (_collider != null) _collider.enabled = isActive;
        if (_renderer != null) _renderer.enabled = isActive;
    }
}