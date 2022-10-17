using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MEC;

namespace Meta.VR
{

    public class TouchableBehaviour : BaseTouchable
    {

        public Action onTouch = () => { };

        protected override void OnTouch()
        {
            onTouch.Invoke();
        }

    }

}