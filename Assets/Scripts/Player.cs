using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction; // Направление движения игрока
    public float gravity = -9.8f; // Гравитация, воздействующая на игрока
    public float strength = 5f; // Сила прыжка игрока


    private void Awake()
    {
        // Пустой метод Awake, не содержит действий при инициализации объекта
    }

    private void Start()
    {
        // Регулярное вызывание метода OnTriggerEnter2D с определенной периодичностью
        InvokeRepeating(nameof(OnTriggerEnter2D), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        // Установка начальной позиции игрока на высоте 0 и обнуление направления
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // Обновление направления в зависимости от нажатия клавиши пробел или сенсорного взаимодействия
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        // Применение гравитации к направлению движения и обновление позиции игрока
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Обработка столкновений с препятствиями и объектами для увеличения счета
        if (other.gameObject.tag == "Obstacle")
        {
            // Вызов метода завершения игры при столкновении с препятствием
            FindObjectOfType<Manager>().GameOver();
        } else if (other.gameObject.tag == "Scoring")
        {
            // Вызов метода увеличения счета при столкновении с объектом для увеличения счета
            FindObjectOfType<Manager>().IncreaseScore();
        }
        
    }
}
