using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private AudioSource _hoverSound;

    public void OnPointerEnter(PointerEventData eventData) {
        _hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData) {
        _hoverSound.Stop();
    }
}
