using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    // Biến public để chứa tên level (cảnh) tiếp theo cần tải
    public string GameLevel;

    // Hàm này sẽ được gọi để tải level mới
    public void NextLevel()
    {
        // Sử dụng SceneManager để load scene theo tên đã được gán
        SceneManager.LoadScene(GameLevel);
    }

    // Hàm này được gọi khi một đối tượng va chạm với collider của đối tượng này
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Player" hay không
        if (collision.CompareTag("Player"))
        {
            // Nếu là người chơi, gọi hàm NextLevel để tải cảnh tiếp theo
            NextLevel();
        }
    }
}
