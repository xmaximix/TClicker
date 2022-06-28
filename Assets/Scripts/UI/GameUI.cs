using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] Game game;
    [SerializeField] TextMeshProUGUI currentEnemies;
    [SerializeField] TextMeshProUGUI killedEnemies;

    [SerializeField] Button freezeButton;
    [SerializeField] Button destroButton;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button menuButton;
    
    private void Awake()
    {
        EventManager.OnEnemyKilled.AddListener(UpdateCurrentEnemies);
        EventManager.OnEnemyKilled.AddListener(UpdateKilledEnemies);
        EventManager.OnEnemySpawned.AddListener(UpdateCurrentEnemies);      
        EventManager.OnGameFinished.AddListener(GameOver);

        freezeButton.onClick.AddListener(EventManager.SendFreezeActivated);
        freezeButton.onClick.AddListener(delegate { StartBoosterCooldown(freezeButton); });
        destroButton.onClick.AddListener(EventManager.SendDestroActivated);
        destroButton.onClick.AddListener(delegate { StartBoosterCooldown(destroButton); });

        playAgainButton.onClick.AddListener(PlayAgain);
        menuButton.onClick.AddListener(LoadMenu);
    } 

    private void UpdateCurrentEnemies()
    {
        currentEnemies.text = game.GetCurrentEnemies().ToString() + "/" + game.GetMaxEnemies().ToString();
    }

    private void UpdateKilledEnemies()
    {
        killedEnemies.text = "Убито монстров: " + game.GetKilledEnemies().ToString();
    }

    private void StartBoosterCooldown(Button button)
    {
        StartCoroutine(BoosterCooldownCoroutine(button));
    }
    private IEnumerator BoosterCooldownCoroutine(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(Random.Range(5f,25f));
        button.interactable = true;
    }

    private void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
