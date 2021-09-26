using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointOn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool is_kai = true;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(is_kai);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(!is_kai);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).gameObject.SetActive(!is_kai);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
