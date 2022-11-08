using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageEffect : MonoBehaviour
{
    public Transform player;
    public float damage;
    public Color color;

    private TextMeshPro text;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private float destroyTime;
    private Color alpha;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.color = color;
        alpha = text.color;
        text.text = damage.ToString();

        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        transform.LookAt(player, Vector3.up);
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        text.color = alpha;
    }
}
