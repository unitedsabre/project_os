using UnityEngine;

public class Parallax : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f; // �������� �������� ��������

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // ��������� ���������� MeshRenderer ��� ������� ��������
    }

    private void Update()
    {
        // ���������� �������� �������� ��� �������� ������� ���������� �� ��� X
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
