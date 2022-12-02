using UnityEngine;

namespace Mushroom_Angels_Games
{
    public class TestSimuletPauser : MonoBehaviour
    {
        public void UseTest()
        {
            //In order not to lose fps, it is recommended to update the screen only when the player changes the screen settings.
            //To do this, you must call this function whenever the settings have been changed:

            StaticList_Update.InvokeUpdateScreen();
        }
    }

}