using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Image _filter;

    protected void OnValueChanged(float value) => _filter.fillAmount = value;
}
