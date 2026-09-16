namespace WoollyRules
{
    public interface ICuttable 
    {
        bool RuleBrokenOnCut { get; }
        bool Ignore { get; }
        public void Cut();
    }
}