namespace Categorizr
{
    public class CategorizrOptions
    {
        public bool CategorizeTabletsAsDesktops { get; set; }
        public bool CategorizeTvsAsDesktops { get; set; }

        public static CategorizrOptions Default
        {
            get
            {
                return new CategorizrOptions
                {
                    CategorizeTabletsAsDesktops = false,
                    CategorizeTvsAsDesktops = false
                };
            }
        }
    }
}