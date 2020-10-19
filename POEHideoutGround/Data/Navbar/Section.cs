

using System.Collections.Generic;

namespace POEHideoutGround.Data.Navbar
{
    public class Section
    {
        public string DisplayName { get; set; }
        public string UniqueId { get; set; }
        public int Weight { get; set; }
        public string DataIcon { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }

}