using UnityEngine;
using System.Collections; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Life = 100;
    [SerializeField] private PlayerMovement Player;
    [SerializeField] private UIManager UImanager;
    private bool isShielded = false;
    private Coroutine shieldCoroutine;


    public void ReduceHealth(int _Damage)
    {
        if (isShielded)
        {
            return; 
        }

        if (Life > 0)
        {
            Life -= _Damage;
            UImanager.HealthColor(Color.red);
            UImanager.FillAmount_HealthColor(Life / 100f);
        }

        if (Life <= 0)
        {
            Destroy(Player.gameObject);
        }

        switch (Life)
        {
            case int Health when Health >= 80:
                UImanager.HealthColor(Color.green);
                break;

            case int n when n < 20:
                UImanager.HealthColor(Color.darkRed);
                break;

            case int n when n < 80:
                UImanager.HealthColor(Color.orange);
                break;
        }
    }
    public void IncreaseHealth(int amount)
    {
        Life = Mathf.Min(Life + amount, 100); // no pasar de 100
        UImanager.FillAmount_HealthColor(Life / 100f);
    }

    public void ActivateShield(float duration)
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }

        shieldCoroutine = StartCoroutine(ShieldRoutine(duration));
    }

    private IEnumerator ShieldRoutine(float duration)
    {
        isShielded = true;

        yield return new WaitForSeconds(duration); 

        isShielded = false;
        shieldCoroutine = null;
    }

}
