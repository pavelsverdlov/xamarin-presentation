namespace Xamarin.Presentation.Framework.VSVVM {
    public abstract class BaseViewState : BaseNotify {
        private readonly object _lock = new object();
        public void Push(params (string name, object value)[] properties) {
            DispatcherEx.BeginRise(()=> {
                foreach (var expression in properties) {
                    var property = this.GetType().GetProperty(expression.name);
                    var prev = property.GetValue(this);
                    if (Update(ref prev, expression.value, expression.name)) {
                        property.SetValue(this, expression.value);
                    }
                }
            });
        }
    }
}
