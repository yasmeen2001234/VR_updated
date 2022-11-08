using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySimpleLiquid
{
    public class RemoveLiquid : MonoBehaviour
    {
        // Start is called before the first frame update
        private LiquidContainer liquidContainer;
        bool empty = false;
        private void Awake()
        {
            liquidContainer = GetComponent<LiquidContainer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (liquidContainer.FillAmountPercent > 0.01f)
            {
                liquidContainer.FillAmountPercent = 0.0f;
                print("will be empty");
                empty = true;

            }
            else if (empty)
            {
                print("will disable script empty");

                GetComponent<RemoveLiquid>().enabled = false;
            }
        }
    }
}
