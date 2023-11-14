namespace ECommerce.UI.Helpers
{
    public static class NavbarHelper //Sıngle Responsibility principle göre ;daha dar kapmasamlı bir isim verildi ve sadece Navabara ögü kodlar yer aldı.
    {
        public static string NavbarController(NavbarInfo navbarInfo)
        {
            if (navbarInfo.ControllerName != null)
            {
                switch (navbarInfo.ControllerName)
                {
                    case "About":
                        navbarInfo.ControllerDisplayName = "Hakkında";
                        break;
                    case "Role":
                        navbarInfo.ControllerDisplayName = "Rol";
                        break;
                    case "BodySize":
                        navbarInfo.ControllerDisplayName = "Beden";
                        break;
                    case "Brand":
                        navbarInfo.ControllerDisplayName = "Marka";
                        break;
                    case "Color":
                        navbarInfo.ControllerDisplayName = "Renk";
                        break;
                    case "Contact":
                        navbarInfo.ControllerDisplayName = "İletişim";
                        break;
                    case "Feature":
                        navbarInfo.ControllerDisplayName = "Özellik";
                        break;
                    case "GenreCategory":
                        navbarInfo.ControllerDisplayName = "Kategori Türü";
                        break;
                    case "MainCategory":
                        navbarInfo.ControllerDisplayName = "Ana Kategori";
                        break;
                    case "Service":
                        navbarInfo.ControllerDisplayName = "Servis";
                        break;
                    case "SocialMedia":
                        navbarInfo.ControllerDisplayName = "Sosyal Medya";
                        break;
                    case "Sponsor":
                        navbarInfo.ControllerDisplayName = "Sponsor";
                        break;
                    case "SubCategory":
                        navbarInfo.ControllerDisplayName = "Alt Kategori";
                        break;
                    case "SupportRequest":
                        navbarInfo.ControllerDisplayName = "Destek Talep";
                        break;
                    case "Tag":
                        navbarInfo.ControllerDisplayName = "Etiket";
                        break;
                    default:
                        return "Boş";
                }
            }

            if (navbarInfo.ActionName == "Index")
            {
                navbarInfo.MainTitle = $"{navbarInfo.ControllerDisplayName} Listesi";
                navbarInfo.SubTitle = $"{navbarInfo.ControllerDisplayName} Listesi";
                navbarInfo.ButtonName = $"Yeni {navbarInfo.ControllerDisplayName} Ekle";
                navbarInfo.ButtonUrl = $"/Admin/{navbarInfo.ControllerName}/Add{navbarInfo.ControllerName}";
                return navbarInfo.ToString();
            }
            else if (navbarInfo.ActionName == $"Add{navbarInfo.ControllerName}")
            {
                navbarInfo.MainTitle = $"{navbarInfo.ControllerDisplayName} Ekleme Sayfası";
                navbarInfo.SubTitle = $"{navbarInfo.ControllerDisplayName} Listesi";
                navbarInfo.ButtonName = $"{navbarInfo.ControllerDisplayName} Listesine Dön";
                navbarInfo.ButtonUrl = $"/Admin/{navbarInfo.ControllerName}/Index";
                return navbarInfo.ToString();
            }
            else if (navbarInfo.ActionName == $"Update{navbarInfo.ControllerName}")
            {
                navbarInfo.MainTitle = $"{navbarInfo.ControllerDisplayName} Güncelleme Sayfası";
                navbarInfo.SubTitle = $"{navbarInfo.ControllerDisplayName} Listesi";
                navbarInfo.ButtonName = $"{navbarInfo.ControllerDisplayName} Listesine Dön";
                navbarInfo.ButtonUrl = $"/Admin/{navbarInfo.ControllerName}/Index";
                return navbarInfo.ToString();
            }
            else if (navbarInfo.ActionName == "UserRoleList")
            {
                navbarInfo.MainTitle = "Kullanıcı Listesi";
                navbarInfo.SubTitle = "Kullanıcı Listesi";
                navbarInfo.ButtonName = "Yeni Kullanıcı Ekle";
                navbarInfo.ButtonUrl = "/Register/Index";
                return navbarInfo.ToString();
            }
            else if (navbarInfo.ActionName == "AssignRole")
            {
                navbarInfo.MainTitle = "Rol Atama Sayfası";
                navbarInfo.SubTitle = "Kullanıcı Listesi";
                navbarInfo.ButtonName = "Kullanıcılara Dön";
                navbarInfo.ButtonUrl = "/Admin/UserRoleList/Index";
                return navbarInfo.ToString();
            }

            return "";
        }
    }
}
