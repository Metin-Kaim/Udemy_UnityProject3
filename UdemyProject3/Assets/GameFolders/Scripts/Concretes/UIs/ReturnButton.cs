using System;
using UdemyProject3.Abstracts.UIs;
using UdemyProject3.Managers;

namespace UdemyProject3.UIs
{
    public class ReturnButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ReturnMenu();
            
        }
    }
}
