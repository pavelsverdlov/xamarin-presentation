using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Presentation.Controls._Entry {
    public class MaskedBehavior : Behavior<Entry> {
        private string _mask = "";
        public string Mask {
            get => _mask;
            set {
                _mask = value;
                SetPositions();
            }
        }

        protected override void OnAttachedTo(Entry entry) {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry) {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private IDictionary<int, char> _positions;

        private void SetPositions() {
            if (string.IsNullOrEmpty(Mask)) {
                _positions = null;
                return;
            }

            Dictionary<int, char> list = new Dictionary<int, char>();
            for (int i = 0; i < Mask.Length; i++) {
                if (Mask[i] != 'X') {
                    list.Add(i, Mask[i]);
                }
            }

            _positions = list;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args) {
            var entry = sender as Entry;

            var text = entry.Text;

            if (string.IsNullOrWhiteSpace(text) || _positions == null) {
                return;
            }

            if (text.Length > _mask.Length) {
                entry.Text = text.Remove(text.Length - 1);
                return;
            }

            foreach (KeyValuePair<int, char> position in _positions) {
                if (text.Length >= position.Key + 1) {
                    string value = position.Value.ToString();
                    if (text.Substring(position.Key, 1) != value) {
                        text = text.Insert(position.Key, value);
                    }
                }
            }

            if (entry.Text != text) {
                entry.Text = text;
            }
        }
    }
}
