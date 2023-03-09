using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UdemyProject3.Abstracts.UIs
{
    public abstract class MyButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        protected abstract void HandleOnButtonClicked();
    }
}
