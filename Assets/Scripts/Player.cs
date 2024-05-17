using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction; // ����������� �������� ������
    public float gravity = -9.8f; // ����������, �������������� �� ������
    public float strength = 5f; // ���� ������ ������


    private void Awake()
    {
        // ������ ����� Awake, �� �������� �������� ��� ������������� �������
    }

    private void Start()
    {
        // ���������� ��������� ������ OnTriggerEnter2D � ������������ ��������������
        InvokeRepeating(nameof(OnTriggerEnter2D), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        // ��������� ��������� ������� ������ �� ������ 0 � ��������� �����������
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // ���������� ����������� � ����������� �� ������� ������� ������ ��� ���������� ��������������
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

        // ���������� ���������� � ����������� �������� � ���������� ������� ������
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ������������ � ������������� � ��������� ��� ���������� �����
        if (other.gameObject.tag == "Obstacle")
        {
            // ����� ������ ���������� ���� ��� ������������ � ������������
            FindObjectOfType<Manager>().GameOver();
        } else if (other.gameObject.tag == "Scoring")
        {
            // ����� ������ ���������� ����� ��� ������������ � �������� ��� ���������� �����
            FindObjectOfType<Manager>().IncreaseScore();
        }
        
    }
}
