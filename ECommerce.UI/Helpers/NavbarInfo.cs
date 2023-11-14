namespace ECommerce.UI.Helpers
{
    public class NavbarInfo
    {
        public string ControllerName { get; set; }
        public string ControllerDisplayName { get; set; }
        public string ActionName { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string SubTitleUrl => $"/Admin/{ControllerName}/Index";
        public string ButtonName { get; set; }
        public string ButtonUrl { get; set; }
    }
}
