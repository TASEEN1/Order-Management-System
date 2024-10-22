namespace PMS_BOL.Models
{
    public class MenuList
    {
        public string MenuText { get; set; }
        public string UserName { get; set; }
    }
    public class ButtonList
    {
        public string ButtonName { get; set; }
        public string Controller { get; set; } // URL Name
        public bool IsShow { get; set; }
        public string UserName { get; set; }
    }
}