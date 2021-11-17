using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class ErrorsModel
    {

        private int currentErrors;
        private int maxErrors;

        public ErrorsModel()
        {
            this.maxErrors = Constants.maxErrors;
            currentErrors = 0;
        }

        public int ErrorDone()
        {
            return ++currentErrors;
        }

        public bool AreErrorsLeft()
        {
            if (maxErrors - currentErrors == -1)
            {
                //Debug.Log("false");
                return false;
            }
            //Debug.Log("true");
            return true;
        }

        public void Reset()
        {
            currentErrors = 0;
        }
    }
}
