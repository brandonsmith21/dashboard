using UnityEngine;

namespace Mushroom_Angels_Games
{
    public class InternalClassResponsive : MonoBehaviour , UpdateScreenUI_Interface
    {
        #region Suport 
        /// <summary>
        /// By: Luiz Felipe Marian
        /// Mushroom Angels Games
        /// Suport : https://www.mushroomangelsgames.com/
        /// </summary>
        #endregion

        protected void InitializedClass() =>
          StaticList_Update.InsertInListUpdate(this);

        protected void DestroyThisGameObject() => 
          StaticList_Update.RemoveFromList(this);

        //Virtual
        public virtual void UpdateScreenNow() { }
     
    }
}