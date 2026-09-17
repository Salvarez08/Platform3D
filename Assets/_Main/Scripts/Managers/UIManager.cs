using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image HealthCounter; 

   
    [SerializeField] private CanvasGroup[] targetCanvasGroups;

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

    
    public void PickUpObject(int noteIndex)
    {
        if (noteIndex >= 0 && noteIndex < targetCanvasGroups.Length)
        {
            if (targetCanvasGroups[noteIndex] != null)
            {
                targetCanvasGroups[noteIndex].alpha = 1f;
            }
        }
    }
}