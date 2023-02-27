using System;
using System.ComponentModel;

namespace MVVM.Model {
    class MainModel : INotifyPropertyChanged {
        // 전세 관련
        private int num = 1;
        private int num2 = 1;
        private double interest = 1;
        private double monthTotal = 1;
        private double monthTotalInterest = 1;
        private double monthSaveMoney = 1;
        private double creditInterest = 1;
        private int redemption = 1;
        private double yearSaveMoney = 1;

        private int monthMonthlyRent = 1;
        private int monthHouseLease = 1;
        private double monthHouseLeaseInterest = 1;

        private double monthHouseLeaseInterestRate = 1;
        private double monthHouseTotal = 1;

        private int monthRedemption = 1;
        private double monthHouseLeaseSave = 1;
        private double monthYearSaveMoney = 1;

        private double monthCompare = 1;
        private double yearSaveCompare = 1;

        public string Type { get; set; }
        public string Memo { get; set; }
        public DateTime dateTime { get; set; }

        // 연간 저축금액 비교
        public double YearSaveCompare {
            set {
                if (MonthYearSaveMoney > 0) {
                    yearSaveCompare = YearSaveMoney - MonthYearSaveMoney;
                    OnPropertyChanged("YearSaveCompare");
                } else {
                    yearSaveCompare = YearSaveMoney + MonthYearSaveMoney;
                    OnPropertyChanged("YearSaveCompare");
                }

            }
            get { return yearSaveCompare; }
        }
        // 월 지출금액 비교
        public double MonthCompare {
            set {
                if (MonthTotalCash > MonthHouseTotal) {
                    monthCompare = MonthTotalCash - MonthHouseTotal;
                    OnPropertyChanged("MonthCompare");
                } else {
                    monthCompare = MonthHouseTotal - MonthTotalCash;
                    OnPropertyChanged("MonthCompare");
                }

            }
            get { return monthCompare; }
        }

        private string tbSaveCompare = "";
        public string TbSaveCompare {
            set {
                if (MonthHouseTotal > MonthTotalCash) {
                    tbSaveCompare = "원이 더 절약 됩니다";
                    OnPropertyChanged("TbSaveCompare");
                } else {
                    tbSaveCompare = "원이 더 지출 됩니다";
                    OnPropertyChanged("TbSaveCompare");
                }
            }
            get { return tbSaveCompare; }
        }
        // 년 월세살이 저축 예상 금액
        public double MonthYearSaveMoney {
            set {
                monthYearSaveMoney = (MonthHouseLeaseSave * 12) - (MonthMonthlyRent * 12);
                OnPropertyChanged("MonthYearSaveMoney");
            }
            get {
                return monthYearSaveMoney;
            }
        }

        // 보증금 대출 상환 기간
        public int MonthRedemptionPeriod {
            set {
                if (monthRedemption != 0) {
                    monthRedemption = value;
                    OnPropertyChanged("MonthRedemptionPeriod");
                } else {
                    monthRedemption = 1;
                    OnPropertyChanged("MonthRedemptionPeriod");
                }
                
            }
            get {
                return monthRedemption;
            }
        }

        // 월 대출 납부 상환 금액
        public double MonthHouseLeaseSave {
            set {
                monthHouseLeaseSave = MonthHouseLease / MonthRedemptionPeriod;
                OnPropertyChanged("MonthHouseLeaseSave");
            }
            get { return monthHouseLeaseSave; }
        }

        // 월세 월 납부 이자
        public double MonthHouseLeaseInterestRate {
            set {
                monthHouseLeaseInterestRate = monthHouseLease * (MonthHouseLeaseInterest / 100 / 12);
                OnPropertyChanged("MonthHouseLeaseInterestRate");
            }
            get { return monthHouseLeaseInterestRate; }
        }
        // 월세 총 납부 금액
        public double MonthHouseTotal {
            set {
                monthHouseTotal = MonthMonthlyRent + MonthHouseLeaseInterestRate + MonthHouseLeaseSave;
                OnPropertyChanged("MonthHouseTotal");
            }
            get { return monthHouseTotal; }
        }

        // 월세 보증금
        public int MonthHouseLease {
            set {
                monthHouseLease = value;
                OnPropertyChanged("MonthHouseLease");
            }
            get { return monthHouseLease; }
        }

        // 월세 보증금 이자율
        public double MonthHouseLeaseInterest {
            set {
                monthHouseLeaseInterest = value;
                OnPropertyChanged("MonthHouseLeaseInterest");
            }
            get { return monthHouseLeaseInterest; }
        }
        // 월세
        public int MonthMonthlyRent {
            set {
                monthMonthlyRent = value;
                OnPropertyChanged("MonthMonthlyRent");
            }
            get { return monthMonthlyRent; }
        }

        // 년 저축 금액
        public double YearSaveMoney {
            set {
                yearSaveMoney = MonthSaveCash * 12;
                OnPropertyChanged("YearSaveMoney");
            }
            get { return yearSaveMoney; }
        }

        // 월 지출 금액
        public double MonthTotalCash {
            set {
                monthTotal = MonthInterestRate + MonthSaveCash;
                OnPropertyChanged("MonthTotalCash");
            }
            get { return monthTotal; }
        }

        // 월 지출 이자
        public double MonthInterestRate {
            set {
                monthTotalInterest = (Lease * (InterestRate / 100 / 12)) + (CreditLease * (CreditInterestRate / 100 / 12));
                OnPropertyChanged("MonthInterestRate");
            }
            get { return monthTotalInterest; }
        }

        // 월 상환금액
        public double MonthSaveCash {
            set {
                monthSaveMoney = CreditLease / RedemptionPeriod;
                OnPropertyChanged("MonthSaveCash");
            }
            get { return monthSaveMoney; }
        }

        // 전세대출 이자율
        public double InterestRate {
            set {
                interest = value;
                OnPropertyChanged("InterestRate");
            }
            get {
                return interest;
            }
        }

        // 전세대출 금액
        public int Lease {
            set {
                num = value;
                OnPropertyChanged("Lease");
            }
            get {
                return num;
            }
        }

        // 신용 대출 금액
        public int CreditLease {
            get {
                return num2;
            }
            set {
                num2 = value;
                OnPropertyChanged("CreditLease");
            }
        }

        // 신용 대출 이자
        public double CreditInterestRate {
            set {
                creditInterest = value;
                OnPropertyChanged("CreditInterestRate");
            }
            get {
                return creditInterest;
            }
        }

        // 신용 대출 상환 기간
        public int RedemptionPeriod {
            set {
                if (redemption != 0) {
                    redemption = value;
                    OnPropertyChanged("RedemptionPeriod");
                } else {
                    redemption = 1;
                    OnPropertyChanged("RedemptionPeriod");
                }
                
            }
            get {
                return redemption;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
