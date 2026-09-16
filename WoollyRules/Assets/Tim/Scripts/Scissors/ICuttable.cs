namespace WoollyRules
{
    public interface ICuttable 
    {
        bool RuleBrokenOnCut { get; }
        bool BlockHover { get; }
        bool BlockCut { get; }
        bool HasSoundWhenCut { get; }
        public void Cut();
    }
}