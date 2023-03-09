using UdemyProject3.Abstracts.UIs;
using UdemyProject3.Managers;

namespace UdemyProject3.UIs
{
    public class PlayerAddButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.IncreasePlayerCount();
        }

    }
}
