using System.Collections.Generic;
using UnityEngine;


namespace Mushroom_Angels_Games
{
    #region Suport 
    /// <summary>
    /// By: Luiz Felipe Marian
    /// Mushroom Angels Games
    /// Suport : https://www.mushroomangelsgames.com/
    /// </summary>
    #endregion

    public class StaticList_Update : MonoBehaviour
    {
        #region Variables
        private static List<UpdateScreenUI_Interface> AllScreenNeedUpdate = new List<UpdateScreenUI_Interface>(); 
        #endregion

        #region  Unity Voids

        private void Awake()
        {
            //Clear static variable to not contain data from other scenes
            AllScreenNeedUpdate.Clear();
        }
        #endregion

        #region Class Voids
        /// <summary> Add Item on screen update. </summary>
        public static void InsertInListUpdate(UpdateScreenUI_Interface ThisScreenNeedInsert)
        {
            //Checks if you have the item in the list, to not allow repeated calls.
            if (CheckContains(ThisScreenNeedInsert))
                return;
         
            AllScreenNeedUpdate.Add(ThisScreenNeedInsert);
        }

        //private
        private static bool CheckContains(UpdateScreenUI_Interface ItemCheck)
        {
            //Checks if you have the item in the list, to not allow repeated calls.
            if (AllScreenNeedUpdate.Contains(ItemCheck))
                return true;

            return false;
        }

        /// <summary> Remove Item from Screen Update </summary>
        public static void RemoveFromList(UpdateScreenUI_Interface ThisScreenNeedInsert)
        {
            //Checks if you have the item on the list
            if (!CheckContains(ThisScreenNeedInsert))
                return;

            //remove
            AllScreenNeedUpdate.Remove(ThisScreenNeedInsert);
        }

        /// <summary> Make Update to the screen now </summary>  
        public static void InvokeUpdateScreen()
        {
            //Make a call on all screens that need to resize
            AllScreenNeedUpdate.ForEach(ss =>
            {
                if (ss != null)
                    ss.UpdateScreenNow();

            });
        }
        #endregion
    }
}
