using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image HealthCounter;
    public CanvasGroup targetCanvasGroup;


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

    public void PickUpObject()
    {
        if (targetCanvasGroup != null)
        {
            targetCanvasGroup.alpha = 1f; 
        }
    }
}

