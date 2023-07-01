using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class SingletonManager : SingletonMonoBehaviour<SingletonManager>
    {
        protected override bool dontDestroyOnLoad { get { return true; } }

        [SerializeField]
        private DataMnager _dataMnager;

        private DataMnager _data;
        public DataMnager Data => _data ? _data : _data = _dataMnager;

        [SerializeField]
        private PopupManager popupManager;

        private PopupManager _popup;
        public PopupManager Popup => _popup ? _popup : _popup = popupManager;
    }

}
