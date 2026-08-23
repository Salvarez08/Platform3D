using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image HealthCounter;

    private void Start()

    {
        HealthCounter.color = Color.cyan;
        HealthCounter.fillAmount = 1;
    }
    public void HealthColor(Color color)
    {
        HealthCounter.color = color;

    }

    public void FillAmount_HealthColor(float fillAmount)
    {
        HealthCounter.fillAmount = fillAmount;
    }
}

