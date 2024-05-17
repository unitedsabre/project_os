using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f; // Скорость движения труб
    private float leftEdge; // Координата левого края экрана

    private void Start()
    {
        // Определение координаты X левого края экрана с учетом смещения на 1 единицу
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Перемещение труб влево с учетом скорости и времени
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Условие проверки, достигла ли труба левого края экрана, и ее уничтожение, если это так
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
