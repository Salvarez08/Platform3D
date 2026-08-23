using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Life = 100;
    [SerializeField] private PlayerMovement Player;
    [SerializeField] private UIManager UImanager;


    public void ReduceHealth(int _Damage)
    {
        if (Life > 0)
        {
            Life -= _Damage;
            UImanager.HealthColor(Color.red);
            UImanager.FillAmount_HealthColor(Life / 100f);
        }

        if (Life <= 0)
        {
            Destroy(Player.gameObject);
            Debug.Log("Se muriooo");
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
}
