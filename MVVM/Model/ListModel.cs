using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVVM.Model {
    class ListModel : INotifyPropertyChanged {
        private string a;
        private int b;
        private DateTime c;

        public string dataA {
            set {
                this.a = value;
                OnPropertyChanged("dataA");
            }
            get { 
                return this.a; 
            }
        }
        public int dataB {
            set {
                this.b = value;
                OnPropertyChanged("dataB");
            }
            get {
                return this.b;
            }
        }

        public DateTime dataC {
            set {
                this.c = value;
                OnPropertyChanged("dataC");
            }
            get {
                return this.c;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
