using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private int coinCount = 0;
    private bool isGameOver = false;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("Yig‘ilgan tangalar: " + coinCount);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}