namespace HearthstoneBot.Auth
{
    public class d0 : r0
    {
        private byte[] DataField;
        public byte[] Data
        {
            get
            {
                return this.DataField;
            }
            set
            {
                if (this.DataField != value)
                {
                    this.DataField = value;
                    base.RaisePropertyChanged("Data");
                }
            }
        }

        private string InfoField;
        public string Info
        {
            get
            {
                return this.InfoField;
            }
            set
            {
                if (this.InfoField != value)
                {
                    this.InfoField = value;
                    base.RaisePropertyChanged("Info");
                }
            }
        }
    }
}
