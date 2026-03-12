using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;

    public AudioClip hitSound;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
    {
        transform.position += GameManager.Instance.gameSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }

            // trigger camera shake
            FindObjectOfType<CameraShake>().Shake();

            GameManager.Instance.GameOver();
        }
    }
}
