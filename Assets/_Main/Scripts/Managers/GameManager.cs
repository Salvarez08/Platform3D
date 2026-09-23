using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private int Life = 100;
    [SerializeField] private PlayerMovement Player;
    [SerializeField] private UIManager UImanager;
    [SerializeField] private bool[] Notes = new bool[3];
    [SerializeField] private Collider doorCollider;
    [SerializeField] private Renderer doorRenderer;
    
    [Header("UI Reference")]
    public GameObject objectPauseMenu;
    public GameObject objectPauseButton;
    public GameObject objectLossMenu;


    [HideInInspector]
    public bool gamePaused = false;

    private bool isShielded = false;
    private Coroutine shieldCoroutine;


    public void getNote(int noteNumber)
    {
     
        if (noteNumber >= 0 && noteNumber < Notes.Length)
        {
            Notes[noteNumber] = true; 

            UImanager.PickUpObject(noteNumber);

            CheckNotes(); 
        }
    }

    private void CheckNotes()
    {
        for (int i = 0; i < Notes.Length; i++)
        {
            if (Notes[i] == false)
            {
                return;
            }
        }

        OpenDoor();
    }

    private void OpenDoor()
    {
        doorCollider.isTrigger = true;
        doorRenderer.enabled = false;
    }

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

        if (Life <= 0) // PDHEWYUGVBUSHDBGVBREWUIGJVBNRJKGBVNJKSBNJVKSDBNVJKSDNJKVBDSHJKBVHJDSBVHJDSFB VHJDSFB 
        {
            Loss();
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
        Life = Mathf.Min(Life + amount, 100); 
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
        Player.SetShieldVisible(true);

        yield return new WaitForSeconds(duration);

        isShielded = false;
        Player.SetShieldVisible(false);
        shieldCoroutine = null;
    }

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        Player.SpeedMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        Player.SpeedMultiplier = 1f;
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Unpause()
    {
        objectPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        objectPauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Loss()
    {
        Time.timeScale = 0f;
        objectLossMenu.SetActive(true);
        objectPauseButton.SetActive(false);
        gamePaused = true;
    }
}
