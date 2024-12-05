using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Transform respawnPoint; // Điểm respawn được gán trong Inspector
    [SerializeField] GameObject player; // Gán nhân vật chính trong Inspector

    private string currentSceneName;

    private void Start()
    {
        // Lưu lại tên scene hiện tại khi bắt đầu game
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        // Lưu lại trạng thái hiện tại (nếu cần thiết) và load scene menu
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        // Đưa nhân vật trở lại điểm respawn
        player.transform.position = respawnPoint.position;

        // Reset trạng thái game nếu cần
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    // Phương thức này sẽ được gọi khi bạn quay lại scene game (từ menu)
    public void StartGame()
    {
        // Khi bắt đầu lại, load lại scene game ban đầu
        SceneManager.LoadScene(currentSceneName);
    }
}
