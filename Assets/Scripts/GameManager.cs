using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public Player player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    private int score;

    private void Awake() // Вызывается при запуске сценария
    {
        Application.targetFrameRate = 60; // Устанавливает цель кадров в секунду

        Pause();
    }

    public void Play() // Метод, вызываемый при нажатии кнопки "Воспроизведение"
    {
        score = 0;
        scoreText.text = score.ToString(); // Обновляет отображение счета на экране

        playButton.SetActive(false); // Деактивирует кнопку воспроизведения
        gameOver.SetActive(false); // Скрывает информацию о завершении игры

        Time.timeScale = 1f; // Устанавливает нормальную скорость воспроизведения времени
        player.enabled = true; // Активирует игрока

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // Находит все трубы в сцене
        for (int i = 0; i < pipes.Length; i++) // Цикл по всем найденным трубам
        {
            Destroy(pipes[i].gameObject); // Уничтожает каждую трубу
        }
    }

    public void Pause() // Метод для приостановки игры
    { 
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver() // Метод, вызываемый при завершении игры
    {
        gameOver.SetActive(true); 
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() // Метод для увеличения счета
    {
        score++;
        scoreText.text = score.ToString();
    }
}
