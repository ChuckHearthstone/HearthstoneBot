using System.ComponentModel;

namespace HearthstoneBot
{
    public class r0
    {
        private bool SuccessField;

        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                if (!this.SuccessField.Equals(value))
                {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string BodyField;
        public string Body
        {
            get
            {
                return this.BodyField;
            }
            set
            {
                if (this.BodyField != value)
                {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
    }
}
