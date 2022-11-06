using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIRay : MonoBehaviour
{
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform dot;

    private void Update()
    {
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        RaycastHit hit;

        Debug.DrawRay(rightHand.position, rightHand.forward, Color.green, Time.deltaTime);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else
            {
                dot.gameObject.SetActive(false);
            }

            if (dot.gameObject.activeSelf)
            {
                if (OVRInput.GetDown(OVRInput.Button.Any))
                {
                    Button btn = hit.transform.GetComponent<Button>();
                    btn?.onClick?.Invoke();
                }
            }
        }
        else
        {
            dot.gameObject.SetActive(false);
        }
    }
}
