namespace Xamarin.Presentation.Framework.VSVVM {
    public abstract class BaseViewState : BaseNotify {
        private readonly object _lock = new object();
        public void Push(params (string name, object value)[] properties) {
            //DispatcherEx.BeginRise(() => {
                foreach ((string name, object value) expression in properties) {
                    var property = GetType().GetProperty(expression.name);
                    object prev = property.GetValue(this);
                    if (Update(ref prev, expression.value, expression.name)) {
                        property.SetValue(this, expression.value);
                    }
                }
            //});
        }
        public void ForcePush(params string[] names) {
            foreach (string name in names) {
                SetPropertyChanged(name);
            }
        }
    }
}
