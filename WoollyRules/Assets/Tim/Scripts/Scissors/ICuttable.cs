using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public interface ICuttable 
    {
        bool RuleBrokenOnCut { get; }
        bool BlockHover { get; }
        bool BlockCut { get; }
        bool IsButton { get; }
        public void Cut();
    }
}