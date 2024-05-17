using UnityEngine;

public class Parallax : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f; // Скорость анимации движения

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // Получение компонента MeshRenderer при запуске сценария
    }

    private void Update()
    {
        // Обновление смещения текстуры для создания эффекта параллакса по оси X
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
