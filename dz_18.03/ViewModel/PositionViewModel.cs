using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz_18._03.Model;

namespace dz_18._03.ViewModel
{
    public class PositionViewModel : ViewModelBase
    {
        public Position position;
        public PositionViewModel(Position position)
        {
            this.position = position;
        }
        public string NamePosition
        {
            get { return position.NamePosition!; }
            set
            {
                position.NamePosition = value;
                OnPropertyChanged(nameof(NamePosition));
            }
        }
    }
}
