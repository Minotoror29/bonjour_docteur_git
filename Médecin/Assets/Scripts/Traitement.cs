using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Traitement : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    GameManager gm;
    GameObject dragDropPrefab;
    GameObject dragDropInstance;

    public TRAITEMENTS traitement;

    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        dragDropPrefab = gm.dragDropPrefab;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

        dragDropInstance = Instantiate(dragDropPrefab, transform);
        dragDropInstance.GetComponent<Text>().text = GetComponent<Text>().text;
        dragDropInstance.GetComponent<Traitement>().traitement = traitement;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        dragDropInstance.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        Destroy(dragDropInstance);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }
}
