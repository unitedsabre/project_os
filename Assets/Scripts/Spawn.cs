using UnityEngine;

public class Column : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.0f; // Частота появления труб
    public float minHeight = -1.0f; // Минимальная высота для появления трубы
    public float maxHeight = 1.0f; // Максимальная высота для появления трубы

    private void OnEnable()
    {
        // Вызов метода Spawn с определенной периодичностью
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Отмена повторения вызова метода Spawn
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Создание экземпляра трубы и ее позиционирование в пределах указанных высот
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}