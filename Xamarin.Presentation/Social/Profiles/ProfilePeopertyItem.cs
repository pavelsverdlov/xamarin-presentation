namespace Xamarin.Presentation.Social.Profiles {
    public class ProfilePeopertyItem {
        public ProfilePeopertyItem() { }
        public ProfilePeopertyItem(string property, string value) {
            Property = property.ToUpper();
            Value = value;
        }

        public string Property { get; set; }
        public string Value { get; set; }
    }
}
