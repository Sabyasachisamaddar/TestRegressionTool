using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRegressionTool
{

    public class Mark : INotifyPropertyChanged
    {
        private int _id;
        private int _rawMark;
        private int _moderatorMark;
        private int _regressedMark;
        

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public int RawMark
        {
            get { return _rawMark; }
            set
            {
                _rawMark = value;
                NotifyPropertyChanged("RawMark");
            }
        }

        public int ModeratorMark
        {
            get { return _moderatorMark; }
            set
            {
                _moderatorMark = value;
                NotifyPropertyChanged("ModeratorMark");
            }
        }

        public int  RegressedMark
        {
            get { return _regressedMark; }
            set
            {
                _regressedMark = value;
                NotifyPropertyChanged("RegressedMark");
            }
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

}
