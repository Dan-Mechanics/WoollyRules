namespace WoollyRules
{
    public interface ICuttable 
    {
        bool RuleBrokenOnCut { get; }
        bool IsButton { get; }
        public void Cut();
    }
}