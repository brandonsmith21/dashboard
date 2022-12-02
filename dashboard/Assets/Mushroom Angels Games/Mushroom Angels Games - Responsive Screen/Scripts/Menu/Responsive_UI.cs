using UnityEngine;
using UnityEngine.UI;

namespace Mushroom_Angels_Games
{
    #region Suport 
    /// <summary>
    /// By: Luiz Felipe Marian
    /// Mushroom Angels Games
    /// Suport : https://www.mushroomangelsgames.com/
    /// </summary>
    #endregion

    public class Responsive_UI : InternalClassResponsive
    {
        #region Variables
        //Force Publics
        [Header("Configure UI Adaptation")]
        [Tooltip("Use to adjust screen scalability")]
        [SerializeField] private float widthAdpatation = 0.5625f;
        [Space(5)]
        [Tooltip("This is a reference to use to configure the screen size")]
        [SerializeField] private Vector2 referenceResolution = new Vector2(1920, 1080);
        [Space(5)]
        [Header("Update With Frequency")]
        [Range(1,25)][Tooltip("Time in seconds for rescanning and updating the screen")]
        [SerializeField] private float updateFrequency = 5;
        [SerializeField][Tooltip("ATTENTION : Constantly refreshing the screen may cause loss of FPS.")] 
        private bool refreshScreenConstantly = false;

        [Space(5)]
        [Header("Update With Constantly")]
        [SerializeField]
        [Tooltip("ATTENTION : Constantly refreshing the screen may cause loss of FPS.")]
        private bool updateAllTheTime = false;

        //Privates
        private float screenWidth;
        private float screenHeight;
        private CanvasScaler canvasScaler;

        #endregion

        #region Unity Voids

        private void OnEnable() => GetScreenCurrectSize();

        private void Start()
        {
            InitializedClass();
            CheckUseConstantly();
            InitializedClassThis();
            GetScreenCurrectSize();
        }

        private void FixedUpdate()
        {
            if (!updateAllTheTime)
                return;

            GetScreenCurrectSize();
        }

        private void OnDestroy()
        {
            //Function inherited from parent class, remove this item from update list
            DestroyThisGameObject();

            //automatic repetition system is canceled
            if (refreshScreenConstantly)
                CancelInvoke("GetScreenCurrectSize");
        }

        #endregion

        #region Class Voids

        private void CheckUseConstantly()
        {
            //Check use constantly Update
            if (!refreshScreenConstantly)
                return;

            //automatic repetition system
            InvokeRepeating("GetScreenCurrectSize", updateFrequency, updateFrequency);
        }

        private void InitializedClassThis()
        {
            try
            {
                //Configure Canvas
                canvasScaler = transform.GetComponentInParent<CanvasScaler>();
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasScaler.referenceResolution = referenceResolution;
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                canvasScaler.matchWidthOrHeight = 1;
                canvasScaler.referencePixelsPerUnit = 100;
            }
            catch { }
        }

        private void GetScreenCurrectSize()
        {
            //Restore original screen size
            screenWidth = Screen.width;
            screenHeight = Screen.height;

            //Update Screen size
            transform.localScale = new Vector3((widthAdpatation * screenWidth / screenHeight), 
                transform.localScale.y, transform.localScale.z);
        }

        #endregion

        #region Interfaces

        /// <summary>This Interface is called every time you request and refresh the screen. </summary>
        public override void UpdateScreenNow() => GetScreenCurrectSize();
        #endregion
    }

}