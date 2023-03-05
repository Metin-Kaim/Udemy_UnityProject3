using UdemyProject3.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject3.UIs
{
    public class StartButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleButtonOnClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleButtonOnClicked);
        }

        private void HandleButtonOnClicked()
        {
            GameManager.Instance.LoadLevel("game");
        }
    }
}
