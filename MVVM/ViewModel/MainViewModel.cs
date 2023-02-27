using MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM.ViewModel {
    class MainViewModel : ViewModelBase {

        private DateTime date = DateTime.Now;

        private MainModel model;
        public Command btn_cmd { get; set; }
        public Command btnSave { get; set; }
        public Command btnSaveMonth { get; set; }
        public Command btnLoad { get; set; }

        public Command btnDelete { get; set; }

        public MainViewModel(MainWindow ownerWindow) {
            model = new MainModel();
            btn_cmd = new Command(Execute_func, CanExecute_func);
            btnSave = new Command(Execute_save_func, CanExecute_func);
            btnSaveMonth = new Command(Execute_monthSave_func, CanExecute_func);
            btnLoad = new Command(Execute_Load_func, CanExecute_func);
            btnDelete = new Command(Execute_Delete_func, CanExecute_func);
        }
        private int _tabSelected;

        public int TabSelected {
            set {
                _tabSelected = value;
                OnPropertyChanged("TabSelected");
            }
            get {
                return _tabSelected;
            }
        }
        // 선택된 행 인덱스
        private int _selectedIndex;
        public int SelectedIndex {
            set {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
            get { return _selectedIndex; }
        }

        private MainModel _selectedItem;

        public MainModel SelectedItem {
            set {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
            get { return _selectedItem; }
        }

        // 데이터를 품고있는 객체
        ObservableCollection<MainModel> _sampleDatas = null;
        public ObservableCollection<MainModel> SampleDatas {
            get {
                if (_sampleDatas == null) {
                    _sampleDatas = new ObservableCollection<MainModel>();
                }
                return _sampleDatas;
            }
            set {
                _sampleDatas = value;
            }
        }
        // 데이터 삭제
        public void Execute_Delete_func(object obj) {
            if (SelectedIndex < 0) {
                MessageBox.Show("선택된 데이터가 없습니다");
                return;
            } else {
                SampleDatas.RemoveAt(SelectedIndex);
            }
        }

        // 데이터 불러오기
        private void Execute_Load_func(object obj) {
            if (SampleDatas[SelectedIndex].Type.Equals("전세")) {
                model.Lease = SampleDatas[SelectedIndex].Lease;
                model.InterestRate = SampleDatas[SelectedIndex].InterestRate;
                model.CreditLease = SampleDatas[SelectedIndex].CreditLease;
                model.CreditInterestRate = SampleDatas[SelectedIndex].CreditInterestRate;
                model.RedemptionPeriod = SampleDatas[SelectedIndex].RedemptionPeriod;

                string memo = "전세: " + SampleDatas[SelectedIndex].Lease.ToString() + "원";
                MessageBox.Show(memo + " 불러오기 완료");

            } else {
                model.MonthHouseLease = SampleDatas[SelectedIndex].MonthHouseLease;
                model.MonthHouseLeaseInterest = SampleDatas[SelectedIndex].MonthHouseLeaseInterest;
                model.MonthRedemptionPeriod = SampleDatas[SelectedIndex].MonthRedemptionPeriod;
                model.MonthMonthlyRent = SampleDatas[SelectedIndex].MonthMonthlyRent;

                string memo = "보증금 :" + string.Format("{0:n0}", model.MonthHouseLease) + " / 월세 :" + string.Format("{0:n0}", model.MonthMonthlyRent);

                MessageBox.Show(memo + " 불러오기 완료");
            }
        }

        public void choiceData() {
            
        }

        // 전세 데이터 저장 생성
        public void addItem(string type, string memo, DateTime date) {
            MainModel model = new MainModel();

            model.Type = type;
            model.Memo = memo;
            model.dateTime = date;

            if (type.Equals("전세")) {
                model.Lease = this.model.Lease;
                model.InterestRate = this.model.InterestRate;
                model.CreditLease = this.model.CreditLease;
                model.CreditInterestRate = this.model.CreditInterestRate;
                model.RedemptionPeriod = this.model.RedemptionPeriod;

            } else {
                model.MonthHouseLease = this.model.MonthHouseLease;
                model.MonthHouseLeaseInterest = this.model.MonthHouseLeaseInterest;
                model.MonthRedemptionPeriod = this.model.MonthRedemptionPeriod;
                model.MonthMonthlyRent = this.model.MonthMonthlyRent;

            }
            SampleDatas.Add(model);
        }

        public MainModel Model {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        // 전세 저장 버튼
        private void Execute_save_func(object obj) {
            string lease = "전세";
            string memo = string.Format("{0:n0}", model.Lease) + "원";
            MessageBox.Show(lease + memo);

            addItem(lease, memo, date);

            model.Lease = 1;
            model.InterestRate = 1;
            model.CreditInterestRate= 1;
            model.CreditLease = 1;
            model.RedemptionPeriod= 1;

            model.MonthSaveCash = 1;
            model.MonthInterestRate = 1;
            model.MonthSaveCash = 1;
            model.MonthTotalCash = 1;
            model.YearSaveMoney = 1;


        }
        // 월세 저장 버튼
        private void Execute_monthSave_func(object obj) {
            string lease = "월세";
            string memo = "보증금 :" + string.Format("{0:n0}", model.MonthHouseLease) + " / 월세 :" + string.Format("{0:n0}", model.MonthMonthlyRent);
            MessageBox.Show(memo);

            addItem(lease, memo, date);

            model.MonthHouseLease = 1;
            model.MonthHouseLeaseInterest = 1;
            model.MonthRedemptionPeriod = 1;
            model.MonthMonthlyRent = 1;

            model.MonthHouseLeaseInterestRate = 1;
            model.MonthHouseLeaseSave = 1;
            model.MonthHouseTotal = 1;
            model.MonthYearSaveMoney = 1;

            model.MonthCompare = 1;
            model.YearSaveCompare = 1;
        }

        private void Execute_func(object obj) {

            model.MonthSaveCash = model.MonthSaveCash;
            model.MonthInterestRate = model.MonthInterestRate;
            model.MonthSaveCash = model.MonthSaveCash;
            model.MonthTotalCash = model.MonthTotalCash; // 전세 월 고정 지출
            model.YearSaveMoney = model.YearSaveMoney; // 전세 연간 저축 예상 금액

            model.MonthHouseLeaseInterestRate = model.MonthHouseLeaseInterestRate;
            model.MonthHouseLeaseSave = model.MonthHouseLeaseSave;
            model.MonthHouseTotal = model.MonthHouseTotal; // 월세 월 고정 지출
            model.MonthYearSaveMoney = model.MonthYearSaveMoney; // 월세 연간 저축 예상 금액

            model.MonthCompare = model.MonthCompare; // 월 지출 차액
            model.YearSaveCompare = model.YearSaveCompare; // 연 저축 금액 차액
            model.TbSaveCompare = model.TbSaveCompare;
        }

        private bool CanExecute_func(object obj) {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            /*PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }*/
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
