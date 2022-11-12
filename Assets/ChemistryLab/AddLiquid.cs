using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySimpleLiquid
{

    public class AddLiquid : MonoBehaviour
    {

        // Start is called before the first frame update
        private LiquidContainer liquidContainer;
        bool full = false;

        private void Awake()
        {
            liquidContainer = GetComponent<LiquidContainer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (liquidContainer.FillAmountPercent<0.1f)
            {
                liquidContainer.FillAmountPercent = 0.8f;
                print("will be full");
                full = true;

            }
            else if (full)
            {
                GetComponent<AddLiquid>().enabled = false;
                print("will disable script full");

            }
        }
    }
}
